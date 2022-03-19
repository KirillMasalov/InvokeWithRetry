using NUnit.Framework;
using System;
using InvokeWithRetry;
namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private static int attempts = 0;
        private Action attemptsAction;
        private Action exceptionAction;
        [SetUp]
        public void Setup()
        {
            attemptsAction = () => attempts++;
            exceptionAction = () =>
            {
                for (var i = 0; i < 5; i++)
                    throw new Exception();
            };
        }

        [Test]
        public void Test1()
        {
            var successExecute = Program.InvokeWithRetry(exceptionAction, 10);
            Assert.AreEqual(false, successExecute);
            successExecute = Program.InvokeWithRetry(attemptsAction, 10);
            Assert.AreEqual(true, successExecute);
            Assert.AreEqual(10, attempts);
        }
    }
}