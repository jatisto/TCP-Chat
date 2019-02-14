"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHubs").build();

connection.on("ReceiveMessage", function (user, to, message) {
    if (to === document.getElementById("userOutput").children[0].value) {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var encodedMsg = user + " says " + msg;
        var li = document.createElement("li");
        li.textContent = encodedMsg;
        document.getElementById("messagesList").appendChild(li);
    }
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").children[0].value;    
    var to = document.getElementById("userOutput").children[0].value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, to, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});