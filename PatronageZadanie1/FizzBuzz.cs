using System;
using System.Collections.Generic;
using System.Text;

namespace PatronageZadanie1
{
    class FizzBuzzGenerator
    {
        public void FizzBuzz()
        {
            bool isDivisible = false;
            int returnValue = FizzBuzzStart();

            if (returnValue == -1)
                return; 

            if (!IsInRange(returnValue))
            {
                Console.WriteLine("Podano złą wartość!");
                return;
            }

            if (returnValue % 2 == 0)
            {
                Console.Write("Fizz");
                isDivisible = true;
            }

            if (returnValue % 3 == 0)
            {
                Console.WriteLine("Buzz");
                isDivisible = true;
            }

            if (isDivisible == false)
            {
                Console.WriteLine("Podana liczba nie jest podzielna ani przez 2, ani przez 3.");
            }
        }

        private int FizzBuzzStart()
        {
            Console.WriteLine("\n --------------- FizzBuzz ---------------");
            Console.Write("Podaj liczbę w przedziale od 0 do 1000: ");

            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Musisz podać liczbę!");
                return -1;
            }
        }

        private bool IsInRange(int val)
        {
            if (val >= 0 && val <= 1000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
