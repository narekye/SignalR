$(function () {

    $('#chatBody').hide();
    $('#loginBlock').show();
    var chat = $.connection.chatHub;
    
    chat.client.addMessage = function (name, message) {
    
        $('#chatroom').append('<p><b>' + htmlEncode(name)
            + '</b>: ' + htmlEncode(message) + '</p>');
    };

    
    chat.client.onConnected = function (id, userName, allUsers) {

        $('#loginBlock').hide();
        $('#chatBody').show();
    
        $('#hdId').val(id);
        $('#username').val(userName);
        $('#header').html('<h3>Welcome, ' + userName + '</h3>');

    
        for (var i = 0; i < allUsers.length; i++) {

            AddUser(allUsers[i].ConnectionId, allUsers[i].Name);
        }
    }

    
    chat.client.onNewUserConnected = function (id, name) {

        AddUser(id, name);
    }

    
    chat.client.onUserDisconnected = function (id, userName) {

        $('#' + id).remove();
    }

    
    $.connection.hub.start().done(function () {

        $('#sendmessage').click(function () {
    
            chat.server.send($('#username').val(), $('#message').val());
            $('#message').val('');
        });

    
        $("#btnLogin").click(function () {

            var name = $("#txtUserName").val();
            if (name.length > 0) {
                chat.server.connect(name);
            }
            else {
                alert("Enter name..!!");
            }
        });
    });
});

function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}

function AddUser(id, name) {

    var userId = $('#hdId').val();

    if (userId != id) {

        $("#chatusers").append('<p id="' + id + '"><b>' + name + '</b></p>');
    }
}