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
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my clock application");
            Console.WriteLine("Would you like to be reminded the time periodically? Please answer yes or no: ");
            string decision = Console.ReadLine();
            bool closeApp = false;

            if (decision == "yes" || decision == "Yes")
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
                        MessageBox.Show(Time.CurrentTime());
                        startTime = DateTime.Now;
                        endTime = startTime.AddMinutes(frequency);  
                    }

                    Thread.Sleep(60 * 1000);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                }
            }
            else
            {

            }
            Console.ReadLine();
        }
    }
}
