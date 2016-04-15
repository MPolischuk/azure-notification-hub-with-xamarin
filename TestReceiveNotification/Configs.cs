
namespace TestReceiveNotification
{
    public static class Configs
    {
        //Datos id y cs
        public const string SenderID = "<API Number>"; // Google API Project Number
        public const string ListenConnectionString = "<ListenConnectionString>";
        public const string NotificationHubName = "<NotificationHubName>";

        //Datos Tags
        public static bool TagRiver { get; set; }
        public static bool TagBoca { get; set; }
    }
}