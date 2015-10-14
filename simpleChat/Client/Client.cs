using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Collections.Generic;
using System.Net.Sockets;

namespace SimpleChat {

	class Client {

        private static ChatServer server;
        static RemoteChatClient rmc;
        static string registerMe()
        {
            System.Console.WriteLine("Enter a Username:");
            String user = Console.ReadLine();
            System.Console.WriteLine("Enter a Port:");
            int port = Int32.Parse(Console.ReadLine());

            TcpChannel channel = new TcpChannel(port);
            ChannelServices.RegisterChannel(channel, false);

            server = (ChatServer)Activator.GetObject(
               typeof(ChatServer),
               "tcp://localhost:8086/ChatServer"
           );


            ChatClient obj = (ChatClient)Activator.GetObject(
                typeof(ChatClient),
                "tcp://localhost:8086/ChatClient");


            rmc = new RemoteChatClient();
            String clientServiceName = "ChatClient";

            RemotingServices.Marshal(
                rmc,
                clientServiceName,
                typeof(RemoteChatClient)
            );

            if (server != null)
            {
                server.register(user, "tcp://localhost:" + port + "/" + clientServiceName);
            }

            return user;
        }

		static void Main() {

            try
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
		}
	}

    class RemoteChatClient : MarshalByRefObject, ChatClient
    {
        private List<String> muters;

        public RemoteChatClient()
        {
            muters = new List<String>();
        }

        public void mute(String otherUser)
        {
            muters.Add(otherUser);
        }


        public void print(String name, String msg)
        {
            // IS THIS A GOOD APPROACH? CLIENT SIDE MUTE. STILL RECIEVES, JUST IGNORE
            //SHOULD I KEEP A KEY PAR STRUCT IN SERVER SIDE? ASK
            foreach (String c in muters)
            {
                if (name.Equals(c))
                    return;
            }
            System.Console.WriteLine(name + " said: " + msg);
        }
    }
}