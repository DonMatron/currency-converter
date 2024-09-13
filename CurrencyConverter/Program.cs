namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Converter.Converter converter = new Converter.Converter();

            bool repeat = true;

            while (repeat)
            {
                var input = RequestInput();
                var conversionResult = converter.ConvertNumbersToString(input);

                while (conversionResult.ErrorMessage != null)
                {
                    WriteInvalidInput(conversionResult.ErrorMessage);

                    input = RequestInput();
                    conversionResult = converter.ConvertNumbersToString(input);
                }

                WriteOutput(conversionResult.Currency!);

                //repeat = RequestRepeat();
            }
        }

        private static string? RequestInput()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter the sum:");
            Console.ForegroundColor = ConsoleColor.White;

            return Console.ReadLine();
        }

        private static bool RequestRepeat()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Again? (type y)");
            Console.ForegroundColor = ConsoleColor.White;

            var response = Console.ReadLine();

            if (response == "y")
            {
                return true;
            }

            return false;
        }

        private static void WriteInvalidInput(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void WriteOutput(string output)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(output);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}