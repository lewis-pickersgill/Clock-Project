using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Clock_Project
{
    public static class Time
    {
        public static string CurrentTime()
        {
            DateTime time = DateTime.Now;
            return "The current time is: " + time.ToShortTimeString();
        }
        public static void SpecificTimer(DateTime reminderTime)
        {
            Console.Clear();
            Console.SetWindowSize(100, 5);
            Console.WriteLine("Your timer is set for " + reminderTime);
            while (reminderTime >= DateTime.Now)
            {
                Thread.Sleep(10 * 1000);
            }
            PopUp();
        }
        public static void PopUp()
        {
            MessageBox.Show(CurrentTime(), "Time", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my clock application");
            Console.WriteLine("Please select from one of the following options:\n1. Set a reminder for a specific time\n2. Set a frequent reminder");
            Console.WriteLine("Please enter the number of the option you would like to select: ");
            string decision = Console.ReadLine();
            bool closeApp = false;

            if (decision == "1")
            {
                Console.WriteLine("What time would you like to be reminded? Please respond in the 24 hour format, e.g 17:34");
                DateTime endTime = Convert.ToDateTime(Console.ReadLine());
                Time.SpecificTimer(endTime);
            }

            if (decision == "2")
            {
                Console.WriteLine("Okay, how often would you like to be reminded? Please enter below in minutes: ");
                int frequency = Convert.ToInt32(Console.ReadLine());
                DateTime startTime = DateTime.Now;
                DateTime endTime = startTime.AddMinutes(frequency);

                while (closeApp == false)
                {
                    Console.WriteLine(Time.CurrentTime());

                    if (DateTime.Now >= endTime)
                    {
                        Time.PopUp();
                        startTime = DateTime.Now;
                        endTime = startTime.AddMinutes(frequency);
                    }

                    Thread.Sleep(5000);
                    Console.Clear();
                }
            }

            Console.ReadLine();
        }
    }
}
