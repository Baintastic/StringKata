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
        public void GivenNoNumber_ShouldReturn0(int expected , string numbers) {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase(21, "21")]
        [TestCase(4, "4")]
        [TestCase(56, "56")]
        public void GivenOneNumber_ShouldReturnTheNumberItself(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(57, "56,1")]
        [TestCase(20, "10,10")]
        [TestCase(3, "2,1")]
        public void GivenTwoNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(62, "56,1,5,")]
        public void GivenUnknownAmountOfNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "1\n2, 3")]
        [TestCase(6, "1\n2, 3\n")]
        [TestCase(6, "1\n2\n3")]
        public void GivenNewlinesBewtweenNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "//;\n1;2")]
        [TestCase(5, "//$\n1$2$2")]
        [TestCase(4, "//!\n1!2!1")]
        public void GivenDifferentDelimetersBewtweenNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Negatives not allowed", "-1")]
        public void GivenANegativeNumber_ShouldReturnNegativesNotAllowed(string expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual =  Assert.Throws<Exception>(()=>sut.Add(numbers));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }
    }
}
