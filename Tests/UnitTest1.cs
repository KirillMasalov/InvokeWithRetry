using NUnit.Framework;
using System;
using InvokeWithRetry;
namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private static int attempts = 0;
        private static int exceptionAttempts = 0;

        private Action attemptsAction;
        private Action exceptionAction;

        [SetUp]
        public void Setup()
        {
            attemptsAction = () => attempts++;
            exceptionAction = () =>
            {
                if (exceptionAttempts < 5)
                {
                    exceptionAttempts++;
                    throw new Exception();
                }
            };
        }

        [Test]
        public void Test1()
        {
            var successExecute = Program.InvokeWithRetry(exceptionAction, 10);
            Assert.AreEqual(true, successExecute);
            successExecute = Program.InvokeWithRetry(attemptsAction, 10);
            Assert.AreEqual(true, successExecute);
            Assert.AreEqual(1, attempts);
        }
    }
}