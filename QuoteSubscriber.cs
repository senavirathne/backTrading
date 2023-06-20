using Alpaca.Markets;

namespace backTrading;

public class QuoteSubscriber
{
    private IAlpacaDataStreamingClient _client;
    private string _symbol;
    private decimal _lastBidPrice;
    private decimal _lastAskPrice;

    public QuoteSubscriber(IAlpacaDataStreamingClient client, string symbol)
    {
        _client = client;
        _symbol = symbol;
        _lastBidPrice = decimal.MinValue;
        _lastAskPrice = decimal.MinValue;
    }

    public async Task Subscribe()
    {
        var quoteSubscription = _client.GetQuoteSubscription(_symbol);
        quoteSubscription.Received += (quote) =>
        {
            if (quote.BidPrice != _lastBidPrice || quote.AskPrice != _lastAskPrice)
            {
                Console.WriteLine($"Quote - Symbol: {quote.Symbol}, Bid Price: {quote.BidPrice}, Ask Price: {quote.AskPrice}, Bid Size: {quote.BidSize}, Ask Size: {quote.AskSize}, Timestamp: {quote.TimestampUtc}");
                _lastBidPrice = quote.BidPrice;
                _lastAskPrice = quote.AskPrice;
            }
        };

        await _client.SubscribeAsync(quoteSubscription);
    }
}