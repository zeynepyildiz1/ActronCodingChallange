using ActronCodingChallange.Business.Interfaces;
using ActronCodingChallange.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections.Generic;

namespace FindMaxNumberApiTest
{
    public class Tests
    {
        private IFindMaxNumber _findMaxNumber;

        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
             .AddScoped<IFindMaxNumber, FindMaxNumber>()
             .BuildServiceProvider();

            _findMaxNumber = serviceProvider.GetRequiredService<IFindMaxNumber>();
        }

        [TestCase(new int[] { 15, 223, 78, 90, 99 }, "99907822315")]
        [TestCase(new int[] { 7, 8, 9, 90, 99 }, "9999087")]
        [TestCase(new int[] { 1, 2, 20, 3, 4 }, "432201")]

        public void FindMaxNumber_ReturnsCorrectResult(int[] numbers, string expectedResult)
        {

            string result = _findMaxNumber.FindMaxNumber(numbers.ToList());
            Assert.AreEqual(expectedResult, result, "The result is correct.");
        }
    }
}
