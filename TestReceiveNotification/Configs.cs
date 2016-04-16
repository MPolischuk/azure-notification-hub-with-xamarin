
namespace TestReceiveNotification
{
    public static class Configs
    {
        //Datos id y cs
        public const string SenderID = "<API Number>"; // Google API Project Number
        public const string ListenConnectionString = "<LiseConnectionString>";
        public const string NotificationHubName = "<HubName>";

        //Datos Tags
        public static bool TagRiver { get; set; }
        public static bool TagBoca { get; set; }
    }
}