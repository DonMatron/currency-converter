namespace ConverterTest
{
    public class ConverterTests
    {
        [Theory]
        [InlineData("0", "zero dollars")]
        [InlineData("1", "one dollar")]
        [InlineData("10", "ten dollars")]
        [InlineData("11", "eleven dollars")]
        [InlineData("102", "one hundred two dollars")]
        [InlineData("120", "one hundred twenty dollars")]
        [InlineData("25,1", "twenty-five dollars and ten cents")]
        [InlineData("0,01", "zero dollars and one cent")]
        [InlineData("45 100", "forty-five thousand one hundred dollars")]
        [InlineData("45 000", "forty-five thousand dollars")]
        [InlineData("70 000", "seventy thousand dollars")]
        [InlineData("45 000 000", "forty-five million dollars")]
        [InlineData("45 000 002", "forty-five million two dollars")]
        [InlineData("45 020 002", "forty-five million twenty thousand two dollars")]
        [InlineData("999 999 999,99", "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents")]
        public void Converter_Convert_ReturnsExpectedResult(string input, string expected)
        {
            Converter.Converter converter = new Converter.Converter();

            var result = converter.ConvertNumbersToString(input).Currency;

            Assert.Equal(expected, result);
        }
    }
}