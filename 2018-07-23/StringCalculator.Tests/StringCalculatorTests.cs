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
        public void Add_GivenEmptyString_ShouldReturn0(int expected , string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //ASsert
            Assert.AreEqual(expected,actual);
        }

        [TestCase(1, "1")]
        [TestCase(112, "112")]
        public void Add_GivenStringWithOneNumber_ShouldReturnTheNumberItself(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //ASsert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "1,2")]
        [TestCase(50, "20,30")]
        public void Add_GivenStringWithTwoNumbers_ShouldReturnTheSum(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //ASsert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, "20,30,50")]
        [TestCase(10, "1,1,1,1,1,1,1,1,1,1")]
        public void Add_GivenStringWithUnkownAmountOfNumbers_ShouldReturnTheSum(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //ASsert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "1\n2,3")]
        public void Add_GivenStringWithNewLineDelimiter_ShouldReturnTheSum(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //ASsert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "//;\n1;2")]
        [TestCase(3, "//#\n1#2")]
        public void Add_GivenStringWithCustomDelimiter_ShouldReturnTheSum(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //ASsert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("negatives not allowed : -1 ", "100,-1")]
        [TestCase("negatives not allowed : -2 -1 -3 -6 ", "-2,-1,-3,5,-6")]
        public void Add_GivenStringWithNegativeNumbers_ShouldReturnTheSum(string expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //ASsert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase(2, "1001,2")]
        [TestCase(1002, "1000,2")]
        public void Add_GivenStringWithNumbersMoreThan1000_ShouldReturnTheSumOfThoseEqualOrLessThan1000(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //ASsert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(18, "//[**]\n5**4**9")]
        public void Add_GivenStringWithCustomMultipleDelimiter_ShouldReturnTheSum(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //ASsert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(42, "//[%*][&!][(##)]\n3%*6&!11(##)22")]
        public void Add_GivenStringWithManyCustomMultipleDelimiter_ShouldReturnTheSum(int expected, string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //ASsert
            Assert.AreEqual(expected, actual);
        }
    }
}
