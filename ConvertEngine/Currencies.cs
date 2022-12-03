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

    }
}
