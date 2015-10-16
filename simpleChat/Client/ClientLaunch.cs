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
       /*     try
            {
                string user = registerMe();
                while (true)
                {
                    String type = Console.ReadLine();
                    string[] split = type.Split(' ');
                    switch (split[0])
                    {
                        case "send":
                            String msg = split[1];
                            server.sendMessage(user, msg);
                            break;
                        case "mute":
                            String userMute = split[1];
                            if (!server.ask(userMute))
                            {
                                System.Console.WriteLine("Non existent User");
                            } else {
                                server.notifyBan(user, userMute);
                                rmc.mute(userMute);
                            }
                            break;
                        default:
                            System.Console.WriteLine("Command not found");
                            break;
                    }
                }

            }
            catch (SocketException)
            {
                System.Console.WriteLine("Could not locate server");
            }
            catch (FormatException e)
            {
                System.Console.WriteLine("Invalid format port");
            }
            catch (RemotingException e)
            {
                System.Console.WriteLine(e);
            }
			Console.ReadLine();
		} */
	}

  
}