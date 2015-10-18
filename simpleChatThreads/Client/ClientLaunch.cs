using System;
using System.Windows.Forms;

namespace SimpleChat {

	class ClientLaunch {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatClientForm());

        }
	}

  
}