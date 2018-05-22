function sendMessage() {
    var messageWindow = document.getElementsByName("messageWindow")[0];
    var message = messageWindow.value;
    messageWindow.value = "";
    
    $.ajax({
        url: '/Chat/SendMessage',
        type: 'POST',
        data: {message: message}
    });
}