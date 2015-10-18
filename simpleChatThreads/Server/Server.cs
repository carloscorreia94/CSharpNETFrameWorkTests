using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;

namespace SimpleChat {

    delegate void ThrWork();

    class TheClient
    {
       public String name;
       public String url;
       public ChatClient _ref;
    }

    class ThrPool
    {
        List<Thread> pool;
        List<ThrWork> buffer;

        public ThrPool(int thrNum, int bufSize)
        {
            buffer = new List<ThrWork>(bufSize);
            pool = new List<Thread>(thrNum);
            for (int i = 0; i <= thrNum; i++)
            {
                Thread t = new Thread(new ThreadStart(this.DoWork));
                pool.Add(t);
                t.Start();
            }
        }


        private void DoWork()
        {
            //done when initializing but its always waiting for job, so when we add elements to buffer it'll do the job!
            while (true)
            {
                Monitor.Enter(this);
                if (buffer.Count > 0)
                {
                    // does work in the first available buffer slot
                    ThrWork work = (ThrWork)buffer[0];
                    buffer.RemoveAt(0);
                    Monitor.Exit(this);
                    work();
                }
                else
                {
                    Monitor.Exit(this);
                }
            }
        }

        public void AssyncInvoke(ThrWork action)
        {
            if (buffer.Count != 0 && buffer.Capacity == buffer.Count)
            {
                buffer.RemoveAt(0);
            }
            buffer.Add(action);
        }
    }


    class B
    {
        private String nick, msg;
        private ChatClient refl;
        public B(String nick, String msg, ChatClient refl)
        {
            this.nick = nick;
            this.msg = msg;
            this.refl = refl;
        }

        public void DoWorkB()
        {
            refl.print(nick, msg);
        }
    }

	class Server: MarshalByRefObject, ChatServer {
        private const int PORT = 8086;
        private List<TheClient> clientList = new List<TheClient>();
        private static ThrPool tpool;
        static TcpChannel channel = new TcpChannel(PORT);


        static void initialize()
        {
            tpool = new ThrPool(5, 10);
        }

		static void Main(string[] args) {
            initialize();
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


        public void sendMessage(String nick, String msg)
        {
            Console.WriteLine("Sending message = " + msg + " ; from nick = " + nick);
            foreach (TheClient c in clientList)
            {
                if (c.name == nick)
                    continue;
                B b = new B(nick, msg, c._ref);
                tpool.AssyncInvoke(new ThrWork(b.DoWorkB));
            }
        }

     
	}
}