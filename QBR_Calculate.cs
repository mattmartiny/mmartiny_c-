using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_QBR

{
    class QBR_Calculate
    {
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {

                Console.WriteLine("Is this for the NCAA or the NFL/CFL\n" +
                    "(A) NCAA \n"
                    + "(B) NFL/CFL \n"
                    );
                string choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "A":

                        NCAA();
                        break;
                    case "B":

                        NFL();
                        break;
                    default:
                        Console.WriteLine("input not recognized");
                        break;

                }


            } while (!exit);
        }

        private static void NFL()
        //calculates the QBR for NFL

        {

            Console.WriteLine("Enter the number of attempted passes");
            double att = double.Parse(Console.ReadLine());
            //Number of pass attempts

            Console.WriteLine("Enter the number of completed passes");
            double comp = double.Parse(Console.ReadLine());
            //Number of pass completions

            Console.WriteLine("Enter the total number of yards passed for");
            double yds = double.Parse(Console.ReadLine());
            //number of passing yards

            Console.WriteLine("Enter the total number of touchdown passes");
            double td = double.Parse(Console.ReadLine());
            //number of TD Passes

            Console.WriteLine("Enter the total number of interceptions thrown");
            double inter = double.Parse(Console.ReadLine());
            //number of TD Passes

            double a = ((comp / att - 0.3) * 5); //part one of formula
            double b = ((yds / att - 3) * 0.25); //part 2 of formula
            double c = ((td / att) * 20);// part 3 of formula
            double d = 2.375 - ((inter / att) * 25); //part 4 of formula


            /*
             * NFL QBR requires the result of any calculation to be non-negative and no more than 2.375
             * It also states, if it is a negative number, set it to 0
             * or if it's greater than 2.375, set it to 2.375
             * 
             */

            a = Math.Max(a, 0);
            b = Math.Max(b, 0);
            c = Math.Max(c, 0);
            d = Math.Max(d, 0);
            
            a = Math.Min(a, 2.375);
            b = Math.Min(b, 2.375);
            c = Math.Min(c, 2.375);
            d = Math.Min(d, 2.375);

            double QBR = (((a + b + c + d) / 6) * 100);

            Console.Clear();
            Console.WriteLine("Calculating....");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();  
            Console.WriteLine("Your Quarterback rating is " + Math.Round(QBR, 1) + "\n\n");
        }

                
        private static void NCAA()
            //NCAA Passing Formula

        { 
         Console.WriteLine("Enter the number of attempted passes");
         double att = double.Parse(Console.ReadLine());
        //Number of pass attempts
        
        Console.WriteLine("Enter the number of completed passes");
            double comp = double.Parse(Console.ReadLine());
        //Number of pass completions

        Console.WriteLine("Enter the total number of yards passed for");
          double yds = double.Parse(Console.ReadLine());
        //number of passing yards

        Console.WriteLine("Enter the total number of touchdown passes");
           double td = double.Parse(Console.ReadLine());
        //number of TD Passes

        Console.WriteLine("Enter the total number of interceptions thrown");
            double inter = double.Parse(Console.ReadLine());
            //number of TD Passes

            //The NCAA doesn't have a minimum or maximum limit, 

            
            double QBR = (((8.4 * yds) + (330 * td) + (100 * comp) - (200 * inter)) / att);

            Console.Clear();
            Console.WriteLine("Calculating...");
            System.Threading.Thread.Sleep(2500);
            Console.Clear();
            Console.WriteLine("Your Quarterback rating is " + Math.Round(QBR, 1)+"\n\n");

        }

        //To Do: Error Handling (i.e. when a user inputs something that isn't a number). probably going to use TryParse().  

    }
}
