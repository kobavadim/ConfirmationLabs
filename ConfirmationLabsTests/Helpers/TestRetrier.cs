using System;
using System.Collections.Generic;

namespace ConfirmationLabsTests.Helpers
{
    public static class TestRetrier
    {
        public static void RunWithRetry(this Action action, int attemptCount, Action onRetry = null)
        {
            string error = "";
            var currentAttempt = 0;

            while (currentAttempt < attemptCount)
            {
                try
                {
                    currentAttempt++;
                    Console.WriteLine($"{currentAttempt} attempt");
                    action();
                    return;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    //Log.WriteActionWithTimestamp($"Exception was occurred: {ex.Message}{Environment.NewLine}{ex.StackTrace}");
                    //string method = action.Method.Name;

                    if (ex.Message.Contains("Page is empty!"))
                    {

                    }

                    if (currentAttempt < attemptCount)
                    {
                        try
                        {
                            //Browser.Close();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Cannot close browser and screenshot...");
                        }
                    }
                    onRetry?.Invoke();
                }
            }

            if (string.IsNullOrEmpty(error) == true)
            {

            }
            else
            {
                throw new Exception(error);
            }
        }

        public static void RunWithRetry(this IEnumerable<Action> actions, int attemptCount)
        {
            foreach (var action in actions)
            {
                action.RunWithRetry(attemptCount);
            }
        }

        public static void RunWithRetry(int attemptCount, params Action[] actions)
        {
            actions.RunWithRetry(attemptCount);
        }

        public static void RetryAllOnFailure(this IEnumerable<Action> actions, int attemptCount, Action onRetry = null)
        {
            actions.RunAll().RunWithRetry(attemptCount, onRetry);
        }

        public static void RetryAllOnFailure(Action onRetry, int attemptCount, params Action[] actions)
        {
            actions.RetryAllOnFailure(attemptCount, onRetry);
        }

        private static Action RunAll(this IEnumerable<Action> actions)
        {
            return () =>
            {
                foreach (var action in actions)
                {
                    action();
                }
            };
        }
    }
}