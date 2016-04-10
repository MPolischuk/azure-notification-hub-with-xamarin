using System;
using System.Collections.Generic;
using System.Text;
using WindowsAzure.Messaging;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Util;
using Gcm.Client;
using TestReceiveNotification;

[assembly: UsesPermission(Android.Manifest.Permission.ReceiveBootCompleted)]

//MUY MUY MUY IMPORTANTE!!!
//El package name NO DEBE comenzar con una letra mayuscula

namespace Sample
{
    [BroadcastReceiver(Permission = Constants.PERMISSION_GCM_INTENTS)]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    [IntentFilter(new string[] { Constants.INTENT_FROM_GCM_MESSAGE }, Categories = new string[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new string[] { Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK }, Categories = new string[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new string[] { Constants.INTENT_FROM_GCM_LIBRARY_RETRY }, Categories = new string[] { "@PACKAGE_NAME@" })]
    public class GcmBroadcastReceiver : GcmBroadcastReceiverBase<PushHandlerService>
    {
        public static string[] SENDER_IDS = new string[] { Configs.SenderID };

        public const string TAG = "PushSharp-GCM";
    }

    [Service] //Must use the service tag
    public class PushHandlerService : GcmServiceBase
    {
        public PushHandlerService() : base(GcmBroadcastReceiver.SENDER_IDS) { }

        const string TAG = "GCM-SAMPLE";
        private NotificationHub Hub { get; set; }

        protected override void OnRegistered(Context context, string registrationId)
        {
            Log.Verbose(TAG, "GCM Registrado: " + registrationId);

            //Creamos la notificación
            CreateNotification("GCM Registrado...", "El Dispositivo ha sido registrado, toque para ver.");

            //Creamos nuestro Hub enviando como parámetro el "hub name" y el "ListenConnectionString"
            Hub = new NotificationHub(Configs.NotificationHubName, Configs.ListenConnectionString,
                                        context);
            try
            {
                Hub.UnregisterAll(registrationId);
            }
            catch (Exception ex)
            {
                Log.Error(TAG, ex.Message);
            }

            //Creamos array de tags según la seleccion del usuario
            var tags = CrearTags();

            try
            {
                var hubRegistration = Hub.Register(registrationId, tags.ToArray());
            }
            catch (Exception ex)
            {
                Log.Error(TAG, ex.Message);
            }
        }

        protected override void OnUnRegistered(Context context, string registrationId)
        {
            Log.Verbose(TAG, "GCM Des-Registrado: " + registrationId);

            //Creamos la notificación
            CreateNotification("GCM Des-Registrado...", "El dispositvo ha sido des-registrado, toque para ver.");
        }

        protected override void OnMessage(Context context, Intent intent)
        {
            Log.Info(TAG, "Mensaje GCM recibido!");

            var msg = new StringBuilder();

            if (intent != null && intent.Extras != null)
            {
                foreach (var key in intent.Extras.KeySet())
                    msg.AppendLine(key + "=" + intent.Extras.Get(key));
            }

            //Guardamos el mensaje
            var prefs = GetSharedPreferences(context.PackageName, FileCreationMode.Private);
            var edit = prefs.Edit();
            edit.PutString("last_msg", msg.ToString());
            edit.Commit();

            string messageText = intent.Extras.GetString("message");
            if (!string.IsNullOrEmpty(messageText))
            {
                CreateNotification("Nuevo mensaje desde HUB!", messageText);
            }
            else
            {
                CreateNotification("Detalles del mensaje desconocidos", msg.ToString());
            }
        }

        protected override bool OnRecoverableError(Context context, string errorId)
        {
            Log.Warn(TAG, "Recoverable Error: " + errorId);

            return base.OnRecoverableError(context, errorId);
        }

        protected override void OnError(Context context, string errorId)
        {
            Log.Error(TAG, "GCM Error: " + errorId);
        }

        void CreateNotification(string title, string desc)
        {
            //Creamos el notificationManager
            var notificationManager = GetSystemService(NotificationService) as NotificationManager;

            //Creamos el intent 
            var uiIntent = new Intent(this, typeof(MainActivity));

            //Creamos la notificación (aparecera con el logo de e-mail)
            var notification = new Notification(Android.Resource.Drawable.SymActionEmail, title)
            {
                //Auto-cancel removera la notificacion cuando el usuario la toque.
                Flags = NotificationFlags.AutoCancel,
                Sound = RingtoneManager.GetDefaultUri(RingtoneType.Notification),
                Vibrate = new long[] {1000,0,1000}            
            };

            notification.Defaults = NotificationDefaults.All;

            //Seteamos la informacion de la notificación
            notification.SetLatestEventInfo(this, title, desc, PendingIntent.GetActivity(this, 0, uiIntent, 0));

            //Mostramos la notificación
            notificationManager.Notify(1, notification);
        }

        public List<string> CrearTags()
        {
            var tags = new List<string>() { };
            if (Configs.TagRiver)
            {
                tags.Add("River");
            }
            if (Configs.TagBoca)
            {
                tags.Add("Boca");
            }
            if (Configs.TagTodos)
            {
                tags.Add("Todos");
            }

            return tags;
        }
    }
}