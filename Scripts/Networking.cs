using Godot;
using System;

public class Networking : Node
{
    PacketPeerUDP client = new PacketPeerUDP();

    bool connected = false;

    public override void _Ready()
    {
        client.ConnectToHost("127.0.0.1", 8080);
    }

    public override void _Process(float delta)
    {
        if(!connected)
        {
            client.PutPacket("The answer is... 42".ToUTF8());
        }

        if(client.GetAvailablePacketCount() > 0)
        {
            GD.Print("Connected: " + client.GetPacket().GetStringFromUTF8());
            connected = true;
        }
    }
}
