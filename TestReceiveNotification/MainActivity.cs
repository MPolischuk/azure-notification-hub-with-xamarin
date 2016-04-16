using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Gcm.Client;
using TestReceiveNotification;

namespace Sample
{
    [Activity(Label = "Hub Client Sample", MainLauncher = true,
        LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]
    public class MainActivity : Activity
    {
        const string TAG = "GCM-CLIENT";

        TextView textRegistrationStatus;
        TextView textRegistrationId;
        TextView textLastMsg;
        Button buttonRegister;
        CheckBox checkBoxRiver;
        CheckBox checkBoxBoca;
        bool registered;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Seteamos nuestra vista desde el "main" Layout 
            SetContentView(TestReceiveNotification.Resource.Layout.Main);

            textRegistrationStatus = FindViewById<TextView>(TestReceiveNotification.Resource.Id.textRegistrationStatus);
            textRegistrationId = FindViewById<TextView>(TestReceiveNotification.Resource.Id.textRegistrationId);
            textLastMsg = FindViewById<TextView>(TestReceiveNotification.Resource.Id.textLastMessage);
            buttonRegister = FindViewById<Button>(TestReceiveNotification.Resource.Id.buttonRegister);
            checkBoxRiver = FindViewById<CheckBox>(TestReceiveNotification.Resource.Id.checkboxRiver);
            checkBoxBoca = FindViewById<CheckBox>(TestReceiveNotification.Resource.Id.checkboxBoca);

            Log.Info(TAG, "Hello World");

            //Verificamos que todo se haya configurado adecuadamente
            GcmClient.CheckDevice(this);
            GcmClient.CheckManifest(this);


            buttonRegister.Click += delegate
            {
                if (!registered)
                {
                    Log.Info(TAG, "Registering...");

                    //Seteamos los tags segun la selección actual
                    Configs.TagRiver = checkBoxRiver.Checked;
                    Configs.TagBoca = checkBoxBoca.Checked;

                    //Llamamos al metodo Register (enviandole nuestro sender Id)
                    GcmClient.Register(this, GcmBroadcastReceiver.SENDER_IDS);
                }
                else
                {
                    Log.Info(TAG, "Unregistering...");

                    //Llamamos al metodo Unregister
                    GcmClient.UnRegister(this);
                }

                //Desabilitamos el boton para impedir multiples peticiones 
                RunOnUiThread(() => buttonRegister.Enabled = false);
            };
        }

        protected override void OnResume()
        {
            base.OnResume();

            //Se ejecuta al presionar en la notificación
            UpdateView();
        }

        void UpdateView()
        {
            //Obtenemos el ultimo Id registrado
            var registrationId = GcmClient.GetRegistrationId(this);

            //If it's empty, we need to register
            if (string.IsNullOrEmpty(registrationId))
            {
                registered = false;
                textRegistrationStatus.Text = "Registrado: No";
                textRegistrationId.Text = "Id: N/A";
                buttonRegister.Text = "Registrar";

                Log.Info(TAG, "Not registered...");
            }
            else
            {
                registered = true;
                textRegistrationStatus.Text = "Registrado: Yes";
                textRegistrationId.Text = "Id: " + registrationId;
                buttonRegister.Text = "Eliminar Registro";

                Log.Info(TAG, "Ya está registrado: " + registrationId);
            }

            var prefs = GetSharedPreferences(PackageName, FileCreationMode.Private);
            textLastMsg.Text = "Ultimo Mensaje: " + prefs.GetString("last_msg", "N/A");
            //checkBoxRiver.Checked = prefs.GetBoolean("tagRiver", false);
            //checkBoxBoca.Checked = prefs.GetBoolean("tagBoca", false);

            //Habilitamos el boton de registro
            buttonRegister.Enabled = true;
        }
    }
}