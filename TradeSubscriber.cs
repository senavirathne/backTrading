using Alpaca.Markets;

namespace backTrading;

public class TradeSubscriber
{
    private IAlpacaDataStreamingClient _client;
    private string _symbol;
    private decimal _lastPrice;

    public TradeSubscriber(IAlpacaDataStreamingClient client, string symbol)
    {
        _client = client;
        _symbol = symbol;
        _lastPrice = decimal.MinValue;
    }

    public async Task Subscribe()
    {
        var tradeSubscription = _client.GetTradeSubscription(_symbol);
        tradeSubscription.Received += (trade) =>
        {
            if (trade.Price != _lastPrice)
            {
                Console.WriteLine($"Trade - Symbol: {trade.Symbol}, Price: {trade.Price}, Size: {trade.Size}, Timestamp: {trade.TimestampUtc}");
                _lastPrice = trade.Price;
            }
        };

        await _client.SubscribeAsync(tradeSubscription);
    }
}