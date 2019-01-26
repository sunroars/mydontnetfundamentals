using Converter;
using Moq;
using NUnit.Framework;
using NunitTestingSample;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class FizzBuzzConverterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIntegerPositive([Values(1, 2, 4, 7, 8)] int inputVal)
        {
            FizzBuzzConverter converter = new FizzBuzzConverter();
            string output = converter.GetConvertedValue(inputVal);
            Assert.AreEqual(inputVal.ToString(), output);
        }

        [Test]
        public void TestFizzPositive([Values(3, 6, 9, 12, 99, 48, 54)]int inputVal)
        {
            FizzBuzzConverter converter = new FizzBuzzConverter();
            string output = converter.GetConvertedValue(inputVal);
            Assert.AreEqual("Fizz", output);
        }

        [Test]
        public void TestBuzzPositive([Values(5, 10, 20, 50, 95, 85)] int inputVal)
        {
            FizzBuzzConverter converter = new FizzBuzzConverter();
            string output = converter.GetConvertedValue(inputVal);
            Assert.AreEqual("Buzz", output);
        }

        [Test]
        public void TestFizzBuzzPositive([Values(15, 30, 45, 75)] int inputVal)
        {
            FizzBuzzConverter converter = new FizzBuzzConverter();
            string output = converter.GetConvertedValue(inputVal);
            Assert.AreEqual("FizzBuzz", output);
        }

        [Test]
        public void TestFizzBuzzNegative([Values(1, 3, 5, 7, 11, 13, 17, 19, 23, 27, 77, 97)] int inputVal)
        {
            FizzBuzzConverter converter = new FizzBuzzConverter();
            string output = converter.GetConvertedValue(inputVal);
            Assert.AreNotEqual("FizzBuzz", output);
        }

        [Test]
        public void TestFizzBuzzUsinMock()
        {
            //Ideally thi sis coming from DB but we will just mock.
            List<int> listOfTestData = new List<int>() { 15, 30, 45, 75 };

            Mock<IFizzBuzzDataRepo> mockRepo = new Mock<IFizzBuzzDataRepo>();
            mockRepo.Setup(X => X.GetFizzBuzzTestData()).Returns(listOfTestData);
            FizzBuzzConverter converter = new FizzBuzzConverter();
            List<string> outputValues = converter.GetConvertedValues(mockRepo.Object);

        }
    }
}