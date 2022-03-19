using System;

namespace InvokeWithRetry
{
    public static class Program
    {
        private static int attemptsCount;
        private static bool isSuccessfull;
        public static bool InvokeWithRetry(Action action, int maxAttempts)
        {
            try
            {
                attemptsCount++;
                action.Invoke();
                isSuccessfull = true;
                return true;
            }
            catch (Exception)
            {
                if (attemptsCount >= maxAttempts)
                    return false;
                InvokeWithRetry(action, maxAttempts);
                return isSuccessfull;
            }
        }

        public static void Main()
        {
        }
    }
}
