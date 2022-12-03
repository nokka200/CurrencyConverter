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
        /// Tries to convert from USD to x for y amount
        /// </summary>
        /// <param name="currencyCode">ISO 4217 standard currency code</param>
        /// <param name="amount">amount to convert</param>
        /// <returns>value in dollars</returns>
        public double ConvertTo(string currencyCode, double amount)
        {
            double value;
            double total;

            if(Rates != null)
            {
                Rates.TryGetValue(currencyCode, out value);
                total = amount * value;

                return total;
            }
            return -1;
        }

    }
}
