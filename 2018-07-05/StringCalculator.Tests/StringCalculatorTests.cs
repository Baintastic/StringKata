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
        public void Add_GivenNoNumber_ShouldReturn0(int expected, string numbers) {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase(1, "1")]
        [TestCase(15, "15")]
        [TestCase(30, "30")]
        public void Add_GivenOneNumber_ShouldReturnTheNumbersItself(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, "1,3")]
        [TestCase(5, "2,3")]
        [TestCase(13, "10,3")]
        public void Add_GivenTwoNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(15, "10,3,2")]
        [TestCase(61, "10,30,20,1")]
        [TestCase(17, "10,3,2,1,1")]
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
        [TestCase(7, "1\n2,3\n1")]
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
        [TestCase(3, "//*\n1*2")]
        [TestCase(6, "//#\n1#2#3")]
        public void Add_GivenNumbersWithMultipleDelimiters_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("negatives not allowed : -1 ", "//#\n-1")]
        [TestCase("negatives not allowed : -1 -3 ", "//#\n-1#-3")]
        [TestCase("negatives not allowed : -1 -2 ", "//#\n-1#-2#3")]
        public void Add_GivenNumbersWithMultipleDelimiters_ShouldReturnNegativesNotAllowed(string expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(()=> sut.Add(numbers));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase(3, "//#\n1001#3")]
        [TestCase(1003, "//#\n1000#3")]
        [TestCase(1002, "//#\n999#3#1003")]
        public void Add_GivenSomeNumbersMoreThan1000_ShouldReturnTheSumOfThoseLessThan1001(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "//[***]\n1***2***3")]
        [TestCase(3, "//[$$]\n1$$2")]
        [TestCase(10, "//[@@@@]\n1@@@@2@@@@3@@@@4")]
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
        [TestCase(1010, "//[*][%][@@]\n1*2%3@@1000@@4")]
        [TestCase(100, "//[*][%][@@][###]\n1*2%3@@40###54")]
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
