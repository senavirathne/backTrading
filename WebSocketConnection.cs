namespace backTrading;

using System;
using System.Net.WebSockets;
using System.Threading;
using System.Text;
using System.IO;
using System.Threading.Tasks;

public class WebSocketConnection
{
    private ClientWebSocket _webSocket = null!;

    public async Task Connect(string uri)
    {
        _webSocket = new ClientWebSocket();

        try
        {
            await _webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
            Console.WriteLine("Websocket opened");
            await Send("text");

            using StreamWriter file = new StreamWriter("websocket_messages.txt", append: true);

            while (_webSocket.State == WebSocketState.Open)
            {
                string message = await Receive();
                await file.WriteLineAsync(message);
                await file.FlushAsync();
            }

            Console.WriteLine("File connection closed");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"WebSocket connection closed: {ex}");
        }
    }

    private async Task Send(string data)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(data);
        await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true,
            CancellationToken.None);
    }

    private async Task<string> Receive()
    {
        var buffer = new ArraySegment<byte>(new byte[8192]);
        var completeMessage = new StringBuilder();

        WebSocketReceiveResult result;
        do
        {
            result = await _webSocket.ReceiveAsync(buffer, CancellationToken.None);
            completeMessage.Append(Encoding.UTF8.GetString(buffer.Array, 0, result.Count));
        } while (!result.EndOfMessage);

        return completeMessage.ToString();
    }
}