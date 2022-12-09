using CurrencyConverter.ConvertEngine;
using System.Text.Json;

namespace CurrencyConverter.Payload
{
    public class JsonParser
    {
        // fields
        readonly string currentPath = Directory.GetCurrentDirectory();
        readonly string fileName;

        /// <summary>
        /// Reads the file from the source of this exe
        /// </summary>
        /// <param name="fileName"></param>
        public JsonParser(string fileName)
        {
            this.fileName= fileName;
            currentPath += "/" + this.fileName;
        }

        /// <summary>
        /// Reads the file's content and prints it to console.
        /// </summary>
        public void ReadFile()
        {
            using StreamReader readerObj = new(currentPath);
            Console.WriteLine(readerObj.ReadToEnd());
        }

        /// <summary>
        /// Deserializes a json file, to a Currencies class.
        /// </summary>
        /// <returns>currency object</returns>
        public Currencies DeserializeCurrencyFromFile()
        {
            string jsonString;
            Currencies dollar;

            jsonString = File.ReadAllText(currentPath);

            dollar = JsonSerializer.Deserialize<Currencies>(jsonString)!;

            return dollar;
        }

        /// <summary>
        /// Serializes a json to a curency class
        /// </summary>
        /// <param name="toJson"></param>
        /// <returns></returns>
        public Currencies DeserializeCurrencyFromStr(string toJson)
        {
            Currencies dollar;

            dollar = JsonSerializer.Deserialize<Currencies>(toJson)!;

            return dollar!;
        }
        
    }

}
