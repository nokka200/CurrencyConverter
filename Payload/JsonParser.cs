using CurrencyConverter.ConvertEngine;
using System.Text.Json;

namespace CurrencyConverter.Payload
{
    public class JsonParser
    {
        // fields
        readonly string currentPath = Directory.GetCurrentDirectory();
        readonly string fileName;

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
        public Currencies CreateCurrencyConverterFromFile()
        {
            string jsonString;
            Currencies dollar;

            jsonString = File.ReadAllText(currentPath);

            dollar = JsonSerializer.Deserialize<Currencies>(jsonString)!;

            return dollar;
        }
        
    }

}
