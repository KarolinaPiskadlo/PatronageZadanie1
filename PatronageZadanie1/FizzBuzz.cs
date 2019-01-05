using System;
using System.Collections.Generic;
using System.Text;

namespace PatronageZadanie1
{
    class FizzBuzzGenerator
    {
        private const int MIN_RANGE = 0;
        private const int MAX_RANGE = 1000;

        /// <summary>
        /// Take a numerical parameter and then print "Fizz" if divided by 2,
        /// "Buzz" if divided by 3, "FizzBuzz" if divided by both.
        /// </summary>
        public void FizzBuzz()
        {
            bool isDivisible = false;
            int returnValue = FizzBuzzStart();

            if (returnValue == -1)
            {
                return;
            }

            if (!IsInRange(returnValue))
            {
                Console.WriteLine("Podano złą wartość.");
                return;
            }

            if (returnValue % 2 == 0)
            {
                Console.Write("Fizz");
                isDivisible = true;
            }

            if (returnValue % 3 == 0)
            {
                Console.Write("Buzz");
                isDivisible = true;
            }

            if (isDivisible == false)
            {
                Console.WriteLine("Podana liczba nie jest podzielna ani przez 2, ani przez 3.");
            }
            else
            {
                Console.WriteLine();
            }
        }

        private int FizzBuzzStart()
        {
            Console.WriteLine("\n --------------- FizzBuzz ---------------");
            Console.Write($"Podaj liczbę w przedziale od {MIN_RANGE} do {MAX_RANGE}: ");

            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Musisz podać liczbę.");
                return -1;
            }
        }

        private bool IsInRange(int val)
        {
            if (val >= MIN_RANGE && val <= MAX_RANGE)
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
