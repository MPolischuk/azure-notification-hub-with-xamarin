
namespace TestReceiveNotification
{
    public static class Configs
    {
        //Datos id y cs
        public const string SenderID = "354289014925"; // Google API Project Number
        public const string ListenConnectionString = "Endpoint=sb://testhubnamesp.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=aT0mwJs8TGUQMOuzOAjbnwig0InpHpY/0gOMTXjXris=";
        public const string NotificationHubName = "TestHub";

        //Datos Tags
        public static bool TagRiver { get; set; }
        public static bool TagBoca { get; set; }
    }
}