﻿using System;
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
                        var fizzBuzz = new FizzBuzzGenerator();
                        fizzBuzz.FizzBuzz();
                        break;
                    case 2:
                        var deepDive = new DeepDiveGenerator();
                        deepDive.DeepDive();
                        break;
                    case 3:
                        var drownItDown = new DrownItDownGenerator();
                        drownItDown.DrownItDown();
                        break;
                    case 4:
                        loopBreak = false;
                        break;
                    default:
                        Console.WriteLine("Wprowadzono złą wartość.");
                        break;
                }
            } while (loopBreak);


        }

        static int Menu()
        {
            Console.WriteLine("\n --------------- MENU ---------------");
            Console.WriteLine("Wybierz jedna z podanych nizej metod podajac liczbę od 1 do 4:");
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
                Console.WriteLine("Musisz podać liczbę. \n");
                return -1;
            }
        }
    }

}
