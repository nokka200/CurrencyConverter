using System.Text.Json.Serialization;

namespace CurrencyConverter.ConvertEngine
{
    /// <summary>
    /// Represents a class for currency converting
    /// </summary>
    public class Currencies
    {
        [JsonPropertyName("base")]
        public string? Base { get; set; }

        [JsonPropertyName("rates")]
        public Dictionary<string, double>? Rates { get; set; }

        /// <summary>
        /// Tries to convert from USD to x.
        /// </summary>
        /// <param name="currencyCode">ISO 4217 standard currency code</param>
        /// <param name="amount">amount to convert</param>
        /// <returns>value in converted currency rounded</returns>
        public double ConvertUSDTo(string currencyCode, double amount)
        {
            double total;

            if(Rates == null)
            {
                return -1;
            }
            
            Rates.TryGetValue(currencyCode, out double value);
            total = amount * value;

            return Math.Round(total, 2);
            
        }

        /// <summary>
        /// Tries to convert to USD from x.
        /// </summary>
        /// <param name="currencyCode">ISO 4217 standard currency code</param>
        /// <param name="amount">amount to convert</param>
        /// <returns>value in converted currency rounded</returns>
        public double ConvertToUSD(string currencyCode, double amount)
        {
            double total;

            if(Rates != null)
            {
                Rates.TryGetValue(currencyCode, out double value);
                total = amount / value;

                return Math.Round(total, 2);
            }
            return -1;
        }

        /// <summary>
        /// Converts X currency to EUR. First it will convert it to USD and then USD to EUR
        /// </summary>
        /// <param name="amount">amount to convert</param>
        /// <returns>value in euros, rounded</returns>
        public double ConvertXtoEUR(string currencyCode, double amount)
        {
            double total;

            // first convert's x currency to dollar
            total = ConvertToUSD(currencyCode, amount);

            // second convert dollars to eur
            total = ConvertUSDTo("EUR", total);

            return total;
        }
    }
}
