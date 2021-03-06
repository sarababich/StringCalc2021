using System;
using Xunit;

namespace StringCalc2021
{
    public class StringCalc_Add
    {
        private StringCalc2021_calculator = new();

        [Fact]
        public void Returns0GivenEmptyString()
        {
            var result = _calculator.Add("");

            Assert.Equal(0, result);
        }

        [Fact]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void ReturnsNumberGivenStringWithOneNumber(
            string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        [InlineData("1,2", 3)]
        [InlineData("2,3", 5)]
        public void ReturnsSumGivenStringWithTwoCommaSeparatedNumbers(
            string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        [InlineData("1,2,3", 6)]
        [InlineData("2,3,4", 9)]
        public void ReturnsSumGivenStringWithThreeCommaSeparatedNumbers(
            string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2\n3", 6)]
        [InlineData("1,2\n3", 6)]
        [InlineData("1,2,3", 6)]
        public void ReturnsSumGivenStringWithThreeCommaOrNewLineSeparatedNumbers(
            string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        [InlineData("//;\n1;2;3", 6)]
        public void ReturnsSumGivenStringWithCustomDelimiter(
            string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        [InlineData("-1,2", "Negatives not allowed: -1")]
        [InlineData("-1,-2", "Negatives not allowed: -1,-2")]
        public void ThrowsGivenNegativeInputs(
            string numbers, string expectedMessage)
        {
            Action action = () => _calculator.Add(numbers);

            var ex = Assert.Throws<Exception>(action);

            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        [InlineData("1,2,3000", 3)]
        [InlineData("1001,2", 2)]
        [InlineData("1000,2", 1002)]
        public void ReturnsSumGivenStringIgnoringValuesOver1000(
            string numbers, int expectedResult)
        {
            var result = _calculator.Add(numbers);

            Assert.Equal(expectedResult, result);
        }


    }
}
