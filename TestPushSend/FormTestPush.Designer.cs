namespace FormPushSend
{
    partial class FormTestPush
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvMensaje = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rbRiver = new System.Windows.Forms.RadioButton();
            this.rbBoca = new System.Windows.Forms.RadioButton();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.groupBoxTags = new System.Windows.Forms.GroupBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.groupBoxTags.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvMensaje
            // 
            this.tvMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvMensaje.Location = new System.Drawing.Point(13, 62);
            this.tvMensaje.Name = "tvMensaje";
            this.tvMensaje.Size = new System.Drawing.Size(406, 20);
            this.tvMensaje.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese mensaje a enviar:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // rbRiver
            // 
            this.rbRiver.AutoSize = true;
            this.rbRiver.Location = new System.Drawing.Point(6, 19);
            this.rbRiver.Name = "rbRiver";
            this.rbRiver.Size = new System.Drawing.Size(50, 17);
            this.rbRiver.TabIndex = 4;
            this.rbRiver.TabStop = true;
            this.rbRiver.Text = "River";
            this.rbRiver.UseVisualStyleBackColor = true;
            // 
            // rbBoca
            // 
            this.rbBoca.AutoSize = true;
            this.rbBoca.Location = new System.Drawing.Point(6, 42);
            this.rbBoca.Name = "rbBoca";
            this.rbBoca.Size = new System.Drawing.Size(50, 17);
            this.rbBoca.TabIndex = 5;
            this.rbBoca.TabStop = true;
            this.rbBoca.Text = "Boca";
            this.rbBoca.UseVisualStyleBackColor = true;
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(6, 65);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(55, 17);
            this.rbTodos.TabIndex = 6;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // groupBoxTags
            // 
            this.groupBoxTags.Controls.Add(this.rbRiver);
            this.groupBoxTags.Controls.Add(this.rbTodos);
            this.groupBoxTags.Controls.Add(this.rbBoca);
            this.groupBoxTags.Location = new System.Drawing.Point(16, 114);
            this.groupBoxTags.Name = "groupBoxTags";
            this.groupBoxTags.Size = new System.Drawing.Size(103, 91);
            this.groupBoxTags.TabIndex = 7;
            this.groupBoxTags.TabStop = false;
            this.groupBoxTags.Text = "Tags";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(80, 241);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(240, 23);
            this.btnEnviar.TabIndex = 8;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // FormTestPush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 295);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.groupBoxTags);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvMensaje);
            this.Name = "FormTestPush";
            this.Text = "Enviar Notificaciones";
            this.groupBoxTags.ResumeLayout(false);
            this.groupBoxTags.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tvMensaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.RadioButton rbRiver;
        private System.Windows.Forms.RadioButton rbBoca;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.GroupBox groupBoxTags;
        private System.Windows.Forms.Button btnEnviar;
    }
}

