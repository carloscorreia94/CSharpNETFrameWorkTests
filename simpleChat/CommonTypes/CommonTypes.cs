using System;
using System.Collections;

namespace SimpleChat
{
    public interface ChatServer
    {
        void register(String nick, String url);
        void sendMessage(String nick, String msg);
        void notifyBan(String nick, String other);
        bool ask(String user);
    }


    public interface ChatClient
    {
        void print(String name, String msg);
        void mute(String otherUser);
    }
	
}