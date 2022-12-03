
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
        static string key = "e4b4cecf9f2342299a29d8c2fb5786c7";
        static string uri = "https://openexchangerates.org/api/latest.json?app_id=";

        // Payload test fields
        static JsonParser jsonReader = new(JSON_FILE);

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
            Currencies currencyObj;

            currencyObj = jsonReader.CreateCurrencyConverterFromFile();

            Console.WriteLine($"Base: {currencyObj.Base}");
            Console.WriteLine($"Rate: {currencyObj.Rates["EUR"]}");
        }
    }
}
