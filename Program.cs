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


using backTrading;
class Program
{
    static void Main(string[] args)
    {
        var dataStream = new DataStream("wss://data.tradingview.com/socket.io/websocket");
        dataStream.Connect();

        Console.ReadKey();
    }
}


//alpaca real time data 


// namespace backTrading;
// using System;
// using Alpaca.Markets;
// using System.Threading.Tasks;

// internal sealed class Program
// {
//     private const String API_KEY = "PKXDVBHQ4XQ1GWK8PLZE";
//
//     private const String API_SECRET = "W3f9YbbdauysqDImTTdkUOyhY4VX4jDHW8Ofp07n";

// real time 1min bars

    // public static async Task Main()
    // {
    //     var client = Environments.Paper.GetAlpacaDataStreamingClient(new SecretKey(API_KEY, API_SECRET));
    //
    //     await client.ConnectAndAuthenticateAsync();
    //
    //     String symbol = "TSLA";
    //
    //     var barSubscription = client.GetMinuteBarSubscription(symbol);
    //     barSubscription.Received += (bar) => { Console.WriteLine(bar); };
    //
    //     await client.SubscribeAsync(barSubscription);
    //
    //     // Add a delay or use a different mechanism to keep the program running
    //     await Task.Delay(Timeout.Infinite);
    // }

//}}

//alpaca historical data working
// using Alpaca.Markets;
// namespace backTrading;
//
// internal sealed class Program
// {
//     private const String API_KEY = "PKXDVBHQ4XQ1GWK8PLZE";
//
//     private const String API_SECRET = "W3f9YbbdauysqDImTTdkUOyhY4VX4jDHW8Ofp07n";
//
// //
//     public static async Task Main()
//     {
//         var client = Environments.Paper.GetAlpacaDataClient(new SecretKey(API_KEY, API_SECRET));
//
//         string symbol = "TSLA"; // Use "TSLA" for Tesla stock
//         DateTime start = DateTime.Today.AddDays(-4); // Yesterday
//         DateTime end = DateTime.Today; // Today
//         var timeframe = BarTimeFrame.Minute; // Denotes 1-minute bars
//
//         var bars = await client.ListHistoricalBarsAsync(
//             new HistoricalBarsRequest(symbol, start, end, timeframe));
//
//         Console.WriteLine(bars);
//     }
// }





//final alpaca
// alpaca real time data

// alpaca real time data 
// namespace backTrading;
// using System;
// using Alpaca.Markets;
// using System.Threading.Tasks;
// public class Program
// {
//     private const String API_KEY = "PKXDVBHQ4XQ1GWK8PLZE";
//     private const String API_SECRET = "W3f9YbbdauysqDImTTdkUOyhY4VX4jDHW8Ofp07n";
//     public static async Task Main()
//     {
//         var client = Environments.Paper.GetAlpacaDataStreamingClient(new SecretKey(API_KEY, API_SECRET));
//
//         await client.ConnectAndAuthenticateAsync();
//
//         String symbol = "TSLA";
//
//         var tradeSubscriber = new TradeSubscriber(client, symbol);
//         // var quoteSubscriber = new QuoteSubscriber(client, symbol);
//
//         await tradeSubscriber.Subscribe();
//         // await quoteSubscriber.Subscribe();
//
//         // Add a delay or use a different mechanism to keep the program running
//         await Task.Delay(Timeout.Infinite);
//     }
// }
//     
//     
//
