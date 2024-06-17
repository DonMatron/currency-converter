namespace Converter
{
    public class Converter
    {
        public bool InputStringNumbersAreValid(string? numbers)
        {
            //not null or empty
            // accept only 0-9 commas and whitespaces

            throw new NotImplementedException();
        }

        //Perhaps make the method throwable and throw custom exception instead of validation method.
        //Validation then will be preformed in this method.
        public string ConvertNumbersToString(string numbers)
        {
            //move validation here (?)

            (int dollars, int cents) dollarsAndCents = DivideInputStringNumbers(numbers!);

            var dollars = ConvertNumberToWords(dollarsAndCents.dollars);
            var cents = ConvertNumberToWords(dollarsAndCents.cents);

            var result = CombineWords(dollars, cents);

            return result;
        }

        private (int dollars, int cents) DivideInputStringNumbers(string numbers)
        {
            //Divide numbers using comma as separator and put results in variables below

            string stringDollars = "";
            string stringCents = "";

            var dollars = ConvertStringNumberToInt(stringDollars);
            var cents = ConvertStringNumberToInt(stringCents);

            return (dollars, cents);
        }

        private int ConvertStringNumberToInt(string number)
        {
            //remove whitespaces and return int
            throw new NotImplementedException();
        }

        private string ConvertNumberToWords(int number)
        {
            //Super complex algorithm here (use paper note)
            throw new NotImplementedException();
        }

        private string CombineWords(string dollars, string cents)
        {
            //add "dollars" and "cents", finalize the output string
            throw new NotImplementedException();
        }
    }
}