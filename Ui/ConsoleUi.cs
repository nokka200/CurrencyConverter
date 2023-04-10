using CurrencyConverter.ConvertEngine;
using CurrencyConverter.Http;
using CurrencyConverter.Payload;
using System.Diagnostics;
using System.Formats.Asn1;

namespace CurrencyConverter.Ui
{
    /// <summary>
    /// This class represents the console ui methods, has sync and async methods
    /// </summary>
    public class ConsoleUi
    {
        // const
        const string KEY = "CURRENCY_KEY";
        const string uri = "https://openexchangerates.org/api/latest.json?app_id=";

        // fields
        readonly string[] startCommand;
        readonly string key = Environment.GetEnvironmentVariable(KEY)!;
        readonly ApiConnector apiObj;

        public ConsoleUi(string[] startCommand)
        {
            this.startCommand = startCommand;
            apiObj = new(uri, key);
        }

        /// <summary>
        /// Calls different functions based on the users input
        /// </summary>
        public void GetExchange()
        {
            string re = apiObj.TestConnection();
            if (re == null)
            {
                Console.WriteLine("Error in connection:" + re);
                return;
                
            }
            switch (startCommand[0])
            {
                case "1":
                    MarvelSnapMaxGold();
                    break;

                default:
                    Console.WriteLine("Wrong choice:" + startCommand[0]);
                    break;
            }

        }

        /// <summary>
        /// Async calls different functions based on the users input
        /// </summary>
        /// <returns></returns>
        public async Task GetExchangeAsync()
        {
            string re = apiObj.TestConnection();
            if (re == null)
            {
                Console.WriteLine("Error in connection:" + re);
                return;

            }
            switch (startCommand[0])
            {
                case "1":
                    await MarvelSnapMaxGoldAsync();
                    break;

                default:
                    Console.WriteLine("Wrong choice:" + startCommand[0]);
                    break;
            }
            
        }

        private async Task MarvelSnapMaxGoldAsync()
        {
            double result;

            Currencies currencyObj;
            JsonParser jsonReader = new();

            var response = await apiObj.GetResponseAsync();

            currencyObj = jsonReader.DeserializeCurrencyFromStr(response);

            result = currencyObj.ConvertXtoEUR("SGD", 139.99);
            Console.WriteLine($"Result /SGD -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("THB", 3600);
            Console.WriteLine($"Result /THB -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("MYR", 479.9);
            Console.WriteLine($"Result /MYR -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("PHP", 4990);
            Console.WriteLine($"Result /PHP -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("IDR", 1500000);
            Console.WriteLine($"Result /IDR -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("ARS", 15500);
            Console.WriteLine($"Result /ARS -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("EGP", 2400);
            Console.WriteLine($"Result /EGP -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("MXN", 1990);
            Console.WriteLine($"Result /MXN -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("BRL", 529.9);
            Console.WriteLine($"Result /BRL -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("KRW", 149000);
            Console.WriteLine($"Result /KRW -> EUR: \t{result}");
        }

        private void MarvelSnapMaxGold()
        {
            double result;

            Currencies currencyObj;
            JsonParser jsonReader = new();

            var response = apiObj.GetResponse();

            currencyObj = jsonReader.DeserializeCurrencyFromStr(response);

            result = currencyObj.ConvertXtoEUR("SGD", 139.99);
            Console.WriteLine($"Result /SGD -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("THB", 3600);
            Console.WriteLine($"Result /THB -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("MYR", 479.9);
            Console.WriteLine($"Result /MYR -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("PHP", 4990);
            Console.WriteLine($"Result /PHP -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("IDR", 1500000);
            Console.WriteLine($"Result /IDR -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("ARS", 15500);
            Console.WriteLine($"Result /ARS -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("EGP", 2400);
            Console.WriteLine($"Result /EGP -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("MXN", 1990);
            Console.WriteLine($"Result /MXN -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("BRL", 529.9);
            Console.WriteLine($"Result /BRL -> EUR: \t{result}");

            result = currencyObj.ConvertXtoEUR("KRW", 149000);
            Console.WriteLine($"Result /KRW -> EUR: \t{result}");
        }
    }
}