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
        [TestCase(0,"")]
        [TestCase(0, " ")]
        [TestCase(0, null)]
        public void Add_GivenNoNumber_ShouldReturn0(int expected , string numbers){
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase(1, "1")]
        [TestCase(10, "10")]
        [TestCase(100, "100")]
        public void Add_GivenOneNumber_ShouldReturnTheNumberItself(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, "1,3")]
        [TestCase(40, "10,30")]
        [TestCase(132, "100,32")]
        public void Add_GivenTwoNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "1,2,3")]
        [TestCase(20, "1,2,3,4,10")]
        [TestCase(10, "1,,1,1,1,1,1,1,1,1,1")]
        public void Add_GivenAnUnknownAmountOfNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "1\n2,3")]
        [TestCase(6, "1\n2\n3")]
        [TestCase(10, "1\n2,3\n4")]
        public void Add_GivenNumbersWithNewLines_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "//;\n1;2")]
        [TestCase(3, "//#\n1#2")]
        [TestCase(3, "//@\n1@2")]
        public void Add_GivenNumbersWithDifferentDelimiters_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("negatives not allowed : -1 ", "//@\n-1")]
        [TestCase("negatives not allowed : -1 -2 ", "//@\n-1@-2")]
        [TestCase("negatives not allowed : -1 -3 ", "//@\n-1@2@-3")]
        public void Add_GivenNumbersWithNegatives_ShouldReturnNegativesNotAllowed(string expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = Assert.Throws<Exception>(()=> sut.Add(numbers));
            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase(1, "//@\n1@1001")]
        [TestCase(1015, "//@\n15@1000")]
        [TestCase(1001, "//@\n2@999")]
        public void Add_GivenNumbers_ShouldReturnTheSumOfThoseLessThan1001(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "//[***]\n1***2***3")]
        [TestCase(6, "//[@@]\n1@@2@@3")]
        [TestCase(6, "//[#####]\n1#####2#####3")]
        public void Add_GivenNumbersWithDelimitersOfAnyLength_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "//[*][%]\n1*2%3")]
        [TestCase(6, "//[**][%]\n1**2%3")]
        [TestCase(8, "//[*][%][@@@]\n1*2%3@@@2")]
        public void Add_GivenNumbersWithMultipleDelimitersOfAnyLength_ShouldReturnTheSum(int expected, string numbers)
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
