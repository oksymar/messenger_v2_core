
using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace messenger_v2.Controllers
{
    public class ChatController : Controller
    {
        private const String MQTT_BROKER_ADDR = "192.168.0.199";

        private MqttClient client;
        // GET: Chat
        public IActionResult ChatPage()
        {
            ViewBag.Title = "Chat Page";

            return View();
        }
        
        [HttpPost]
        public void SendMessage(string message)
        {
            string clientId = Guid.NewGuid().ToString();
            if (client == null)
            {
                client = new MqttClient(MQTT_BROKER_ADDR);
            }
            client.Connect(clientId);
            
            client.Publish("/chat", Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        }

    }
}