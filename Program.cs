using CurrencyConverter.Testers;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MethodTester.TestConnection();

            //MethodTester.TestReadJson();

            //MethodTester.TestJsonDeserialize();

            //MethodTester.TestConvertUSDTo("EUR", 125);

            //MethodTester.TestConvertToUSD("EUR", 118.76);

            MethodTester.TestMarvelConvert();
        }
    }
}