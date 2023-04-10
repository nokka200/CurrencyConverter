﻿
using CurrencyConverter.Http;
using CurrencyConverter.Payload;
using CurrencyConverter.ConvertEngine;

namespace CurrencyConverter.Testers
{
    static public class MethodTester
    {
        // generic stuff
        const string JSON_FILE = "TestJson.json";
        const string KEY = "CURRENCY_KEY";

        // Http test fields
        readonly static string key = Environment.GetEnvironmentVariable(KEY)!;
        readonly static string uri = "https://openexchangerates.org/api/latest.json?app_id=";
        readonly static Uri uriObj = new("https://openexchangerates.org/api/latest.json?app_id=");

        // Payload test fields
        readonly static JsonParser jsonReader = new(JSON_FILE);

        // Currencies stuff
        static Currencies? currencyObj;

        /* RANDOM tests*/

        static public void TestDateTimeFormat()
        {
            DateTime dateObj = DateTime.Now;
            Console.WriteLine(dateObj.ToLocalTime());
        }

        /*ENV variable tests*/

        /// <summary>
        /// Gets the env variable and prints it
        /// </summary>
        static public void TestEnvVariableGet()
        {
            string? value;

            value = Environment.GetEnvironmentVariable("CURRENCY_KEY");
            Console.WriteLine($"Value: {value}");
        }

        /*URI object test*/

        /// <summary>
        /// Print the uri to console
        /// </summary>
        static public void TestUriObject()
        {
            Console.WriteLine(uriObj + key);
        }

        /*CONNECTION TESTS*/

        /// <summary>
        /// Test the connection to the api
        /// </summary>
        static public void TestConnection()
        {
            ApiConnector apiObj = new(uri, key);
            var re = apiObj.TestConnection();
            Console.WriteLine(re);
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
            currencyObj = jsonReader.DeserializeCurrencyFromFile();

            Console.WriteLine($"Base: {currencyObj.Base}");

            if(currencyObj.Rates != null)
                Console.WriteLine($"Rate: {currencyObj.Rates["EUR"]}");
        }

        /// <summary>
        /// Test connection and creating a currency object from it
        /// </summary>
        static public void TestConnectionAndConvert()
        {
            string response;
            double result;

            ApiConnector apiObj = new(uri, key);
            

            response = apiObj.GetResponse();
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

        static public void TestConnectionAndWriteToFile()
        {
            ApiConnector apiObj = new(uri, key);
            apiObj.WriteToFile();
        }

        /*CONVERT TESTS*/

        /// <summary>
        /// Test converting usd to x value
        /// </summary>
        /// <param name="valueToConvert"></param>
        static public void TestConvertUSDTo(string valueToConvert, double amount)
        {
            double result;

            currencyObj = jsonReader.DeserializeCurrencyFromFile();

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

            currencyObj = jsonReader.DeserializeCurrencyFromFile();

            result = currencyObj.ConvertToUSD(valueToConvert, amount);

            Console.WriteLine($"Result: {result}");
        }

        /// <summary>
        /// Test currencies used in Marvel snap To USD
        /// </summary>
        static public void TestMarvelConvertToUSD()
        {
            double result;

            currencyObj = jsonReader.DeserializeCurrencyFromFile();

            result = currencyObj.ConvertToUSD("SGD", 139.99);
            Console.WriteLine($"Result /SGD -> USD: \t{result}");

            result = currencyObj.ConvertToUSD("THB", 3600);
            Console.WriteLine($"Result /THB -> USD: \t{result}");

            result = currencyObj.ConvertToUSD("MYR", 479.9);
            Console.WriteLine($"Result /MYR -> USD: \t{result}");

            result = currencyObj.ConvertToUSD("PHP", 4990);
            Console.WriteLine($"Result /PHP -> USD: \t{result}");

            result = currencyObj.ConvertToUSD("IDR", 1500000);
            Console.WriteLine($"Result /IDR -> USD: \t{result}");

            result = currencyObj.ConvertToUSD("ARS", 15500);
            Console.WriteLine($"Result /ARS -> USD: \t{result}");

            result = currencyObj.ConvertToUSD("EGP", 2400);
            Console.WriteLine($"Result /EGP -> USD: \t{result}");

            result = currencyObj.ConvertToUSD("MXN", 1990);
            Console.WriteLine($"Result /MXN -> USD: \t{result}");

            result = currencyObj.ConvertToUSD("BRL", 529.9);
            Console.WriteLine($"Result /BRL -> USD: \t{result}");

            result = currencyObj.ConvertToUSD("KRW", 149000);
            Console.WriteLine($"Result /KRW -> USD: \t{result}");
        }

        /// <summary>
        /// Test currencies in marvel snap to euros
        /// </summary>
        static public void TestMarvelConvertToEUR()
        {
            //double result;

            //currencyObj = jsonReader.DeserializeCurrencyFromFile();

            string response;
            double result;

            ApiConnector apiObj = new(uri, key);
            response = apiObj.GetResponse();

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
