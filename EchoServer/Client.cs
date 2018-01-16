using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Diagnostics;


namespace EchoServer
{
    public partial class ClientForm : Form
    {
        // TCP client object 
        private TcpClient tcpClient;

        // TCP stream reader and writers
        public StreamReader SReader;
        public StreamWriter SWriter;

        // Global message variables used across threads
        private string msgReceived;
        private string msgToSend;
        private string receivedTag = "";

        // Shorthand used in long if/else clauses
        private TextBox tb;

        // Handy flags to communicate with background workers
        private AutoResetEvent SenderDoneEvent = new AutoResetEvent(false);
        private AutoResetEvent ReceiverDoneEvent = new AutoResetEvent(false);
        

        /// <summary>
        /// Print debuging 
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

        public ClientForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Established new connection to the Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpClient != null && tcpClient.Connected)
                    throw new Exception("Already connected to the server.");

                // Connect to the server addressed in the text boxes
                tcpClient = new TcpClient();
                IPEndPoint IPEnd = new IPEndPoint(
                    IPAddress.Parse(serverIPTextBox.Text), int.Parse(serverPortTextBox.Text));

                Log("Connecting...");
                tcpClient.Connect(IPEnd);
                if (tcpClient.Connected)
                {
                    string msg = "Connection established.";
                    Log(msg);
                    consoleTextBox1.AppendText(msg);
                    consoleTextBox2.AppendText(msg);
                    
                    // Pipe client's stream
                    SWriter = new StreamWriter(tcpClient.GetStream());
                    SReader = new StreamReader(tcpClient.GetStream());
                    SWriter.AutoFlush = true;

                    // Send to background
                    backgroundReceiver.RunWorkerAsync();

                    connectButton.Enabled = false;
                    disconnectButton.Enabled = true;
                }
                
            } catch (Exception exp)
            {
                Log(exp.Message.ToString());
                MessageBox.Show(exp.Message.ToString());
            }
        }

        /// <summary>
        /// Terminates the connection from Client to Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpClient == null || ! tcpClient.Connected)
                    throw new Exception("Not connected.");

                string msg = "Disconnecting...";
                this.consoleTextBox1.Invoke(new MethodInvoker(
                    delegate() { 
                        consoleTextBox1.AppendText(msg); 
                        consoleTextBox2.AppendText(msg); 
                    }));

                disposeConnection();

                this.disconnectButton.Invoke(new MethodInvoker(
                    delegate() { 
                        disconnectButton.Enabled = false;
                        connectButton.Enabled = true; }));
                
                Log("Toggled buttons");

                msg = "Disconnected.";
                this.consoleTextBox1.Invoke(new MethodInvoker(
                    delegate() { 
                        consoleTextBox1.AppendText(msg);
                        consoleTextBox2.AppendText(msg); }));
                Log(msg);
            }
            catch (Exception exp)
            {
                Log(exp.Message.ToString());
                MessageBox.Show(exp.Message.ToString(), Ctx());
            }
        }

        /// <summary>
        /// Upon disconnect request, clean up sockets and running threads
        /// </summary>
        private void disposeConnection()
        {

            Log("Closing streams...");
            if (tcpClient != null)
                tcpClient.GetStream().Close();

            Log("Disposing sockets...");
            if (tcpClient != null)
                tcpClient.Close();
            Log("OK");

            SReader = null;
            SWriter = null;
            tcpClient = null;

            backgroundReceiver.CancelAsync();
            backgroundReceiver.Dispose();

            backgroundSender.CancelAsync();
            backgroundSender.Dispose();            
        }

        /// <summary>
        /// Request value of parameter1 from server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getParam1Button_Click(object sender, EventArgs e)
        {
            // All messages are prepended with a tag.
            // So both server and the client knows what to do with them
            // See backgroundReceiver for more info
            Button senderButton = (Button)sender;
            msgToSend = senderButton.Tag + "|";
            Log(msgToSend);

            backgroundSender.RunWorkerAsync();
        }

        /// <summary>
        /// Request value of parameter2 from server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getParam2Button_Click(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            msgToSend = senderButton.Tag + "|";
            Log(msgToSend);

            backgroundSender.RunWorkerAsync();
        }

        /// <summary>
        ///  Sends input message from Console1 to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendButton1_Click(object sender, EventArgs e)
        {
            // Reject empty string.
            if (consoleMsgTextBox1.Text == "") return;

            // Acceptable messsages are first posted on the local console,
            // with sender ID being local IP
            string ts = DateTime.Now.ToString("HH:mm ddd dd.MM.yyyy");
            string from = IPAddress.Any.ToString();
            string msg = "[" + ts + "] " + from + "> " +  consoleMsgTextBox1.Text  + "\n";
            consoleTextBox1.AppendText(msg);

            // Messeges are sent with a tag attached, which tells receiver how to treat the message. 
            Button senderButton = (Button)sender;
            msgToSend = senderButton.Tag + "|" + consoleMsgTextBox1.Text;
            consoleMsgTextBox1.Clear();

            Log(msgToSend);
            
            backgroundSender.RunWorkerAsync();
            this.ActiveControl = consoleMsgTextBox1;
        }

        /// <summary>
        /// Sends input message from Console2 to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendButton2_Click(object sender, EventArgs e)
        {
            if (consoleMsgTextBox2.Text == "") return;
            
            // This is put in postToConsole in Server.cs
            string ts = DateTime.Now.ToString("HH:mm ddd dd.MM.yyyy");
            string from = IPAddress.Any.ToString();
            string msg = "[" + ts + "] " + from + "> " +  consoleMsgTextBox2.Text  + "\n";
            consoleTextBox2.AppendText(msg);

            Button senderButton = (Button)sender;
            msgToSend = senderButton.Tag + "|" + consoleMsgTextBox2.Text;
            consoleMsgTextBox2.Clear();

            Log(msgToSend);

            backgroundSender.RunWorkerAsync();
            this.ActiveControl = consoleMsgTextBox2;
        }

        /// <summary>
        /// Background worker for continuously receiving and parsing network stream. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            while (tcpClient != null && tcpClient.Connected && SReader != null)
            {
                try
                {
                    msgReceived = SReader.ReadLine();
                    if (msgReceived == null)
                        throw new Exception("Remote connection closed.");
                    Log("msgReceived:" + msgReceived.ToString());
                    
                    /* examples for TAG|MESSAGE format
                    consoleTextBox1|Hello
                    consoleTextBox2|Hi.
                    counterTextBox|1
                    param1TextBox|123
                    param2TextBox|312
                    */

                    // Split tag from message
                    string[] split = msgReceived.Split("|".ToCharArray(), 2);

                    // Determine message destination
                    // Console1 will be the default when there is no tag.
                    tb = consoleTextBox1;
                    // Message for counter and parameter tags will be the value itself
                    string receivedTag = ""; 
                    string msg = "";

                    // Server may use no tag for messages from its console.
                    if (split.Length == 0)
                        continue;
                    // tag only
                    if (split.Length == 1)
                        msg = split[0];
                    // tag|msg
                    if (split.Length == 2)
                    {
                        receivedTag = split[0];
                        msg = split[1];
                    }
                    Log("msgTag:" + receivedTag);
                    Log("msg:" + msg);

                    // Timer update
                    if (receivedTag == "counterTextBox")
                    {
                        tb = counterTextBox;
                        this.tb.Invoke(new MethodInvoker(
                            delegate() { tb.Clear(); tb.AppendText(msg); }));
                    }
                    // Response to param requests.
                    else if (receivedTag == "param1TextBox")
                    {
                        tb = param1TextBox;
                        this.tb.Invoke(new MethodInvoker(delegate() { tb.Clear(); tb.AppendText(msg); }));
                    }
                    else if (receivedTag == "param2TextBox")
                    {
                        tb = param2TextBox;
                        this.tb.Invoke(new MethodInvoker(delegate() { tb.Clear(); tb.AppendText(msg); }));
                    }
                    // Server says shuting down. 
                    else if (receivedTag == "ByeBye")
                    {
                        msg = "Server " + tcpClient.Client.RemoteEndPoint.ToString() + " has gone offline.\n";
                        this.consoleTextBox1.Invoke(new MethodInvoker(
                            delegate() { consoleTextBox1.AppendText(msg); }));
                        // Clean up out ties to server
                        disconnectButton_Click(sender, e);
                        //break;
                    }
                    // Otherwise Post message on the respective console
                    else if (receivedTag == "consoleTextBox1")
                    {
                        tb = consoleTextBox1;
                        // post received msg
                        string from = tcpClient.Client.RemoteEndPoint.ToString();
                        string ts = DateTime.Now.ToString("HH:mm ddd dd.MM.yyyy");
                        msg = "[" + ts + "] " + from + "> " + msg + "\n";
                        this.tb.Invoke(new MethodInvoker(delegate() { tb.AppendText(msg); }));
                        
                    }
                    else if (receivedTag == "consoleTextBox2")
                    {
                        tb = consoleTextBox2;
                        string ts = DateTime.Now.ToString("HH:mm ddd dd.MM.yyyy");
                        string from = tcpClient.Client.RemoteEndPoint.ToString();
                        msg = "[" + ts + "] " + from + "> " + msg + "\n";
                        this.tb.Invoke(new MethodInvoker(delegate() { tb.AppendText(msg); }));
                    }
                    // Message from Server's console.
                    else if (receivedTag == "")
                    {
                        tb = consoleTextBox1;
                        string ts = DateTime.Now.ToString("HH:mm ddd dd.MM.yyyy");
                        string from = tcpClient.Client.RemoteEndPoint.ToString();
                        msg = "[" + ts + "] " + from + "> " + msg + "\n";
                        this.tb.Invoke(new MethodInvoker(delegate() { tb.AppendText(msg); }));
                    }
                } 
                catch (Exception exp)
                {
                    Log(exp.Message.ToString());
                }
            }
            // Stream closed remotely.
            ReceiverDoneEvent.Set();
            backgroundReceiver.CancelAsync();
        }

        
        /// <summary>
        /// Backgroundworker for transmiting client's messages to the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundSender_DoWork(object sender, DoWorkEventArgs e)
        {
            if (tcpClient != null && tcpClient.Connected && SWriter != null)
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
            // Does its work and stops
            SenderDoneEvent.Set();
            backgroundSender.CancelAsync();
        }

        /// <summary>
        /// Enter key sends the message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consoleMsgTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sendButton1_Click(sendButton1, e);
        }

        /// <summary>
        /// Enter key sends the message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consoleMsgTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sendButton2_Click(sendButton2, e);
        }
    }
}
