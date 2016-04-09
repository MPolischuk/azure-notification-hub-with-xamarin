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
        public FormTestPush()
        {
            InitializeComponent();
        }
        
        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(
                "<FullSharedAccessConnectionString>",
                "<HubName>");

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
                tags.Add("Todos");
            }

            var enviando = await hub.SendGcmNativeNotificationAsync("{ \"data\" : {\"message\":\"" + tvMensaje.Text + "\"}}", tags);
            MessageBox.Show("El mensaje se ha enviado exitosamente", "Mensaje Enviado",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Question);
        }
        
    }
}
