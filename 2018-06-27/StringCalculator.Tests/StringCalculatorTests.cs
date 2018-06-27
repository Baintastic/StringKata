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
        [TestCase(0, "")]
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

        [TestCase(1, "1")]
        [TestCase(5, "5")]
        [TestCase(8, "8")]
        public void GivenOneNumber_ShouldReturnTheNumberItself(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, "1,3")]
        [TestCase(5, "2,3 ")]
        [TestCase(9, "4,5")]
        public void GivenTwoNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(9, "4\n5")]
        [TestCase(10, "4\n5\n1")]
        public void GivenNumbesrWithNewLines_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "//;\n1;2")]
        [TestCase(3, ";\n1;2")]
        public void GivenNumbesrWithDifferentDelimeters_ShouldReturnTheSum(int expected, string numbers)
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
