using System;
using System.IO;

namespace PatronageZadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loopBreak = true;
            do
            {
                int method = Menu();
                switch (method)
                {
                    case 1:
                        var obFizzBuzz = new FizzBuzzGenerator();
                        obFizzBuzz.FizzBuzz();
                        break;
                    case 2:
                        var obDeepDive = new DeepDiveGenerator();
                        obDeepDive.DeepDive();
                        break;
                    case 3:
                        var obDrownItDown = new DrownItDownGenerator();
                        obDrownItDown.DrownItDown();
                        break;
                    case 4:
                        loopBreak = false;
                        break;
                    default:
                        break;
                }
            } while (loopBreak);


        }

        static int Menu()
        {
            Console.WriteLine("\n --------------- MENU ---------------");
            Console.WriteLine("Wybierz jedna z podanych nizej metod podajac cyfre od 1 do 4:");
            Console.WriteLine("\n \t 1. FizzBuzz");
            Console.WriteLine("\t 2. DeepDive");
            Console.WriteLine("\t 3. DrownItDown");
            Console.WriteLine("\t 4. Exit");

            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Musisz podać cyfrę! \n");
                return -1;
            }
        }
    }

}
