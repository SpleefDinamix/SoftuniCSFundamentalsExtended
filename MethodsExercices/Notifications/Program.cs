using System;

namespace Notifications
{
    class Program
    {
        static void Main()
        {
            Notify();
        }

        static string ShowSuccess(string operation, string message)
        {
            return $"Successfully executed {operation}.\n==============================\nMessage: {message}.";
        }

        static string ShowError(string operation, int code)
        {
            string reason = code > 0 ? "Invalid Client Data" : "Internal System Failure";
            return $"Error: Failed to execute {operation}.\n==============================\nError Code: {code}.\nReason: {reason}.";
        }

        static void Notify()
        {
            int times = int.Parse(Console.ReadLine());

            for (int i=0;i<times;i++)
            {
                string kindOfMessage = Console.ReadLine();

                switch (kindOfMessage)
                {
                    case "success":
                        Console.WriteLine(ShowSuccess(Console.ReadLine(), Console.ReadLine()));
                    break;

                    case "error":
                        Console.WriteLine(ShowError(Console.ReadLine(), int.Parse(Console.ReadLine())));
                    break;

                    default:
                        continue;
                }
            }
        }
    }
}
