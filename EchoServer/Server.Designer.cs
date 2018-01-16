namespace EchoServer
{
    partial class ServerForm
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
            this.consoleGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.consoleMsgTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.serverIPTextBox = new System.Windows.Forms.TextBox();
            this.serverPortTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.param2label = new System.Windows.Forms.Label();
            this.param2TextBox = new System.Windows.Forms.TextBox();
            this.counterLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.param1Label = new System.Windows.Forms.Label();
            this.param1TextBox = new System.Windows.Forms.TextBox();
            this.counterTextBox = new System.Windows.Forms.TextBox();
            this.backgroundReceiver = new System.ComponentModel.BackgroundWorker();
            this.backgroundSender = new System.ComponentModel.BackgroundWorker();
            this.serverTimer = new System.Windows.Forms.Timer(this.components);
            this.backgroundCounter = new System.ComponentModel.BackgroundWorker();
            this.consoleGroupBox.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // consoleGroupBox
            // 
            this.consoleGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.consoleGroupBox.Controls.Add(this.flowLayoutPanel4);
            this.consoleGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.consoleGroupBox.Location = new System.Drawing.Point(12, 170);
            this.consoleGroupBox.Name = "consoleGroupBox";
            this.consoleGroupBox.Size = new System.Drawing.Size(368, 291);
            this.consoleGroupBox.TabIndex = 16;
            this.consoleGroupBox.TabStop = false;
            this.consoleGroupBox.Text = "Console";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel4.Controls.Add(this.consoleTextBox);
            this.flowLayoutPanel4.Controls.Add(this.sendButton);
            this.flowLayoutPanel4.Controls.Add(this.consoleMsgTextBox);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(362, 269);
            this.flowLayoutPanel4.TabIndex = 10;
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.consoleTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.consoleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.consoleTextBox.Location = new System.Drawing.Point(4, 3);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.consoleTextBox.Size = new System.Drawing.Size(355, 235);
            this.consoleTextBox.TabIndex = 11;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sendButton.Location = new System.Drawing.Point(284, 244);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 25);
            this.sendButton.TabIndex = 9;
            this.sendButton.Tag = "consoleTextBox";
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // consoleMsgTextBox
            // 
            this.consoleMsgTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.consoleMsgTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.consoleMsgTextBox.Location = new System.Drawing.Point(3, 244);
            this.consoleMsgTextBox.MaximumSize = new System.Drawing.Size(280, 30);
            this.consoleMsgTextBox.MinimumSize = new System.Drawing.Size(268, 25);
            this.consoleMsgTextBox.Name = "consoleMsgTextBox";
            this.consoleMsgTextBox.Size = new System.Drawing.Size(275, 20);
            this.consoleMsgTextBox.TabIndex = 10;
            this.consoleMsgTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.consoleMsgTextBox_KeyDown);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.serverIPTextBox);
            this.flowLayoutPanel1.Controls.Add(this.serverPortTextBox);
            this.flowLayoutPanel1.Controls.Add(this.startButton);
            this.flowLayoutPanel1.Controls.Add(this.stopButton);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(356, 29);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // serverIPTextBox
            // 
            this.serverIPTextBox.AccessibleDescription = "Server IP";
            this.serverIPTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverIPTextBox.Location = new System.Drawing.Point(3, 4);
            this.serverIPTextBox.MinimumSize = new System.Drawing.Size(130, 20);
            this.serverIPTextBox.Name = "serverIPTextBox";
            this.serverIPTextBox.Size = new System.Drawing.Size(132, 20);
            this.serverIPTextBox.TabIndex = 0;
            this.serverIPTextBox.Text = "0.0.0.0";
            this.serverIPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // serverPortTextBox
            // 
            this.serverPortTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverPortTextBox.Location = new System.Drawing.Point(141, 4);
            this.serverPortTextBox.MinimumSize = new System.Drawing.Size(50, 20);
            this.serverPortTextBox.Name = "serverPortTextBox";
            this.serverPortTextBox.Size = new System.Drawing.Size(50, 20);
            this.serverPortTextBox.TabIndex = 1;
            this.serverPortTextBox.Text = "16090";
            this.serverPortTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startButton.Location = new System.Drawing.Point(197, 3);
            this.startButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(278, 3);
            this.stopButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Close";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 57);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Control";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.flowLayoutPanel5);
            this.groupBox2.Controls.Add(this.counterLabel);
            this.groupBox2.Controls.Add(this.flowLayoutPanel2);
            this.groupBox2.Controls.Add(this.counterTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 89);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.AutoSize = true;
            this.flowLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel5.Controls.Add(this.param2label);
            this.flowLayoutPanel5.Controls.Add(this.param2TextBox);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(201, 49);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(158, 26);
            this.flowLayoutPanel5.TabIndex = 17;
            // 
            // param2label
            // 
            this.param2label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.param2label.AutoSize = true;
            this.param2label.Location = new System.Drawing.Point(3, 6);
            this.param2label.Name = "param2label";
            this.param2label.Size = new System.Drawing.Size(46, 13);
            this.param2label.TabIndex = 9;
            this.param2label.Text = "Param2:";
            // 
            // param2TextBox
            // 
            this.param2TextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.param2TextBox.Location = new System.Drawing.Point(55, 3);
            this.param2TextBox.Name = "param2TextBox";
            this.param2TextBox.Size = new System.Drawing.Size(100, 20);
            this.param2TextBox.TabIndex = 6;
            this.param2TextBox.Text = "13";
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
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.param1Label);
            this.flowLayoutPanel2.Controls.Add(this.param1TextBox);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(201, 13);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(158, 26);
            this.flowLayoutPanel2.TabIndex = 16;
            // 
            // param1Label
            // 
            this.param1Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.param1Label.AutoSize = true;
            this.param1Label.Location = new System.Drawing.Point(3, 6);
            this.param1Label.Name = "param1Label";
            this.param1Label.Size = new System.Drawing.Size(46, 13);
            this.param1Label.TabIndex = 6;
            this.param1Label.Text = "Param1:";
            // 
            // param1TextBox
            // 
            this.param1TextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.param1TextBox.Location = new System.Drawing.Point(55, 3);
            this.param1TextBox.Name = "param1TextBox";
            this.param1TextBox.Size = new System.Drawing.Size(100, 20);
            this.param1TextBox.TabIndex = 5;
            this.param1TextBox.Text = "553";
            this.param1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // counterTextBox
            // 
            this.counterTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.counterTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.counterTextBox.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.counterTextBox.Location = new System.Drawing.Point(21, 38);
            this.counterTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 2);
            this.counterTextBox.MaximumSize = new System.Drawing.Size(120, 55);
            this.counterTextBox.MaxLength = 9;
            this.counterTextBox.MinimumSize = new System.Drawing.Size(120, 30);
            this.counterTextBox.Name = "counterTextBox";
            this.counterTextBox.ReadOnly = true;
            this.counterTextBox.Size = new System.Drawing.Size(120, 30);
            this.counterTextBox.TabIndex = 15;
            this.counterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // backgroundReceiver
            // 
            this.backgroundReceiver.WorkerSupportsCancellation = true;
            this.backgroundReceiver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundReceiver_DoWork);
            // 
            // backgroundSender
            // 
            this.backgroundSender.WorkerSupportsCancellation = true;
            this.backgroundSender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundSender_DoWork);
            // 
            // serverTimer
            // 
            this.serverTimer.Tick += new System.EventHandler(this.serverTimer_Tick);
            // 
            // backgroundCounter
            // 
            this.backgroundCounter.WorkerSupportsCancellation = true;
            this.backgroundCounter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundCounter_DoWork);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 473);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.consoleGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 500);
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "ServerForm";
            this.Text = "Echo Server";
            this.consoleGroupBox.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox consoleGroupBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox serverIPTextBox;
        private System.Windows.Forms.TextBox serverPortTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox consoleMsgTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label param2label;
        private System.Windows.Forms.TextBox param2TextBox;
        private System.Windows.Forms.Label counterLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label param1Label;
        private System.Windows.Forms.TextBox param1TextBox;
        private System.Windows.Forms.TextBox counterTextBox;
        private System.Windows.Forms.TextBox consoleTextBox;
        private System.ComponentModel.BackgroundWorker backgroundReceiver;
        private System.ComponentModel.BackgroundWorker backgroundSender;
        private System.Windows.Forms.Timer serverTimer;
        private System.ComponentModel.BackgroundWorker backgroundCounter;
    }
}

