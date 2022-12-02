using System.Text.Json;
using System.Text.Json.Nodes;

namespace CurrencyConverter.Payload
{
    public class JsonParser
    {
        string currentPath = Directory.GetCurrentDirectory();
        string fileName;

        public JsonParser(string fileName)
        {
            this.fileName= fileName;
            currentPath += "/" + this.fileName;
        }

        public void ReadFile()
        {
            File.ReadAllLines(currentPath);
            
        }
    }

}
