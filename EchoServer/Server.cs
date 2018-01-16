using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EchoServer
{
    public partial class ServerForm : Form
    {
        //readonly Form clientForm = new ClientForm();
        //protected override void OnLoad(EventArgs e)
        //{
        //    clientForm.FormClosed += ClientFormClosing;
        //    clientForm.Show();
        //    base.OnLoad(e);
        //}

        //private void ClientFormClosing(object sender, FormClosedEventArgs e)
        //{
        //    this.Close();
        //}


        // TCP stream reader and writers
        public StreamReader SReader;
        public StreamWriter SWriter;

        // TCP client and listenler object 
        public TcpClient tcpClient;
        public TcpListener tcpListener;
        // Thread for listening connectioon async.ly
        public Thread listenerThread;
        // Option for it.
        public bool acceptAsync = false; 

        // Global message variables used across threads
        public string msgReceived = "";
        public string msgToSend = "";
        public string receivedTag;

        // Handy flags to communicate with background workers
        private AutoResetEvent SenderDoneEvent = new AutoResetEvent(false);
        private AutoResetEvent ReceiverDoneEvent = new AutoResetEvent(false);

        // manually increamently counter value on every Tick of Timer
        private int counter;
        private int counterInit = 100;
        private int counterInc = 100;
        private int timerInterval = 1000;
        private int charNum;
        private System.Windows.Forms.Timer animeTimer = new System.Windows.Forms.Timer();
        private string animeText;
        // Sanity check boolean
        public bool serverIsRunning = false;
        
        

        /// <summary>
        /// Print debuging with context
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="memberName">Caller method</param>
        /// <param name="filePath">Source file path on disk</param>
        /// <param name="lineNumber">Line number from which Log was called</param>
        public static void Log(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Trace.WriteLine(String.Format("{0}_{1}({2}):{3}",
                Path.GetFileName(filePath), memberName, lineNumber, message));
        }

        /// <summary>
        /// Context provider for message boxes.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        /// <param name="memberName">Caller method</param>
        /// <param name="filePath">Source file path on disk</param>
        /// <param name="lineNumber">Line number from which Log was called</param>
        public static string Ctx(
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            return String.Format("{0}_{1}({2})",
                Path.GetFileName(filePath), memberName, lineNumber);
        }

        public ServerForm()
        {
            // Initialize Server Control Form
            InitializeComponent();
            
            // Determine the local IP address that Server will be running on.
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress IP in localIPs)
            {
                // Enter IPv4 one on the form for readabilty
                if (IP.AddressFamily == AddressFamily.InterNetwork)
                {
                    serverIPTextBox.Text = IP.ToString();
                    //break;
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpClient != null && tcpClient.Connected)
                    throw new Exception("Already connected to the server.");

                // Connect to the server addressed in the text boxes
                tcpClient = new TcpClient();
                IPEndPoint IPEnd = new IPEndPoint(
                    IPAddress.Parse(serverIPTextBox.Text), 
                    int.Parse(serverPortTextBox.Text));

                consoleTextBox.AppendText("Starting Server...");
                
                // Start counter
                startTimer();

                // Setup a listener for incoming clients
                tcpListener = new TcpListener
                    (IPAddress.Any, int.Parse(serverPortTextBox.Text));
                tcpListener.Start();

                consoleTextBox.AppendText("OK.\n");

                // Option for non-blocking accept method
                acceptAsync = false;
                if (!acceptAsync)
                {
                    consoleTextBox.AppendText("Waiting for connections...\n");
                    tcpClient = tcpListener.AcceptTcpClient();
                    // We have a client
                    string msg = "Client " + tcpClient.Client.RemoteEndPoint.ToString() + " connected.\n";
                    consoleTextBox.AppendText(msg);

                    // Pipe client's stream
                    SReader = new StreamReader(tcpClient.GetStream());
                    SWriter = new StreamWriter(tcpClient.GetStream());
                    SWriter.AutoFlush = true;

                    // Send to background
                    backgroundReceiver.RunWorkerAsync();
                }
                else
                {   // FIXME
                    Log("Starting new Thread for async listening");
                    listenerThread = new Thread(() => AcceptAsync(tcpListener));
                    listenerThread.Name = "listenerThread";
                    listenerThread.Start();
                }

                serverIsRunning = true;
                startButton.Enabled = false;
                stopButton.Enabled = true;
            }
            catch (Exception exp)
            {
                Log(exp.Message.ToString());
                MessageBox.Show(exp.Message.ToString(), Ctx());
            }
        }

        /// <summary>
        /// Starts server timer used to run the counter
        /// </summary>
        private void startTimer()
        {
            // Timer tick callback will send counter value to the client
            serverTimer.Enabled = true;
            counter = counterInit;
            counterTextBox.Text = counter.ToString();
            serverTimer.Interval = timerInterval;
            serverTimer.Start();
        }

        /// <summary>
        /// Stop server timer used to run the counter
        /// </summary>
        private void stopTimer()
        {
            if (serverTimer.Enabled)
            {
                serverTimer.Stop();
                backgroundCounter.CancelAsync();
            }
        }

        /// <summary>
        /// FIXME 
        /// Simpler alternative to TcpClient.AcceptTcpClientAsync;
        /// </summary>
        /// <param name="tcpListener"></param>
        private void AcceptAsync(TcpListener tcpListener)
        {
            try
            {
                while (tcpClient == null || ! tcpClient.Connected)
                {
                    Log("Accepting new connections..");
                    string msg = "Waiting for connections...\n";
                    this.consoleTextBox.Invoke(new MethodInvoker(
                            delegate() { consoleTextBox.AppendText(msg); }));

                    using (tcpClient = tcpListener.AcceptTcpClient())
                    {
                        msg = "Client " + tcpClient.Client.RemoteEndPoint.ToString() + " connected.\n";
                        Log(msg);
                        this.consoleTextBox.Invoke(new MethodInvoker(
                            delegate() { consoleTextBox.AppendText(msg); }));

                        // Pipe client's stream
                        SReader = new StreamReader(tcpClient.GetStream());
                        SWriter = new StreamWriter(tcpClient.GetStream());
                        SWriter.AutoFlush = true;

                        // Send to background
                        backgroundReceiver.RunWorkerAsync();
                        break;
                    }
                }
            }
            catch (Exception exp)
            {
                Log(exp.Message.ToString());
                MessageBox.Show(exp.Message.ToString(), Ctx());
            }
            Log("Done");
        }

        /// <summary>
        /// Close connection and clean up 
        /// </summary>
        private void disposeClientConnection()
        {
            Log("Closing streams...");
            if (tcpClient != null && tcpClient.Connected)
                tcpClient.GetStream().Close();

            Log("Disposing sockets...");
            if (tcpClient != null)
                tcpClient.Close();
            Log("OK");

            SReader = null;
            SWriter = null;
            tcpClient = null;

            serverTimer.Stop();
            serverTimer.Enabled = false;
            backgroundCounter.CancelAsync();
            backgroundCounter.Dispose();

            backgroundReceiver.CancelAsync();
            backgroundReceiver.Dispose();

            backgroundSender.CancelAsync();
            backgroundSender.Dispose();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (serverIsRunning == false)
                    throw new Exception("Not connected.");

                stopButton.Enabled = false;
                startButton.Enabled = true;
                serverIsRunning = false;

                Log("Stopping server...");
                this.consoleTextBox.Invoke(
                    new MethodInvoker(delegate() 
                        { consoleTextBox.AppendText("Stopping server...\n"); }));                

                // Notify connected clients
                if (tcpClient != null && tcpClient.Connected)
                {
                    msgToSend = "ByeBye|";
                    backgroundSender.RunWorkerAsync();
                }

                Log("Stopping timer...");
                stopTimer();
                    
                disposeClientConnection();

                Log("Disposing listener thread...");
                if (listenerThread != null && listenerThread.IsAlive)
                    listenerThread.Join();
                Log("Stopped server.");

                this.consoleTextBox.Invoke(new MethodInvoker(
                    delegate() { consoleTextBox.AppendText("Stopped server.\n"); }));                


                this.Close();
            }
            catch (Exception exp)
            {
                Log(exp.Message.ToString());
                MessageBox.Show(exp.ToString(), Ctx());
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            // Reject empty input
            if (consoleMsgTextBox.Text == "") return;
            
            // Post message on local console immediately
            postToConsole(consoleMsgTextBox.Text, IPAddress.Any.ToString());

            // Use previous message's tag if any
            if (receivedTag != "")
                msgToSend = receivedTag + '|' + consoleMsgTextBox.Text;
            else
                msgToSend = consoleMsgTextBox.Text;

            consoleMsgTextBox.Clear();
            Log(msgToSend);

            backgroundSender.RunWorkerAsync();
            this.ActiveControl = consoleMsgTextBox;
        }

        private void backgroundReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            while (tcpClient != null && tcpClient.Connected && SReader != null)
            {
                try
                {
                    msgReceived = SReader.ReadLine();
                    if (msgReceived == null) continue;
                    Log(msgReceived);

                    // Split tag from message
                    string[] split = msgReceived.Split("|".ToCharArray(), 2);

                    // Parse message, response or post.
                    string msg = "";

                    /* Examples for TAG|MESSAGE format
                    consoleTextBox1|Hello       Sent from Console2. Message will be posted to Server Console. 
                                                Next response will be addressed to Client's Console1.
                    consoleTextBox2|Bye bye.    Sent from Console2. Message will be posted to Server Console.
                                                Next response will be addressed to Client's Console2.
                    param1TextBox|              Resquest for param2, param1 will be sent.
                    param2TextBox|              Resquest for param2, param1 will be sent.
                    */

                    // There is nothing but a tag. Expected case of param request
                    if (split.Length == 1)
                        receivedTag = split[0];

                    // Tag followed by a message
                    if (split.Length == 2)
                    {
                        // This tag (either console1 or console2) will be prerended 
                        // to the next message to be sent so the client know on which 
                        // console the message should be posted.
                        receivedTag = split[0];
                        // This message will be posted on the console.
                        msg = split[1];
                    }

                    // Handle tagged messaged
                    if (receivedTag == "param1TextBox")
                    {
                        msgToSend = receivedTag + '|' + param1TextBox.Text;
                        receivedTag = "";
                        backgroundSender.RunWorkerAsync();
                    }
                    else if (receivedTag == "param2TextBox")
                    {
                        msgToSend = receivedTag + '|' + param2TextBox.Text;
                        receivedTag = "";
                        backgroundSender.RunWorkerAsync();
                    }
                    else if (receivedTag == "ByeBye")
                    {
                        msg = "Client " + tcpClient.Client.RemoteEndPoint.ToString() + " disconnected.\n";
                        postToConsole(msg, tcpClient.Client.RemoteEndPoint.ToString());
                        disposeClientConnection();
                    }
                    else
                    {
                        // post received msg
                        string from = tcpClient.Client.RemoteEndPoint.ToString();
                        postToConsole(msg, from);
                    }
                }
                catch (Exception exp)
                {
                    Log(exp.Message.ToString());
                }
            }
            //ReceiverDoneEvent.Set();
            backgroundReceiver.CancelAsync();
        }

        private void postToConsole(string msg, string from)
        {
            string ts = DateTime.Now.ToString("HH:mm ddd dd.MM.yyyy");
            from = tcpClient.Client.RemoteEndPoint.ToString();
            msg = "[" + ts + "] " + from + "> " + msg + "\n";
            this.consoleTextBox.Invoke(new MethodInvoker(delegate()
                { consoleTextBox.AppendText(msg); }));
        }

        // Message sending thread
        private void backgroundSender_DoWork(object sender, DoWorkEventArgs e)
        {
            if (tcpClient != null && tcpClient.Connected  && SWriter != null)
            {
                Log("msgToSend:" + msgToSend);
                SWriter.WriteLine(msgToSend);
            }
            else
            {
                string msg = "Not connected to the server.";
                Log(msg);
                MessageBox.Show(msg, Ctx());
            }
            Log("Done.");
            msgToSend = "";
            SenderDoneEvent.Set();
            backgroundSender.CancelAsync();
        }

        // Timer Tick called every Timer.interval = 2000 ms
        private void serverTimer_Tick(object sender, EventArgs e)
        {
            // Update counter value on the form.
            this.counterTextBox.Invoke(new MethodInvoker(
                            delegate()
                            {
                                counterTextBox.Clear();
                                counterTextBox.AppendText(counter.ToString());
                            }));
            
            // Add 10 to the counter value to be sent
            msgToSend = "counterTextBox" + "|" + (counter + 10).ToString();

            // Not really real time in timesharing machine.
            // Drop package.
            if (!backgroundCounter.IsBusy)
                backgroundCounter.RunWorkerAsync();
            else
                Log("Skipped:" + counter.ToString());
            
            //AnimateTextIntoTextbox(counter);
            counter += counterInc;
        }

        /// <summary>
        /// Sends counter value to the client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundCounter_DoWork(object sender, DoWorkEventArgs e)
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                SWriter.WriteLine(msgToSend);
            }
            msgToSend = "";
            backgroundCounter.CancelAsync();
        }

        /// <summary>
        /// Enter sends the message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consoleMsgTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sendButton_Click(sendButton, e);
        }

        /// <summary>
        /// Animate counter text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void animeTimer_Tick(object sender, EventArgs e)
        {
            Log("animeText:" + animeText);
            Log("animeText.Length:" + animeText.Length); 
            Log("charNum:" + charNum);
            
            if (charNum == animeText.Length)
            {
                charNum = 0;
                animeTimer.Stop();
                animeTimer.Tick -= new System.EventHandler(this.animeTimer_Tick);
                animeTimer.Enabled = false;
                Log("Done.");
                return;
            }

            string ss = animeText.Substring(charNum, 1).ToString();
            Log("ss:" + ss);
            //counterTextBox.Text += ss;
            this.counterTextBox.Invoke(
                new MethodInvoker(delegate() {
                    counterTextBox.Text = counterTextBox.Text + ss; 
                }));
            Log("counterTextBox.Text:" + counterTextBox.Text);
            charNum += 1;
        }

        private void AnimateTextIntoTextbox(int c)
        {
            animeText = c.ToString().PadLeft(9, '0');
            this.counterTextBox.Invoke(
                new MethodInvoker(delegate() { 
                    counterTextBox.Text = ""; }));
            
            charNum = 0;
            animeTimer.Interval = 20;
            animeTimer.Tick += new System.EventHandler(this.animeTimer_Tick);
            animeTimer.Enabled = true;
            animeTimer.Start();
        }

    }
}
