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
                RequestInput();

                var input = Console.ReadLine();

                while (!converter.InputStringNumbersAreValid(input))
                {
                    WriteInvalidInput();
                    RequestInput();
                    input = Console.ReadLine();
                }

                WriteOutput(converter.ConvertNumbersToString(input));
                repeat = RequestRepeat();
            }
        }

        private static void RequestInput()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter the sum:");
            Console.ForegroundColor = ConsoleColor.White;
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

        private static void WriteInvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input.");
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