var timestamp;

seTimer();

function sendMessage() {
    var messageWindow = document.getElementsByName("messageWindow")[0];
    var messageMQTT = {
        message: messageWindow.value,
        timestamp: Date.now()
    };

    messageWindow.value = "";

    $.ajax({
        url: '/Chat/SendMessageMQTT',
        type: 'POST',
        data: {message: JSON.stringify(messageMQTT)}
    });
}

function seTimer() {
    setInterval(function () {
        $.ajax({
            url: '/Chat/ReceiveMessage',
            type: 'GET',
            success: handlereceivedMessage
        });
    }, 500);

}

function handlereceivedMessage(data) {
    if (data !== "Error") {
        $("#ChatBox").append("<span>"+data.message+"</span>");
    }
}