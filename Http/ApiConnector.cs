

namespace CurrencyConverter.Http
{
    /// <summary>
    /// Handels all the connections to the API
    /// </summary>
    public class ApiConnector
    {
        // properties
        public Uri Uriobj { get; private set; }

        // fields
        readonly HttpClient clientObj;
        readonly string key;

        public ApiConnector(string uri, string key)
        {
            Uriobj = new(uri);
            this.key = key;
            clientObj = new HttpClient();
        }

        /// <summary>
        /// Check if the connection works to the api, prints the result
        /// </summary>
        public string TestConnection()
        {
            string responseBody;
            responseBody = clientObj.GetStringAsync(Uriobj + this.key).Result;
            return responseBody;
        }

        /// <summary>
        /// Sends a get request to the uri + key address
        /// </summary>
        /// <returns>response in string</returns>
        public string GetResponse()
        {
            string responseBody;
            responseBody = clientObj.GetStringAsync(Uriobj + this.key).Result;

            return responseBody;
        }

        /// <summary>
        /// Writes the response to a json file
        /// </summary>
        public void WriteToFile()
        {
            string result;
            
            string fileName = new("Currency.json");

            result = GetResponse();

            File.WriteAllText(fileName, result);
        }

    }
}
