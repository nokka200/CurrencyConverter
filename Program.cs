using CurrencyConverter.Http;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApiConnector apiObj = new("https://openexchangerates.org/api/latest.json?app_id=e4b4cecf9f2342299a29d8c2fb5786c7");
            apiObj.TestConnection();
        }
    }
}