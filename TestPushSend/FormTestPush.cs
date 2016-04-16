using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.NotificationHubs;

namespace FormPushSend
{
    public partial class FormTestPush : Form
    {
        public NotificationHubClient NotificationHubClient { get; set; }

        public FormTestPush()
        {
            InitializeComponent();
            NotificationHubClient = NotificationHubClient.CreateClientFromConnectionString(
           "Endpoint=sb://testhubnamesp.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=XiKW2cHuSiiIpVS5WCQdxzCW/8XfSo+VExbwHKb4l/o=",
           "TestHub");
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            var tags = new List<string>() { };
            if (rbRiver.Checked)
            {
                tags.Add("River");
            }
            if (rbBoca.Checked)
            {
                tags.Add("Boca");
            }
            if (rbTodos.Checked)
            {
                await
                    NotificationHubClient.SendGcmNativeNotificationAsync("{ \"data\" : {\"message\":\"" + tvMensaje.Text +
                                                                         "\"}}");
                MessageBox.Show("El mensaje se ha enviado exitosamente", "Mensaje Enviado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
            }
            else
            {
                await NotificationHubClient.SendGcmNativeNotificationAsync("{ \"data\" : {\"message\":\"" + tvMensaje.Text + "\"}}", tags);
                MessageBox.Show("El mensaje se ha enviado exitosamente", "Mensaje Enviado",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Question);
            }

     
        }

    }
}
