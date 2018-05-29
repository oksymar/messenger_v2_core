// var client;
var MQTT_BROKER_ADDR = "192.168.0.199";

//seTimer();
connectMQTT();

function sendMessage() {
    var messageWindow = document.getElementsByName("messageWindow")[0];
    var messageMQTT = {
        message: messageWindow.value,
        timestamp: Date.now()
    };

    messageWindow.value = "";

    var messagePaho = new Paho.MQTT.Message(JSON.stringify(messageMQTT));
    messagePaho.destinationName = "/chat";
    client.send(messagePaho);

    // $.ajax({
    //     url: '/Chat/SendMessageMQTT',
    //     type: 'POST',
    //     data: {message: JSON.stringify(messageMQTT)}
    // });
}

// function seTimer() {
//     setInterval(function () {
//         $.ajax({
//             url: '/Chat/ReceiveMessage',
//             type: 'GET',
//             success: handlereceivedMessage
//         });
//     }, 500);
//
// }

// function handlereceivedMessage(data) {
//     if (data !== "Error") {
//         $("#ChatBox").append("<span>"+data.message+"</span>");
//     }
// }

//PAHO
function connectMQTT() {
    //client = new Paho.MQTT.Client(MQTT_BROKER_ADDR, Number(1883),"", "clientId");
    client = new Paho.MQTT.Client("test.mosquitto.org", Number(443), "clientId");
    client.onConnectionLost = onConnectionLost;
    client.onMessageArrived = onMessageArrived;
    client.connect({
        onSuccess: onConnect
    });
}

// called when the client connects
function onConnect() {
    // Once a connection has been made, make a subscription and send a message.
    console.log("onConnect");
    client.subscribe("/chat");
}

// called when the client loses its connection
function onConnectionLost(responseObject) {
    if (responseObject.errorCode !== 0) {
        console.log("onConnectionLost:" + responseObject.errorMessage);
    }
}

// called when a message arrives
function onMessageArrived(message) {
    $("#ChatBox").append("<span>" + data.message + "</span>");
}