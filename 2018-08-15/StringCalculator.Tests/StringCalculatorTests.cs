using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("", 0)]
        [TestCase(" ", 0)]
        [TestCase(null, 0)]
        public void Add_GivenEmptyOrNullString_ShouldReturn0(string input , int expected) {
            //Act
            var sut = new StringCalculator();
            //Arrange
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase("1", 1)]
        [TestCase("21", 21)]
        public void Add_GivenInputWithOneNumber_ShouldReturnTheNumberItself(string input, int expected)
        {
            //Act
            var sut = new StringCalculator();
            //Arrange
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("10,11", 21)]
        public void Add_GivenInputWithTwoNumbersSeperatedByAComma_ShouldReturnTheSum(string input, int expected)
        {
            //Act
            var sut = new StringCalculator();
            //Arrange
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2,2,2,1,1,1", 10)]
        public void Add_GivenInputWithUnknownAmountOfNumbersSeperatedByCommas_ShouldReturnTheSum(string input, int expected)
        {
            //Act
            var sut = new StringCalculator();
            //Arrange
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("1\n2,3\n4\n5", 15)]
        public void Add_GivenInputWithNewLineDelimeter_ShouldReturnTheSum(string input, int expected)
        {
            //Act
            var sut = new StringCalculator();
            //Arrange
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//@\n1@2", 3)]
        public void Add_GivenInputWithDifferentDelimeters_ShouldReturnTheSum(string input, int expected)
        {
            //Act
            var sut = new StringCalculator();
            //Arrange
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase("-1,2", "negatives not allowed : -1")]
        [TestCase("-1,-2,3,4,5,-12", "negatives not allowed : -1,-2,-12")]
        public void Add_GivenInputWithNegativeNumbers_ShouldReturnNegativesNotAllowed(string input, string expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("1001,3", 3)]
        [TestCase("1000,2", 1002)]
        public void Add_GivenInputWithNumbersMoreThan1000_ShouldReturnTheSumOfThoseLessThan1001(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[@@@@@]\n1@@@@@2@@@@@3", 6)]
        public void Add_GivenInputWithDelimetersOfAnyLength_ShouldReturnTheSum(string input, int expected)
        {
            //Act
            var sut = new StringCalculator();
            //Arrange
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[*][%]\n1*2%7", 10)]
        public void Add_GivenInputWithMultipleCharDelimiters_ShouldReturnTheSum(string input, int expected)
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
