namespace EchoServer
{
    partial class ClientForm
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
            this.backgroundReceiver = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.serverIPTextBox = new System.Windows.Forms.TextBox();
            this.serverPortTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.getParam2Button = new System.Windows.Forms.Button();
            this.param2TextBox = new System.Windows.Forms.TextBox();
            this.counterLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.getParam1Button = new System.Windows.Forms.Button();
            this.param1TextBox = new System.Windows.Forms.TextBox();
            this.counterTextBox = new System.Windows.Forms.TextBox();
            this.consoleGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.consoleTextBox1 = new System.Windows.Forms.TextBox();
            this.consoleMsgTextBox1 = new System.Windows.Forms.TextBox();
            this.sendButton1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.consoleTextBox2 = new System.Windows.Forms.TextBox();
            this.consoleMsgTextBox2 = new System.Windows.Forms.TextBox();
            this.sendButton2 = new System.Windows.Forms.Button();
            this.backgroundSender = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.consoleGroupBox.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundReceiver
            // 
            this.backgroundReceiver.WorkerSupportsCancellation = true;
            this.backgroundReceiver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundReceiver_DoWork);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 57);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Connection";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.serverIPTextBox);
            this.flowLayoutPanel1.Controls.Add(this.serverPortTextBox);
            this.flowLayoutPanel1.Controls.Add(this.connectButton);
            this.flowLayoutPanel1.Controls.Add(this.disconnectButton);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(356, 29);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // serverIPTextBox
            // 
            this.serverIPTextBox.AccessibleDescription = "Server IP";
            this.serverIPTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.serverIPTextBox.Location = new System.Drawing.Point(3, 4);
            this.serverIPTextBox.MinimumSize = new System.Drawing.Size(130, 20);
            this.serverIPTextBox.Name = "serverIPTextBox";
            this.serverIPTextBox.Size = new System.Drawing.Size(132, 20);
            this.serverIPTextBox.TabIndex = 0;
            this.serverIPTextBox.Text = "10.0.2.15";
            this.serverIPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serverPortTextBox
            // 
            this.serverPortTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.serverPortTextBox.Location = new System.Drawing.Point(141, 4);
            this.serverPortTextBox.MinimumSize = new System.Drawing.Size(50, 20);
            this.serverPortTextBox.Name = "serverPortTextBox";
            this.serverPortTextBox.Size = new System.Drawing.Size(50, 20);
            this.serverPortTextBox.TabIndex = 1;
            this.serverPortTextBox.Text = "16090";
            this.serverPortTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // connectButton
            // 
            this.connectButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.connectButton.Location = new System.Drawing.Point(197, 3);
            this.connectButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(278, 3);
            this.disconnectButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 3;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.flowLayoutPanel5);
            this.groupBox2.Controls.Add(this.counterLabel);
            this.groupBox2.Controls.Add(this.flowLayoutPanel4);
            this.groupBox2.Controls.Add(this.counterTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 89);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel5.Controls.Add(this.getParam2Button);
            this.flowLayoutPanel5.Controls.Add(this.param2TextBox);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(175, 49);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(187, 26);
            this.flowLayoutPanel5.TabIndex = 17;
            // 
            // getParam2Button
            // 
            this.getParam2Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.getParam2Button.Location = new System.Drawing.Point(3, 3);
            this.getParam2Button.Name = "getParam2Button";
            this.getParam2Button.Size = new System.Drawing.Size(75, 20);
            this.getParam2Button.TabIndex = 8;
            this.getParam2Button.Tag = "param2TextBox";
            this.getParam2Button.Text = "Get Param2";
            this.getParam2Button.UseVisualStyleBackColor = true;
            this.getParam2Button.Click += new System.EventHandler(this.getParam2Button_Click);
            // 
            // param2TextBox
            // 
            this.param2TextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.param2TextBox.Location = new System.Drawing.Point(84, 3);
            this.param2TextBox.Name = "param2TextBox";
            this.param2TextBox.ReadOnly = true;
            this.param2TextBox.Size = new System.Drawing.Size(100, 20);
            this.param2TextBox.TabIndex = 6;
            this.param2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // counterLabel
            // 
            this.counterLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.counterLabel.AutoSize = true;
            this.counterLabel.Location = new System.Drawing.Point(55, 20);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(44, 13);
            this.counterLabel.TabIndex = 14;
            this.counterLabel.Text = "Counter";
            this.counterLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel4.Controls.Add(this.getParam1Button);
            this.flowLayoutPanel4.Controls.Add(this.param1TextBox);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(175, 13);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(187, 26);
            this.flowLayoutPanel4.TabIndex = 16;
            // 
            // getParam1Button
            // 
            this.getParam1Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.getParam1Button.Location = new System.Drawing.Point(3, 3);
            this.getParam1Button.Name = "getParam1Button";
            this.getParam1Button.Size = new System.Drawing.Size(75, 20);
            this.getParam1Button.TabIndex = 7;
            this.getParam1Button.Tag = "param1TextBox";
            this.getParam1Button.Text = "Get Param1";
            this.getParam1Button.UseVisualStyleBackColor = true;
            this.getParam1Button.Click += new System.EventHandler(this.getParam1Button_Click);
            // 
            // param1TextBox
            // 
            this.param1TextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.param1TextBox.Location = new System.Drawing.Point(84, 3);
            this.param1TextBox.Name = "param1TextBox";
            this.param1TextBox.ReadOnly = true;
            this.param1TextBox.Size = new System.Drawing.Size(100, 20);
            this.param1TextBox.TabIndex = 5;
            this.param1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // counterTextBox
            // 
            this.counterTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.counterTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.counterTextBox.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.counterTextBox.Location = new System.Drawing.Point(21, 42);
            this.counterTextBox.MaximumSize = new System.Drawing.Size(120, 30);
            this.counterTextBox.MaxLength = 15;
            this.counterTextBox.MinimumSize = new System.Drawing.Size(120, 30);
            this.counterTextBox.Name = "counterTextBox";
            this.counterTextBox.ReadOnly = true;
            this.counterTextBox.Size = new System.Drawing.Size(120, 30);
            this.counterTextBox.TabIndex = 15;
            this.counterTextBox.Tag = "counterTextBox";
            this.counterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // consoleGroupBox
            // 
            this.consoleGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.consoleGroupBox.Controls.Add(this.flowLayoutPanel2);
            this.consoleGroupBox.Controls.Add(this.flowLayoutPanel3);
            this.consoleGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.consoleGroupBox.Location = new System.Drawing.Point(12, 172);
            this.consoleGroupBox.Name = "consoleGroupBox";
            this.consoleGroupBox.Size = new System.Drawing.Size(368, 289);
            this.consoleGroupBox.TabIndex = 20;
            this.consoleGroupBox.TabStop = false;
            this.consoleGroupBox.Text = "Console";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.consoleTextBox1);
            this.flowLayoutPanel2.Controls.Add(this.consoleMsgTextBox1);
            this.flowLayoutPanel2.Controls.Add(this.sendButton1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(362, 131);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // consoleTextBox1
            // 
            this.consoleTextBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.consoleTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.consoleTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.consoleTextBox1.Location = new System.Drawing.Point(3, 3);
            this.consoleTextBox1.Multiline = true;
            this.consoleTextBox1.Name = "consoleTextBox1";
            this.consoleTextBox1.ReadOnly = true;
            this.consoleTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleTextBox1.Size = new System.Drawing.Size(355, 96);
            this.consoleTextBox1.TabIndex = 11;
            // 
            // consoleMsgTextBox1
            // 
            this.consoleMsgTextBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.consoleMsgTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.consoleMsgTextBox1.Location = new System.Drawing.Point(3, 105);
            this.consoleMsgTextBox1.MaximumSize = new System.Drawing.Size(280, 30);
            this.consoleMsgTextBox1.MinimumSize = new System.Drawing.Size(250, 25);
            this.consoleMsgTextBox1.Name = "consoleMsgTextBox1";
            this.consoleMsgTextBox1.Size = new System.Drawing.Size(275, 20);
            this.consoleMsgTextBox1.TabIndex = 13;
            this.consoleMsgTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.consoleMsgTextBox1_KeyDown);
            // 
            // sendButton1
            // 
            this.sendButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendButton1.Location = new System.Drawing.Point(284, 105);
            this.sendButton1.Name = "sendButton1";
            this.sendButton1.Size = new System.Drawing.Size(75, 25);
            this.sendButton1.TabIndex = 12;
            this.sendButton1.Tag = "consoleTextBox1";
            this.sendButton1.Text = "Send";
            this.sendButton1.UseVisualStyleBackColor = true;
            this.sendButton1.Click += new System.EventHandler(this.sendButton1_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.consoleTextBox2);
            this.flowLayoutPanel3.Controls.Add(this.consoleMsgTextBox2);
            this.flowLayoutPanel3.Controls.Add(this.sendButton2);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 155);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(362, 131);
            this.flowLayoutPanel3.TabIndex = 12;
            // 
            // consoleTextBox2
            // 
            this.consoleTextBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.consoleTextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.consoleTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.consoleTextBox2.Location = new System.Drawing.Point(3, 3);
            this.consoleTextBox2.Multiline = true;
            this.consoleTextBox2.Name = "consoleTextBox2";
            this.consoleTextBox2.ReadOnly = true;
            this.consoleTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleTextBox2.Size = new System.Drawing.Size(355, 96);
            this.consoleTextBox2.TabIndex = 11;
            // 
            // consoleMsgTextBox2
            // 
            this.consoleMsgTextBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.consoleMsgTextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.consoleMsgTextBox2.Location = new System.Drawing.Point(3, 105);
            this.consoleMsgTextBox2.MaximumSize = new System.Drawing.Size(280, 30);
            this.consoleMsgTextBox2.MinimumSize = new System.Drawing.Size(250, 25);
            this.consoleMsgTextBox2.Name = "consoleMsgTextBox2";
            this.consoleMsgTextBox2.Size = new System.Drawing.Size(275, 20);
            this.consoleMsgTextBox2.TabIndex = 13;
            this.consoleMsgTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.consoleMsgTextBox2_KeyDown);
            // 
            // sendButton2
            // 
            this.sendButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendButton2.Location = new System.Drawing.Point(284, 105);
            this.sendButton2.Name = "sendButton2";
            this.sendButton2.Size = new System.Drawing.Size(75, 25);
            this.sendButton2.TabIndex = 12;
            this.sendButton2.Tag = "consoleTextBox2";
            this.sendButton2.Text = "Send";
            this.sendButton2.UseVisualStyleBackColor = true;
            this.sendButton2.Click += new System.EventHandler(this.sendButton2_Click);
            // 
            // backgroundSender
            // 
            this.backgroundSender.WorkerSupportsCancellation = true;
            this.backgroundSender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundSender_DoWork);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 473);
            this.Controls.Add(this.consoleGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 500);
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Echo Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.consoleGroupBox.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundReceiver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox serverIPTextBox;
        private System.Windows.Forms.TextBox serverPortTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox consoleGroupBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Button getParam2Button;
        private System.Windows.Forms.TextBox param2TextBox;
        private System.Windows.Forms.Label counterLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button getParam1Button;
        private System.Windows.Forms.TextBox param1TextBox;
        private System.Windows.Forms.TextBox counterTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TextBox consoleTextBox2;
        private System.Windows.Forms.TextBox consoleMsgTextBox2;
        private System.Windows.Forms.Button sendButton2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox consoleTextBox1;
        private System.Windows.Forms.TextBox consoleMsgTextBox1;
        private System.Windows.Forms.Button sendButton1;
        private System.ComponentModel.BackgroundWorker backgroundSender;
    }
}