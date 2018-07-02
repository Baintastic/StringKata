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
        [TestCase(0, " ")]
        [TestCase(0, "")]
        [TestCase(0, null)]
        public void GivenNoNUmbers_ShouldReturn0(int expected, string numbers) {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase(4, "4")]
        [TestCase(5, "5")]
        [TestCase(10, "10")]
        public void GivenOneNumber_ShouldReturnNumberItself(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, "4,1")]
        [TestCase(10, "5,5")]
        [TestCase(13, "10,3")]
        public void GivenTwoNumbers_ShouldReturnSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, "4,1,5")]
        [TestCase(12, "5,5,1,1")]
        [TestCase(100, "10,10,50,30")]
        public void GivenUnknownAmountOfNumbers_ShouldReturnSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "1\n2,3")]
        [TestCase(7, "1\n2\n4")]
        [TestCase(1, "1\n")]
        public void GiveNumbersWithNewLines_ShouldReturnSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(8, "//#\n1#2#5")]
        [TestCase(4, "//*\n1*2*1")]
        [TestCase(3, "//;\n1;2")]
        public void GiveNumbersWithDifferentDelimters_ShouldReturnSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Negatives Not Allowed : -1 ", "-1")]
        [TestCase("Negatives Not Allowed : -2 -5 ", "//#\n1#-2#-5")]
        [TestCase("Negatives Not Allowed : -1 -2 ", "//;\n-1;-2")]
        public void GivenNegativeNumbers_ShouldReturnNegativesNotAllowed(string expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(numbers));

            //Assert

            Assert.That(actual.Message, Is.EqualTo(expected));         
        }

        [TestCase(1, "//;\n1;1001")]
        [TestCase(1002, "//;\n2;1000")]
        [TestCase(1000, "//;\n1;999")]
        public void GiveNumbersBiggerThan100_ShouldReturnSumOfthoseLessThan1001(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "//[***]\n1***2***3")]
        [TestCase(6, "//[*][%]\n1*2%3")]
        public void GiveNumbersWithDelimtersOfAnyLength_ShouldReturnSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
