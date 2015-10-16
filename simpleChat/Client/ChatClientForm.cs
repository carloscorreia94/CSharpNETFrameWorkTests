using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Net.Sockets;

namespace SimpleChat
{

    public delegate void UIDel(String nick, String msg);

    public partial class ChatClientForm : Form
    {
        private static ChatServer server;
        RemoteChatClient rmc;
        private static String _nick;
        private static bool isConnected;
        void registerMe(String nick, String _port)
        {
            try
            {
                _nick = nick;
                int port = Int32.Parse(_port);

                TcpChannel channel = new TcpChannel(port);
                ChannelServices.RegisterChannel(channel, false);

                server = (ChatServer)Activator.GetObject(
                   typeof(ChatServer),
                   "tcp://localhost:8086/ChatServer"
               );


                ChatClient obj = (ChatClient)Activator.GetObject(
                    typeof(ChatClient),
                    "tcp://localhost:8086/ChatClient");

                //pass the object here, so we keep a reference that link us to the UI
                rmc = new RemoteChatClient(this);
                String clientServiceName = "ChatClient";

                RemotingServices.Marshal(
                    rmc,
                    clientServiceName,
                    typeof(RemoteChatClient)
                );

                if (server != null)
                {
                    server.register(nick, "tcp://localhost:" + port + "/" + clientServiceName);
                    isConnected = true;
                }


            }
            catch (SocketException)
            {
                System.Windows.Forms.MessageBox.Show("Could not locate server");
            }
            catch (FormatException e)
            {
                System.Windows.Forms.MessageBox.Show("Invalid format port");
            }
            catch (RemotingException e)
            {
                System.Console.WriteLine(e);
            }
        }

        public void updateChat(String nick, String msg)
        {
            msgs.Text += nick + ": " + msg + "\n";
        }

        public ChatClientForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void connect_Click(object sender, EventArgs e)
        {
            String nick = name.Text;
            String _port = port.Text;
            if (!nick.Equals("") && !_port.Equals(""))
            {
                registerMe(nick, _port);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Fill in all the fields");
            }
            
        }

        private void send_Click(object sender, EventArgs e)
        {
            if (!isConnected) {
                System.Windows.Forms.MessageBox.Show("You must connect first!");
            }
            else if (msg.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Enter a message!");
            }
            else
            {
                server.sendMessage(_nick, msg.Text);
            }
        }

    }


    class RemoteChatClient : MarshalByRefObject, ChatClient
    {
        private ChatClientForm form;

        private List<String> muters;

        public RemoteChatClient(ChatClientForm form)
        {
            this.form = form;
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
            this.form.Invoke(new UIDel(form.updateChat), new object[] { name, msg });
        }
    }
}
