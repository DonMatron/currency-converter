using Converter.Models;
using System.IO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Converter
{
    public class Converter
    {
        private ConverterWordsModel? converterWords = JsonSerializer.Deserialize<ConverterWordsModel>(File.ReadAllText("Words.json"));

        public ConversionResult ConvertNumbersToString(string? numbers)
        {
            var result = new ConversionResult();

            if (string.IsNullOrEmpty(numbers))
            {
                result.ErrorMessage = "Input is empty.";
                return result;
            }

            foreach (char c in numbers)
            {
                if ((c < '0' || c > '9') && (c != ' ' && c != ','))
                {
                    result.ErrorMessage = "Input contains unallowed symbols.";
                    return result;
                }
            }

            if (numbers.Contains(',') && numbers.Split(',').Length > 2)
            {
                result.ErrorMessage = "Input must not contain more than one comma.";
                return result;
            }

            (int dollars, int cents) dollarsAndCents = DivideInputStringNumbers(numbers);

            if (dollarsAndCents.cents > 99)
            {
                result.ErrorMessage = "Cents should not be more than 99.";
                return result;
            }
            if (dollarsAndCents.dollars > 999999999)
            {
                result.ErrorMessage = "Dollars should not be more than 999.999.999.";
                return result;
            }


            var dollars = ConvertNumberToWords(dollarsAndCents.dollars);
            var cents = ConvertNumberToWords(dollarsAndCents.cents);

            result.Currency = CombineWords(dollars, cents);

            return result;
        }

        private (int dollars, int cents) DivideInputStringNumbers(string numbers)
        {
            var parts = numbers.Split(',');

            string stringDollars = parts.Length > 0 ? parts[0] : numbers;
            string stringCents = parts.Length > 1 ? parts[1] : "";

            var dollars = ConvertStringNumberToInt(stringDollars);
            var cents = ConvertStringNumberToInt(stringCents);

            return (dollars, cents);
        }

        private int ConvertStringNumberToInt(string number)
        {
            if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number))
            {
                return 0;
            }

            string cleanedNumberString = string.Concat(number.Where(c => !char.IsWhiteSpace(c)));

            return int.Parse(cleanedNumberString);
        }

        private string CombineWords(string dollars, string cents)
        {
            return dollars + "dollars and " + cents + "cents";
        }

        private string ConvertNumberToWords(int input)
        {
            if (converterWords == null)
            {
                throw new FileNotFoundException(" Words file was not found.");
            }

            var lastThreeDigits = input % 1000;

            var resultString = GetWordsFromThreeDigits(lastThreeDigits);

            for (int i = 0; input - input % 1000 > 0; i++)
            {
                input /= 1000;

                lastThreeDigits = input % 1000;

                var resultStringPart = GetWordsFromThreeDigits(lastThreeDigits);

                resultString = resultStringPart + converterWords.Powers[i] + " " + resultString;
            }

            return resultString;
        }

        private string GetWordsFromThreeDigits(int input)
        {
            //return input.ToString();

            if (input < 0 || input > 999)
            {
                throw new ArgumentException("Input integer should not be lower than 0 and greater than 999.");
            }

            string result = "";

            //hundreds
            if (input / 100 > 0)
            {
                result += converterWords.Digits[input / 100] + " " + converterWords.Powers[-1] + " ";
            }

            //below 19
            if (input % 100 < 19)
            {
                result += converterWords.Digits[input % 100] + " ";
                return result;
            }

            // from 20 to 99
            var tens = (input / 10) % 10;
            var ones = input % 10;

            result += converterWords.Digits[((input / 10) % 10)*10] + "-" + converterWords.Digits[input % 10] + " ";

            return result;
        }
    }
}