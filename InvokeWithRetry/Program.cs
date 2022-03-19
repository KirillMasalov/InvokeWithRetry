using System;

namespace InvokeWithRetry
{
    public static class Program
    {
        public static bool InvokeWithRetry(Action action, int maxAttempts)
        {
            try
            {
                for (var i = 0; i < maxAttempts; i++)
                    action.Invoke();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void Main()
        { 
        }
    }
}
