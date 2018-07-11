using NUnit.Framework;
using System;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase(0,"")]
        [TestCase(0, " ")]
        [TestCase(0, null)]
        public void Add_GivenEmptyString_ShouldReturn0(int expected , string input) {
            //Arrange
            var sut = new StringCalculator();
            
            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase(1 ,"1")]
        [TestCase(21, "21")]
        public void Add_GivenStringHavingOneNumber_ShouldReturnTheNumberItself(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, "1,4")]
        public void Add_GivenStringHavingTwoNumbers_ShouldReturnTheSum(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, "1,1,1,1,1")]
        [TestCase(100, "10,20,30,20,20")]
        public void Add_GivenStringHavingUnknownAmountOfNumbers_ShouldReturnTheSum(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "1\n2,3")]
        public void Add_GivenStringHavingNewLineDelimiter_ShouldReturnTheSum(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "//;\n1;2")]
        [TestCase(3, "//*\n1*2")]
        public void Add_GivenStringHavingCustomDelimiter_ShouldReturnTheSum(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("negatives not allowed : -1", "-1")]
        [TestCase("negatives not allowed : -1,-2,-3,-7", "-1,-2,-3,4,5,6,-7")]
        public void Add_GivenStringHavingNegativeNumbers_ShouldReturnNegativesNotAllowed(string expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(()=>sut.Add(input));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase(2, "1001,2")]
        [TestCase(1002, "1000,2")]
        public void Add_GivenStringHavingNumbersMoreThan1000_ShouldReturnTheSumOfThoseLessThan1001(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "//[***]\n1***2***3")]
        public void Add_GivenStringHavingDelimitersOfAnyLength_ShouldReturnTheSum(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "//[*][%]\n1*2%3")]
        [TestCase(10, "//[***][%][#@@@]\n1***2%3#@@@1#@@@3")]
        public void Add_GivenStringHavingMultipleCharDelimitersOfAnyLength_ShouldReturnTheSum(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
