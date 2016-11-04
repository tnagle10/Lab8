using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lab8
{
    class Program
    {
        public class Player
        {
            
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double AB { get; set; }
            public double Single { get; set; }
            public double Double {get;set; }
            public double Triple {get;set;}
            public double HR { get; set; }
            public double Avg { get; set; }
            public double Slug { get; set; }

            

        }
        static void Main(string[] args)
        {

            List<Player> Tigers = createInitPlayerList();


            int option;

            do
            {
                string[] options = { "List Team", "Enter At Bats", "Add Player", "Exit"};
                genList(options, out option);

                switch (option)
                {
                    case 1:
                        listPlayers(Tigers);
                        break;
                    case 2:
                        getAtBats(Tigers);
                        break;
                    case 3:
                        addPlayers(Tigers);
                        break;
                    case 4:
                        return;

                    default:
                        break;
                }

            } while (keepGoing());
          
        }

        static void genList(string[] names, out int option)
        {
            Boolean valid = false;
            int input = 0;
            int pos = 0;
            while (valid == false)
            {

                Console.WriteLine("Please choose one of the following options: ");
                for (int i = 0; i < names.Length; i++)
                {
                    Console.WriteLine(i+1 + ": " + names[i]);
                }

                input = int.Parse(Console.ReadLine());
                pos = Array.IndexOf(names, names[input]);

                if (pos > -1)
                {
                    Console.WriteLine("You chose " + names[input-1] + "\n");
                    valid = true;
                }
                else
                {
                    valid = false;
                }
                

            }
            option = pos;
            
        }

        private static void getAtBats(List<Player> Tigers)
        {
            do
            {   
               
                int timesAtBat = 0;
                
                int[] atBatResults;
                Console.WriteLine("Enter at bat information\n");
                string FName = getPlayerAttributeS("First Name");
                string LName = getPlayerAttributeS("Last Name");
                Console.Write("Enter number of times at bat:");

                if (int.TryParse(Console.ReadLine(), out timesAtBat))
                {

                    if (timesAtBat > 0)
                    {
                        atBatResults = getAtBats(timesAtBat);
                        double  avg = calcAvg(atBatResults);
                        double slug = calcSlug(atBatResults);
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

                int loc = Tigers.FindIndex(x => x.FirstName == FName && x.LastName == LName);

                if (loc > 0)
                {
                    Player temp = Tigers[loc];
                    temp.AB = temp.AB + timesAtBat;

                }
                else
                {
                    Console.WriteLine("Player doesn't exist");
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

        static double calcSlug(int[] atBatResults)
        {
            int sum = 0;

            foreach (int atBat in atBatResults)
            {
                sum = sum + atBat;
            }

            int timesAtBat = atBatResults.Length;
            double slug = (double)sum / timesAtBat;
            Console.WriteLine("\nSlugging Percentage: {0}", slug);
            return slug;
        }

        static double calcAvg(int[] atBatResults)
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
            return avg;
        }

        public static List<Player> createInitPlayerList()
        {
           List<Player> Tigers = new List<Player>();
            
            
            // Add players to team
            Tigers.Add(new Player() { FirstName = "Miguel", LastName = "Cabrera", AB = 595, Single = 188, Double = 31, Triple = 1, HR = 38, Avg = .316, Slug = .563, });
            Tigers.Add(new Player() { FirstName = "Curtis", LastName = "Maybin", AB = 349, Single = 110, Double = 14, Triple = 5, HR = 4, Avg = .315, Slug = .418, });
            
            return Tigers;
        }

        
        public static void listPlayers(List<Player> Tigers)
        {
            //List<Player> Tigers = new List<Player>();
            foreach (Player players in Tigers)
            {
                Console.WriteLine("FirstName  LastName        AB      Single     Double    Triple     HR     Avg    Slug");

                Console.WriteLine(players.FirstName.PadRight(2) + players.LastName.PadLeft(12) + "        " + players.AB + "      " + players.Single + "        " + players.Double + "            " + players.Triple + "       " + players.HR + "    " + players.Avg + "    " + players.Slug);

            }

        }


        public static void addPlayers(List<Player> Tigers)
        {
            string FName;
            string LName;
            double AB;
            double Single;
            double Double;
            double Triple;
            double HR;
            double Avg;
            double Slug;
            
            Console.WriteLine("Enter a new player");

            FName = getPlayerAttributeS("First Name");
            LName = getPlayerAttributeS("Last Name");
            AB = getPlayerAttributeI("At Bats");
            Single = getPlayerAttributeI("Singles");
            Double = getPlayerAttributeI("Doubles");
            Triple = getPlayerAttributeI("Triples");
            HR = getPlayerAttributeI("Home Runs");
            Avg = getPlayerAttributeI("Average");
            Slug = getPlayerAttributeI("Slugging Percentage");
            

            Tigers.Add(new Player() { FirstName = FName, LastName = LName, AB = AB, Single = Single, Double = Double, Triple = Triple, HR = HR, Avg = Avg, Slug = Slug, });

        }
        
        private static string getPlayerAttributeS(string input)
        {
            string output = "";
            bool good = false;
            while (!(good))
            {
                Console.Write("Enter player {0}: ",input);
                output = Console.ReadLine();
                if (output == "")
                {
                    Console.WriteLine("You entered an invalid name.  Please try again");
                    output = "";

                }
                else
                {
                    good = true;
                }

            }

            return output;
        }

        private static double getPlayerAttributeI(string input)
        {
            double output = 0;
            bool good = false;
            while (!(good))
            {
                Console.Write("Enter player first {0}: ", input);
                if ((double.TryParse(Console.ReadLine(),out output)) == false)
                {
                    Console.WriteLine("You entered an invalid {0}.  Please try again", input);
                    good = false;
                }
                
                    good = true;
              

            }

            return output;
        }



        ////List<Player> lastnamenagle = test.FindAll(x=> x.LastName == "Nagle");


        //Player temp = test[2];
        //temp.LastName = temp.LastName + "billy";

        //            Console.WriteLine("do i get here");
        //            List<Player> lastnamenagle = test.FindAll(g => g.FirstName == "Calvin" && g.LastName == "Nagle");
        //            foreach (var item in lastnamenagle)
        //            {
        //                Console.WriteLine(item.FirstName + item.LastName);
        //                int loc = test.FindIndex(x => x.FirstName == "bob");
        //                 Console.WriteLine(loc);
        //            }




    }
}
