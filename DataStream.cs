namespace backTrading;

using System;
using WebSocket4Net;
using System.IO;
using System.Text.RegularExpressions;

public class DataStream
{
    private readonly WebSocket _websocket;

    public DataStream(string uri)
    {
        _websocket = new WebSocket(uri);
        _websocket.Opened += WebSocket_Opened;
        _websocket.Error += WebSocket_Error!;
        _websocket.Closed += WebSocket_Closed!;
        _websocket.MessageReceived += WebSocket_MessageReceived!;
    }

    public void Connect()
    {
        _websocket.Open();
    }

    private static void WebSocket_Opened(object? sender, EventArgs e)
    {
        
        Console.WriteLine("Websocket opened");
        var ws = sender as WebSocket;

       
        

        foreach (var message in Parameters.Messages)
        {
            ws!.Send(message);
        }
    }

    private void WebSocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
    {
        Console.WriteLine("Process terminated: " + e.Exception.Message);
    }

    private void WebSocket_Closed(object sender, EventArgs e)
    {
        Console.WriteLine("Process closed");
    }

    private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
    {
        using (StreamWriter file = new StreamWriter(Parameters.SavedFileLocation, true))
        {
            file.WriteLine(e.Message);
        }
        if (!IsMatchingFormat(e.Message)) return;
        var ws = sender as WebSocket;
        Console.WriteLine(e.Message);
        ws!.Send(e.Message); // Send the message back to the WebSocket server
    }
    private static bool IsMatchingFormat(string message)
    {
        string pattern = Parameters.ReturnMessagePattern;
        return Regex.IsMatch(message, pattern);
    }
}
