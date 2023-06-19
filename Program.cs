// using System;
// using Alpaca.Markets;
// using System.Threading.Tasks;
//
// namespace AlpacaExample
// {
//     internal sealed class ExampleProgram
//     {
//         
//         private const string KeyId = "PKUGDCB6ZA232NMMO3BT";
//
//         private const string SecretKey = "iIfSOHeVNdyUMyLzcUiA4OUsvR6r798AK4MITKyR";
//
//         public static async Task Main()
//         {
//             var client = Environments.Paper
//                 .GetAlpacaTradingClient(new SecretKey(KeyId, SecretKey));
//
//             var account = await client.GetAccountAsync();
//             // Set order parameters
//             const string symbol = "BTC/USD";
//             const int quantity = 1;
//
//             // Placing buy order
//             var buyOrder = await client.PostOrderAsync(OrderSide.Buy.Market(symbol, quantity));
//             Console.WriteLine(buyOrder);
//         }
//     }
// }

// namespace backTrading;
//
// class Program
// {
//     static async Task Main(string[] args)
//     {
//         var webSocketConnection = new WebSocketConnection();
//         await webSocketConnection.Connect("wss://data.tradingview.com/socket.io/websocket");
//     }
// }
// working 

using System;
using WebSocket4Net;
using System.IO;
using ErrorEventArgs = SuperSocket.ClientEngine.ErrorEventArgs;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        WebSocket websocket = new WebSocket("wss://data.tradingview.com/socket.io/websocket");

        websocket.Opened += new EventHandler(websocket_Opened!);
        websocket.Error += new EventHandler<ErrorEventArgs>(websocket_Error!);
        websocket.Closed += new EventHandler(websocket_Closed!);
        websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived!);

        websocket.Open();

        Console.ReadKey();
    }

    private static void websocket_Opened(object? sender, EventArgs e)
    {
        Console.WriteLine("Websocket opened");
        var ws = sender as WebSocket;

        string[] messages =
        {
            "~m~52~m~{\"m\":\"quote_create_session\",\"p\":[\"qs_sL59AhMR2rv8\"]}",
            "~m~432~m~{\"m\":\"quote_set_fields\",\"p\":[\"qs_sL59AhMR2rv8\",\"base-currency-logoid\",\"ch\",\"chp\",\"currency-logoid\",\"currency_code\",\"currency_id\",\"base_currency_id\",\"current_session\",\"description\",\"exchange\",\"format\",\"fractional\",\"is_tradable\",\"language\",\"local_description\",\"listed_exchange\",\"logoid\",\"lp\",\"lp_time\",\"minmov\",\"minmove2\",\"original_name\",\"pricescale\",\"pro_name\",\"short_name\",\"type\",\"typespecs\",\"update_mode\",\"volume\",\"value_unit_id\"]}",
            "~m~63~m~{\"m\":\"quote_add_symbols\",\"p\":[\"qs_sL59AhMR2rv8\",\"NASDAQ:TSLA\"]}",
            // "~m~64~m~{\"m\":\"quote_fast_symbols\",\"p\":[\"qs_sL59AhMR2rv8\",\"NASDAQ:TSLA\"]}"
        };

        foreach (var message in messages)
        {
            ws.Send(message);
        }
    }

    private static void websocket_Error(object? sender, ErrorEventArgs e)
    {
        Console.WriteLine("Process terminated: " + e.Exception.Message);
    }

    private static void websocket_Closed(object? sender, EventArgs e)
    {
        Console.WriteLine("Process closed");
    }

    private static void websocket_MessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        using (StreamWriter file = new StreamWriter("../../../websocket_messages.txt", true))
        {
            file.WriteLine(e.Message);
        }

        if (!IsMatchingFormat(e.Message)) return;
        var ws = sender as WebSocket;
        Console.WriteLine(e.Message);
        ws.Send(e.Message); // Send the message back to the WebSocket server
    }

    private static bool IsMatchingFormat(string message)
    {
        string pattern = @"~m~\d+~m~~h~\d+";
        return Regex.IsMatch(message, pattern);
    }
}
// working