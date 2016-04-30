using ColossusBets.Calculator.DataService;
using ColossusBets.Calculator.DataService.Ef6Model;
using Moq;
using NUnit.Framework;

namespace ColossusBets.Calculator.Service.Implementation.Test
{
    [TestFixture]
    public class ServiceCalculatorTest
    {
        [SetUp]
        public void Init()
        {
            var mockDataDervice = new Mock<IDataServiceCalculator>();
            mockDataDervice.Setup(x => x.Store(It.IsAny<Record>()));
            _dataDervice = mockDataDervice.Object;
            _service = new ServiceCalculator(_dataDervice);
        }

        private IDataServiceCalculator _dataDervice;
        private IServiceCalculator _service;

        [Test]
        [TestCase(0.01, "p0.01")]
        [TestCase(0.02, "p0.02")]
        [TestCase(0.05, "p0.05")]
        [TestCase(0.10, "p0.10")]
        [TestCase(0.20, "p0.20")]
        [TestCase(0.50, "p0.50")]
        [TestCase(1.00, "£1")]
        [TestCase(2.00, "£2")]
        [TestCase(5.00, "£5")]
        [TestCase(10.00, "£10")]
        [TestCase(20.00, "£20")]
        [TestCase(50.00, "£50")]
        public void BaseTestCalculation(decimal amount, string expected)
        {
            var combination = _service.GetSmallestCombination(amount);
            Assert.IsTrue(combination.HasResult());
            Assert.IsTrue(combination.Count() == 1);
            var result = combination.ElementAt(0);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Quantity == 1);
            Assert.IsTrue(result.Money.Amount == amount);
            Assert.AreEqual(result.Money.ToString(), expected);
        }

        [Test]
        [TestCase(111, "£50x2+£10x1+£1x1")]
        [TestCase(887.91, "£50x17+£20x1+£10x1+£5x1+£2x1+p0.50x1+p0.20x2+p0.01x1")]
        [TestCase(0.12, "p0.10x1+p0.02x1")]
        public void TestCalculation(decimal amount, string expected)
        {
            var combination = _service.GetSmallestCombination(amount);
            Assert.IsTrue(combination.HasResult());
            Assert.IsTrue(combination.Count() > 1);
            string toCompare = null;
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var result in combination.Result())
            {
                toCompare = toCompare == null
                    ? string.Format("{0}x{1}", result.Money, result.Quantity)
                    : string.Format("{0}+{1}x{2}", toCompare, result.Money, result.Quantity);
            }
            Assert.IsNotNull(toCompare);
            Assert.AreEqual(toCompare.ToLowerInvariant().Trim(), expected);
        }
    }
}