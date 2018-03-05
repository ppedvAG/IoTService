<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeldungsListe.aspx.cs" Inherits="IoTService.MeldungsListe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery.signalR-2.2.2.js"></script>
    <script src="/signalr/hubs"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Meldungen </h1>

            <asp:GridView ID="GridView1" runat="server" CssClass="table"
                ItemType="IoTService.ServiceMeldungen"
                SelectMethod="GridView1_GetData">
            </asp:GridView>
        </div>
        <script>
            var connection = $.hubConnection();
            var contosoChatHubProxy = connection.createHubProxy('meldungenHub');
            contosoChatHubProxy.on('refreshUI', function (message) {
                var row = '<tr>';
                row += '<td>' + message.Id + '</td>';
                row += '<td>' + message.Meldung + '</td>';
                row += '<td>' + message.Datum + '</td>';
                row += '</tr>';
                $("#GridView1 tbody").append(row);
                $("#GridView1").animate({ scrollTop: $('#GridView1').prop("scrollHeight") }, 1000);

            });
            connection.start().done(function () {

            });
        </script>
    </form>
</body>
</html>
