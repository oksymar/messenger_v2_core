using System;
using System.Collections;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace messenger_v2.Controllers
{
    public class ChatController : Controller
    {
//        private const String MQTT_BROKER_ADDR = "192.168.0.199";

//        private MqttClient client;

//        private class MsgObject
//        {
//            private String message;
//            private long timestamp;
//
//            public MsgObject(string message, long timestamp)
//            {
//                this.message = message;
//                this.timestamp = timestamp;
//            }
//
//            public string Message
//            {
//                get => message;
//                set => message = value;
//            }
//
//            public long Timestamp
//            {
//                get => timestamp;
//                set => timestamp = value;
//            }
//        }

        private static Queue globalMsgStorage = new Queue();

        // GET: Chat
        public IActionResult ChatPage()
        {
            ViewBag.Title = "Chat Page";

//            if (client == null)
//            {
//                client = new MqttClient(MQTT_BROKER_ADDR);
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
//            var entity = JsonConvert.DeserializeObject<MsgObject>(Encoding.UTF8.GetString(e.Message));
//            globalMsgStorage.Enqueue(entity);
//        }

//        [HttpGet]
//        public string ReceiveMessage()
//        {
//            if (globalMsgStorage.Count != 0)
//            {
//                MsgObject element = (MsgObject) globalMsgStorage.Peek();
//                if (element.Timestamp + 600 < DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
//                {
//                    MsgObject msgObj = (MsgObject) globalMsgStorage.Dequeue();
//                    return JsonConvert.SerializeObject(msgObj);
//                }
//                else
//                {
//                    MsgObject msgObj = (MsgObject) globalMsgStorage.Peek();
//                    return JsonConvert.SerializeObject(msgObj);
//                }
//            }
//
//            return "Error";
//        
    }
}