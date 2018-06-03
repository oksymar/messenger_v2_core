using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using messenger_v2_core.DataAccessLayer;
using messenger_v2_core.Models;
using Microsoft.AspNetCore.Mvc;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.ManagedClient;
using Newtonsoft.Json;

namespace messenger_v2.Controllers
{
    public class ChatController : Controller
    {
        private const String MQTT_BROKER_ADDR = "192.168.0.199:3000/mqtt";
        private const int MQTT_BROKER_PORT = 3000;

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
                using (var db = new StoreDbContext())
                {
                    var msg = new GlobalMsgModel{Message = "asdfrt", Timestamp = 123, Username = "Us1"};
                    db.GlobalMsg.Add(msg);
                    db.SaveChanges();
                }
            };

//            if (client == null)
//            {
//                client = new MqttClient(MQTT_BROKER_ADDR, MQTT_BROKER_PORT, false, (X509Certificate) null,
//                    (X509Certificate) null, MqttSslProtocols.None);
//            }
//
//            client.MqttMsgPublishReceived += ReceiveMessageMQTT;
//            string clientId = Guid.NewGuid().ToString();
//            client.Connect(clientId);
//            client.Subscribe(new string[] {"/chat"}, new byte[] {MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE});

            return View();
        }

//        [HttpPost]
//        public void SendMessageMQTT(string message)
//        {
//            if (client == null)
//            {
//                client = new MqttClient(MQTT_BROKER_ADDR);
//                string clientId = Guid.NewGuid().ToString();
//                client.Connect(clientId);
//            }
//
//            client.Publish("/chat", Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
//                false);
//        }

//        public void ReceiveMessageMQTT(object sender, MqttMsgPublishEventArgs e)
//        {
//            var message = JsonConvert.DeserializeObject<GlobalMsgModel>(Encoding.UTF8.GetString(e.Message));
//            using (var db = new StoreDbContext())
//            {
//                db.GlobalMsg.Add(message);
//                db.SaveChanges();
//
////                // Display all Blogs from the database 
////                var query = from b in db.Blogs
////                    orderby b.Name
////                    select b;
//            }
//        }
    }
}