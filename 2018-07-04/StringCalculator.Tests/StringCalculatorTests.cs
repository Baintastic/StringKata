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
        public void Add_GivenNoNUmber_ShouldReturn0(int expected ,string numbers) {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase(1, "1")]
        [TestCase(53, "53")]
        [TestCase(888, "888")]
        public void Add_GivenOneNUmber_ShouldReturnTheNumberItself(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "1,2")]
        [TestCase(30, "10,20")]
        [TestCase(300, "100,200")]
        public void Add_GivenTwoNUmbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(302, "100,200,1,1")]
        [TestCase(11, "1,2,2,2,2,2")]
        [TestCase(5, "1,2,2")]
        public void Add_GivenUnknownAmountOfNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "1\n2,3")]
        [TestCase(8, "1\n2\n3,2")]
        [TestCase(15, "10\n2,3\n")]
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
        [TestCase(6, "//@\n1#2#3")]
        [TestCase(10, "//#\n1@2@3@4")]
        public void Add_GivenNumbersWithDifferentDelimeters_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("negatives not allowed : -2 ", "//#\n1@-2")]
        [TestCase("negatives not allowed : -1 -2 ", "//;\n-1;-2")]
        [TestCase("negatives not allowed : -1 -2 ", "//@\n-1#-2#3")]
        public void Add_GivenNumbersWithNegatvies_ShouldReturnNegativesNotAllowed(string expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(numbers));
            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase(2, "//#\n1001@2")]
        [TestCase(1002, "//#\n1000@2")]
        [TestCase(1001, "//#\n999@2")]
        public void Add_GivenNumbersMoreThan1000_ShouldReturnSumOfThoseLessThan1001(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "//[***]\n1***2***3")]
        [TestCase(7, "//[@@]\n2@@2@@3")]
        [TestCase(3, "//[$$$$]\n1$$$$2")]
        public void Add_GivenNumbersWithDelimetersOfAnyLength_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "//[*][%]\n1*2%3")]
        [TestCase(8, "//[*][%][##]\n1*2%3##2")]
        [TestCase(6, "//[*][%%%]\n1*2%%%3")]
        public void Add_GivenNumbersWithMultipleDelimetersOfAnyLength_ShouldReturnTheSum(int expected, string numbers)
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
