using NUnit.Framework.Interfaces;
using Transactions;

namespace TestTransaction
{

    [TestFixture]
    public class Tests
    {
        Transaction Transaction { get; set; }

        [SetUp]
        public void PreConditions()
        {
            Transaction = new Transaction();
        }

        [Test]
        [TestCaseSource(typeof(TestData), nameof(TestData.MinSumData))]
        public void MinSum(decimal sum)
        {
            try
            {
                var actualResult = Transaction.FullSum(sum);
            }
            catch (AggregateException e)
            {
                if(e.Message.Equals("The transaction amount is less than the minimum amount"))
                {
                    Assert.Pass();
                }
            }
        }


        [Test]
        [TestCaseSource(typeof(TestData), nameof(TestData.MaxSumData))]
        public void MaxSum(decimal sum)
        {
            try
            {
                var actualResult = Transaction.FullSum(sum);
            }
            catch (AggregateException e)
            {
                if(e.Message.Equals("The transaction amount is greater than the maximum amount"))
                {
                    Assert.Pass();
                }
                
            }
        }

        [Test]
        [TestCaseSource(typeof(TestData), nameof(TestData.Per10SumData))]
        public void Per10Sum(decimal sum, decimal expectedResult)
        {
            var actualResult = Transaction.FullSum(sum);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCaseSource(typeof(TestData), nameof(TestData.Per5SumData))]
        public void Per5Sum(decimal sum, decimal expectedResult)
        {
            var actualResult = Transaction.FullSum(sum);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCaseSource(typeof(TestData), nameof(TestData.Per1SumData))]
        public void Per1Sum(decimal sum, decimal expectedResult)
        {
            var actualResult = Transaction.FullSum(sum);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

    }

}

