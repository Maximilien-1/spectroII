namespace Interface_Spectrographe
{
    partial class C_Affichage
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_STM32 = new System.IO.Ports.SerialPort(this.components);
            this.m_LabelSerialPortChoice = new System.Windows.Forms.Label();
            this.m_BppConnectSerial = new System.Windows.Forms.Button();
            this.m_SerialChoice = new System.Windows.Forms.TextBox();
            this.m_Debug = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_STM32
            // 
            this.m_STM32.BaudRate = 115200;
            this.m_STM32.DtrEnable = true;
            this.m_STM32.PortName = "COM5";
            this.m_STM32.ReadBufferSize = 10;
            this.m_STM32.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.m_STM32_DataReceived);
            // 
            // m_LabelSerialPortChoice
            // 
            this.m_LabelSerialPortChoice.AutoSize = true;
            this.m_LabelSerialPortChoice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_LabelSerialPortChoice.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelSerialPortChoice.ForeColor = System.Drawing.Color.Plum;
            this.m_LabelSerialPortChoice.Location = new System.Drawing.Point(1044, 9);
            this.m_LabelSerialPortChoice.Name = "m_LabelSerialPortChoice";
            this.m_LabelSerialPortChoice.Size = new System.Drawing.Size(128, 18);
            this.m_LabelSerialPortChoice.TabIndex = 0;
            this.m_LabelSerialPortChoice.Text = "Serial port ";
            this.m_LabelSerialPortChoice.Click += new System.EventHandler(this.label1_Click);
            // 
            // m_BppConnectSerial
            // 
            this.m_BppConnectSerial.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_BppConnectSerial.ForeColor = System.Drawing.Color.Purple;
            this.m_BppConnectSerial.Location = new System.Drawing.Point(1047, 56);
            this.m_BppConnectSerial.Name = "m_BppConnectSerial";
            this.m_BppConnectSerial.Size = new System.Drawing.Size(108, 23);
            this.m_BppConnectSerial.TabIndex = 1;
            this.m_BppConnectSerial.Text = "Connect";
            this.m_BppConnectSerial.UseVisualStyleBackColor = true;
            this.m_BppConnectSerial.Click += new System.EventHandler(this.m_BppConnectSerial_Click);
            // 
            // m_SerialChoice
            // 
            this.m_SerialChoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.m_SerialChoice.Location = new System.Drawing.Point(1062, 30);
            this.m_SerialChoice.Name = "m_SerialChoice";
            this.m_SerialChoice.Size = new System.Drawing.Size(78, 20);
            this.m_SerialChoice.TabIndex = 3;
            this.m_SerialChoice.TextChanged += new System.EventHandler(this.m_SerialChoice_TextChanged);
            // 
            // m_Debug
            // 
            this.m_Debug.AutoSize = true;
            this.m_Debug.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_Debug.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_Debug.ForeColor = System.Drawing.Color.Plum;
            this.m_Debug.Location = new System.Drawing.Point(10, 9);
            this.m_Debug.Name = "m_Debug";
            this.m_Debug.Size = new System.Drawing.Size(58, 18);
            this.m_Debug.TabIndex = 4;
            this.m_Debug.Text = "Debug";
            this.m_Debug.Click += new System.EventHandler(this.m_Debug_Click);
            // 
            // C_Affichage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1155, 661);
            this.Controls.Add(this.m_Debug);
            this.Controls.Add(this.m_SerialChoice);
            this.Controls.Add(this.m_BppConnectSerial);
            this.Controls.Add(this.m_LabelSerialPortChoice);
            this.Name = "C_Affichage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort m_STM32;
        private System.Windows.Forms.Label m_LabelSerialPortChoice;
        private System.Windows.Forms.Button m_BppConnectSerial;
        private System.Windows.Forms.TextBox m_SerialChoice;
        private System.Windows.Forms.Label m_Debug;
    }
}

