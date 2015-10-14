using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace SimpleChat {

    class TheClient
    {
       public String name;
       public String url;
       public ChatClient _ref;
    }


	class Server: MarshalByRefObject, ChatServer {
        private const int PORT = 8086;
        private List<TheClient> clientList = new List<TheClient>();

        static TcpChannel channel = new TcpChannel(PORT);

		static void Main(string[] args) {
			ChannelServices.RegisterChannel(channel,false);

			RemotingConfiguration.RegisterWellKnownServiceType(
				typeof(Server),
				"ChatServer",
				WellKnownObjectMode.Singleton);
      
			System.Console.WriteLine("<enter> para sair...");
			System.Console.ReadLine();
		}

        public void register(String name, String url)
        {
            TheClient c = new TheClient();
            ChatClient client = (ChatClient) Activator.GetObject(
                typeof(ChatClient),
                url
            );

            c.name = name;
            c.url = url;
            c._ref = client;

            clientList.Add(c);

            Console.WriteLine("Connected folk with url = " + url + " ; with nick = " + name);
        }


        public bool ask(String user)
        {
            foreach (TheClient c in clientList)
            {
                if (c.name == user)
                    return true;
            }
            return false;
        }


        public void notifyBan(String nick, String other)
        {
            System.Console.WriteLine(nick + " just muted " + other);
        }
        public void sendMessage(String nick, String msg)
        {
            Console.WriteLine("Sending message = " + msg + " ; from nick = " + nick);
            foreach (TheClient c in clientList)
            {
                if (c.name == nick)
                    continue;
                    c._ref.print(nick, msg);
            }
        }

     
	}
}