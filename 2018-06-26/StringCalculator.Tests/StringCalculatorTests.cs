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
        public void Add_GivenNoNumber_ShouldReturnZero(int expected, string numbers) {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3,"3")]
        [TestCase(10, "10")]
        [TestCase(23, "23")]
        public void Add_GivenOneNumber_ShouldReturnNumberItself(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, "1,3")]
        [TestCase(10, "5,5")]
        [TestCase(100, "25,75")]
        public void Add_GivenTwoNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(12, "1,3,5,3")]
        [TestCase(85, "5,10,20,50")]
        [TestCase(8, "1,1,1,1,1,1,1,1")]
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

        public void Add_GivenNewlinesBetweenNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(numbers);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "//;\n1;2")]

        public void Add_GivenMulitpleDelimetersBetweenNumbers_ShouldReturnTheSum(int expected, string numbers)
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
