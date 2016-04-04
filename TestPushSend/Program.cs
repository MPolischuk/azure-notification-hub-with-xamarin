using System;
using Microsoft.Azure.NotificationHubs;

namespace TestPushSend
{
    class Program
    {
        static void Main(string[] args)
        {
            SendNotificationAsync();
            Console.ReadLine();
        }

        private static async void SendNotificationAsync()
        {
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(
                "<ConnectionStringWithFullAccess>",
                "<HubName>");
            await hub.SendGcmNativeNotificationAsync("{ \"data\" : {\"message\":\"Probando Notificaciones desde Azure!\"}}");
        }
    }
}
