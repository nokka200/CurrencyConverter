

using System.Runtime.CompilerServices;

namespace CurrencyConverter
{
    public class ApiConnector
    {
        // properties
        public string Uri { get; set; }

        // fields
        readonly HttpClient clientObj;

        public ApiConnector(string uri)
        {
            Uri= uri;
            clientObj = new HttpClient();
        }

        public void TestConnection()
        {
            string responseBody = clientObj.GetStringAsync(Uri).Result;
            Console.WriteLine("Body");
            Console.WriteLine(responseBody);
        }


    }
}
