namespace backTrading;

public class Parameters
{
    public const string Wss = "wss://data.tradingview.com/socket.io/websocket";
    public const string ReturnMessagePattern = @"~m~\d+~m~~h~\d+";
    public const string SavedFileLocation = "../../../websocket_messages.txt";

    public static readonly string[] Messages = 
    {
        "~m~52~m~{\"m\":\"quote_create_session\",\"p\":[\"qs_5uWIRFAui1UJ\"]}",
        "~m~131~m~{\"m\":\"quote_add_symbols\",\"p\":[\"qs_5uWIRFAui1UJ\",\"={\\\"adjustment\\\":\\\"splits\\\",\\\"session\\\":\\\"regular\\\",\\\"symbol\\\":\\\"NASDAQ:TSLA\\\"}\"]}",
        "~m~132~m~{\"m\":\"quote_fast_symbols\",\"p\":[\"qs_5uWIRFAui1UJ\",\"={\\\"adjustment\\\":\\\"splits\\\",\\\"session\\\":\\\"regular\\\",\\\"symbol\\\":\\\"NASDAQ:TSLA\\\"}\"]}",
        
        
        
        
        // "~m~52~m~{\"m\":\"quote_create_session\",\"p\":[\"qs_sL59AhMR2rv8\"]}",
        // "~m~432~m~{\"m\":\"quote_set_fields\",\"p\":[\"qs_sL59AhMR2rv8\",\"base-currency-logoid\",\"ch\",\"chp\",\"currency-logoid\",\"currency_code\",\"currency_id\",\"base_currency_id\",\"current_session\",\"description\",\"exchange\",\"format\",\"fractional\",\"is_tradable\",\"language\",\"local_description\",\"listed_exchange\",\"logoid\",\"lp\",\"lp_time\",\"minmov\",\"minmove2\",\"original_name\",\"pricescale\",\"pro_name\",\"short_name\",\"type\",\"typespecs\",\"update_mode\",\"volume\",\"value_unit_id\"]}",
        // "~m~63~m~{\"m\":\"quote_add_symbols\",\"p\":[\"qs_sL59AhMR2rv8\",\"NASDAQ:TSLA\"]}",
        // "~m~64~m~{\"m\":\"quote_fast_symbols\",\"p\":[\"qs_sL59AhMR2rv8\",\"NASDAQ:TSLA\"]}"
    };
}