"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHubs").build();

// connection.on("ReceiveMessage", function (who, message) {   
//         var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
//         var encodedMsg = who + " says " + msg;
//         var li = document.createElement("li");
//         li.textContent = encodedMsg;
//         document.getElementById("messagesList").appendChild(li);
// });

connection.on("ReceiveMessage", function (user, to, message) {
    if (to === document.getElementById("userOutput").children[0].value) {
        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var encodedMsg = user + " says " + msg;
        var li = document.createElement("li");
        li.textContent = encodedMsg;
        document.getElementById("messagesList").appendChild(li);
    }
});


// connection.on("ReceiveMessage", function (message) {
//     var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&lt;");
//     var li = document.createElement("li");
//     var encodedMsg = user + " says " + msg;
//     li.textContent = encodedMsg;
//     document.getElementById("messagesList").appendChild(li);
// });

connection.on("UserConnected", function (connectionId) {
    var groupElement = document.getElementById("userInput");
    var option = document.createElement("option");
    option.text = connectionId;
    option.value = connectionId;
    groupElement.add(option);
});

connection.on("UserDisconnected", function (connectionId) {
    var groupElement = document.getElementById("userOutput");
    for (let i = 0; i < groupElement.length; i++) {
        if (groupElement.options[i].value == connectionId) {
            groupElement.remove(i);
        }

    }
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});


// document.getElementById("sendButton").addEventListener("click", function (event) {
//     var message = document.getElementById("messageInput").value;
//     var groupElement = document.getElementById("userOutput");
//     var groupValue = groupElement.options[groupElement.selectedIndex].value;
//     if (groupValue === "All" || groupValue === "Myself") {
//         var method = groupValue === "All" ? "SendMessageToAll" : "SendMessageToCaller";
//         connection.invoke(method, message).catch(function (err) {
//             return console.error(err.toString());
//         });
//     }
//     else {
//         connection.invoke("SendMessageToUser", groupValue, message).catch(function (err) {
//             return console.error(err.toString());
//         });
//     }
//     event.preventDefault();
// });

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;    
    var to = document.getElementById("userOutput").children[0].value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, to, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});


// document.getElementById("sendButton").addEventListener("click", function (event) {
//     var who = document.getElementById("userInput").value;
//     var message = document.getElementById("messageInput").value;
//     connection.invoke("SendChatMessage", who, message).catch(function (err) {
//         return console.error(err.toString());
//     });
//     event.preventDefault();
// });