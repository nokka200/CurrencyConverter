
using CurrencyConverter.Http;
using CurrencyConverter.Payload;
using CurrencyConverter.ConvertEngine;

namespace CurrencyConverter.Testers
{
    static public class MethodTester
    {
        // generic stuff
        const string JSON_FILE = "TestJson.json";

        // Http test fields
        readonly static string key = "e4b4cecf9f2342299a29d8c2fb5786c7";
        readonly static string uri = "https://openexchangerates.org/api/latest.json?app_id=";

        // Payload test fields
        static JsonParser jsonReader = new(JSON_FILE);

        // Currencies stuff
        static Currencies? currencyObj;

        /// <summary>
        /// Test the connection to the api
        /// </summary>
        static public void TestConnection()
        {
            ApiConnector apiObj = new(uri, key);
            apiObj.TestConnection();
        }

        /// <summary>
        /// Test reading a .json file
        /// </summary>
        static public void TestReadJson()
        {
            jsonReader.ReadFile();
        }

        /// <summary>
        /// Test deseralizing .json and creating a currency object
        /// </summary>
        static public void TestJsonDeserialize()
        {
            currencyObj = jsonReader.CreateCurrencyConverterFromFile();

            Console.WriteLine($"Base: {currencyObj.Base}");

            if(currencyObj.Rates != null)
                Console.WriteLine($"Rate: {currencyObj.Rates["EUR"]}");
        }

        /// <summary>
        /// Test converting usd to x value
        /// </summary>
        /// <param name="valueToConvert"></param>
        static public void TestConvertUSDTo(string valueToConvert, double amount)
        {
            double result;

            currencyObj = jsonReader.CreateCurrencyConverterFromFile();

            result = currencyObj.ConvertUSDTo(valueToConvert, amount);

            Console.WriteLine($"Result: {result}");
        }

        /// <summary>
        /// Test converting x to usd.
        /// </summary>
        /// <param name="valueToConvert"></param>
        static public void TestConvertToUSD(string valueToConvert, double amount)
        {
            double result;

            currencyObj = jsonReader.CreateCurrencyConverterFromFile();

            result = currencyObj.ConvertToUSD(valueToConvert, amount);

            Console.WriteLine($"Result: {result}");
        }

        static public void TestMarvelConvert()
        {
            double result;

            currencyObj = jsonReader.CreateCurrencyConverterFromFile();

            result = currencyObj.ConvertToUSD("SGD", 139.99);
            Console.WriteLine($"Result /SGD: \t{result}");

            result = currencyObj.ConvertToUSD("THB", 3600);
            Console.WriteLine($"Result /THB: \t{result}");

            result = currencyObj.ConvertToUSD("MYR", 479.9);
            Console.WriteLine($"Result /MYR: \t{result}");

            result = currencyObj.ConvertToUSD("PHP", 4990);
            Console.WriteLine($"Result /PHP: \t{result}");

            result = currencyObj.ConvertToUSD("IDR", 1500000);
            Console.WriteLine($"Result /IDR: \t{result}");

            result = currencyObj.ConvertToUSD("ARS", 15500);
            Console.WriteLine($"Result /ARS: \t{result}");

            result = currencyObj.ConvertToUSD("EGP", 2400);
            Console.WriteLine($"Result /EGP: \t{result}");

            result = currencyObj.ConvertToUSD("MXN", 1990);
            Console.WriteLine($"Result /MXN: \t{result}");

            result = currencyObj.ConvertToUSD("BRL", 529.9);
            Console.WriteLine($"Result /BRL: \t{result}");

            result = currencyObj.ConvertToUSD("KRW", 149000);
            Console.WriteLine($"Result /KRW: \t{result}");
        }
    }
}
