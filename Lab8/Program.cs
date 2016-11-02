using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int timesAtBat = 0;
                int[] atBatResults;
                Console.WriteLine("Welcome to Batting Average Calculator!\n");
                Console.Write("Enter number of times at bat:");

                if (int.TryParse(Console.ReadLine(), out timesAtBat))
                {

                    if (timesAtBat > 0)
                    {
                        atBatResults = getAtBats(timesAtBat);
                        calcAvg(atBatResults);
                        calcSlug(atBatResults);
                    }

                    else
                    {
                        Console.WriteLine("Invalid times at bat");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid times at bat");
                }



            } while (keepGoing());
        }

        static bool keepGoing()
        {
            /* Name: keepGoing
            * Description:  This method implements a loop to determine if users wants to continue
            * Input:  None
            * Output: Returns false if user doesn't want to continue.  Otherwise returns true.
            *         Outputs values to Console
            */


            // If user enters "q", execute exit procedure
            Console.WriteLine("\nContinue? (y/n):");
            string input = Console.ReadLine();

            if (input == "n")
            {
                Console.WriteLine("You entered n\n");
                Console.WriteLine("Are you sure you want to exit? (Type y to confirm)");
                input = Console.ReadLine();

                if (input == "y")
                {
                    return false;
                }

            }

            return true;
        }

        static int[] getAtBats(int timesAtBat)
        {

            int[] atBats = new int[timesAtBat];
            int atBatResult;

            Console.WriteLine("\n0=out, 1=single, 2=double, 3=triple, 4=home run");
            for (int i = 0; i < timesAtBat; i++)
            {

                Console.Write("Enter the result for at bat [{0}]:", i);
                if (int.TryParse(Console.ReadLine(), out atBatResult))
                {

                    if (atBatResult >= 0)
                    {
                        atBats[i] = atBatResult;


                    }
                    else
                    {
                        Console.WriteLine("Invalid at bat code");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid at bat code");
                }


            }
            return atBats;

        }

        static void calcSlug(int[] atBatResults)
        {
            int sum = 0;

            foreach (int atBat in atBatResults)
            {
                sum = sum + atBat;
            }

            int timesAtBat = atBatResults.Length;
            double slug = (double)sum / timesAtBat;
            Console.WriteLine("\nSlugging Percentage: {0}", slug);
        }

        static void calcAvg(int[] atBatResults)
        {
            int sum = 0;

            foreach (int atBat in atBatResults)
            {
                if (atBat > 0)
                {
                    sum++;
                }
            }

            int timesAtBat = atBatResults.Length;
            double avg = (double)sum / timesAtBat;
            Console.WriteLine("\nBatting average: {0}", avg);
        }

        

    }
}
