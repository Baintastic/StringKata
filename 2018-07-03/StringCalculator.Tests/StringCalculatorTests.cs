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
        public void Add_GivenNoNumber_ShouldReturn0(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, "1")]
        [TestCase(21, "21")]
        [TestCase(150, "150")]
        public void Add_GivenOneNumber_ShouldReturnTheNumberItself(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, "2,3")]
        [TestCase(23, "20,3")]
        [TestCase(56, "20,36")]
        public void Add_GivenTwoNumbers_ShouldReturnSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase(10, "2,3,1,4")]
        [TestCase(100, "20,30,50")]
        [TestCase(10, "1,1,1,1,1,1,1,1,1,1")]
        public void Add_GivenUnknownAmountOfNumbers_ShouldReturnSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "1\n2,3")]
        [TestCase(10, "1\n2,3\n4")]
        [TestCase(19, "1\n5\n5,5\n3")]
        public void Add_GivenNumbersWithNewLines_ShouldReturnSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "//;\n1;2")]
        [TestCase(100, "//*\n20*50*30")]
        [TestCase(20, "//#\n5#5#10")]
        public void Add_GivenNumbersWithDifferentDelimeters_ShouldReturnSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("negatives not allowed : -1", "//#\n-1")]
        [TestCase("negatives not allowed : -1 -2", "//#\n-1#-2")]
        [TestCase("negatives not allowed : -5", "//*\n-5*10*12")]
        public void Add_GivenNumbersWithNegatives_ShouldReturnSum(string expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(numbers));


            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase(2, "//#\n1001#2")]
        [TestCase(1001, "//#\n999#2")]
        [TestCase(1003, "//#\n1000#3")]
        public void Add_GivenNumbersMoreThan1000_ShouldReturnSumOfNumbersLessThan1001(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "//[***]\n1***2***3")]
        [TestCase(25, "//[##]\n20##2##3")]
        [TestCase(85, "//[!!!!!]\n80!!!!!2!!!!!3")]
        public void Add_GivenNumbersWithDelimetersOfAnyLength_ShouldReturnSum(int expected, string numbers)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, "//[*][%]\n1*2%3")]
        [TestCase(8, "//[*][%][@]\n1*2%3@2")]
        [TestCase(12, "//[*][%][###]\n1*2%3##6")]
        public void Add_GivenNumbersWithMultipleDelimetersOfAnyLength_ShouldReturnSum(int expected, string numbers)
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
