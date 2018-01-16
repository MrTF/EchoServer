using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread clientThread = new Thread(ThreadStart);
            clientThread.TrySetApartmentState(ApartmentState.STA);
            clientThread.Start();

            ServerForm serverForm = new ServerForm();

            Application.Run(serverForm);
            
            if (clientThread.IsAlive)
                clientThread.Abort();
        }

        private static void ThreadStart()
        {
            ClientForm clientForm = new ClientForm();
            Application.Run(clientForm);
        }
    }
}
