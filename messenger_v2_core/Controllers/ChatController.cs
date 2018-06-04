using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using messenger_v2_core.DataAccessLayer;
using messenger_v2_core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.ManagedClient;
using Newtonsoft.Json;

namespace messenger_v2.Controllers
{
    public class ChatController : Controller
    {
        private const String MQTT_BROKER_ADDR = "192.168.0.199:3000/mqtt";

//        private MqttClient client;
        
        IMqttClient mqttClient  = new MqttFactory().CreateMqttClient();
        
        // GET: Chat
        public IActionResult ChatPage()
        {
            ViewBag.Title = "Chat Page";

            // Use WebSocket connection.
            var options = new MqttClientOptionsBuilder()
                .WithWebSocketServer(MQTT_BROKER_ADDR)
                .Build();

            Task task = new Task (async () =>{
                await mqttClient.ConnectAsync(options);
            });
            task.Start();
            task.Wait();


            mqttClient.Connected += async (s, e) =>
            {
                await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("/chat").Build());
            };

            mqttClient.ApplicationMessageReceived += (s, e) =>
            {
                var message = JsonConvert.DeserializeObject<GlobalMsgModel>(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                
                var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();
                optionsBuilder.UseInMemoryDatabase();
                using (var db = new StoreDbContext(optionsBuilder.Options))
                {
                    var msg = new GlobalMsgModel{Message = "asdfrt", Timestamp = 123, Username = "Us1"};
                    db.GlobalMsg.Add(msg);
                    db.SaveChanges();
                }
            };
            return View();
        }
    }
}