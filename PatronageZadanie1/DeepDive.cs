using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PatronageZadanie1
{
    class DeepDiveGenerator
    {
        public void DeepDive()
        {
            int numberOfFolders = DeepDiveStart();

            if (numberOfFolders == -1)
                return;

            if (!IsInRange(numberOfFolders))
            {
                Console.WriteLine("Podano złą wartość!");
                return;
            }
            CreateFolder(numberOfFolders);
        }

        private int DeepDiveStart()
        {
            Console.WriteLine("\n --------------- DeepDive ---------------");
            Console.Write("Ile folderów zagnieżdżonych utworzyć? Podaj liczbę od 1 do 5: ");

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

        private void CreateFolder(int number)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            Console.WriteLine("Tworzenie folderów w :");
            Console.WriteLine(currentDirectory);

            for (int i = 1; i <= number; i++)
            {
                Guid guid;
                guid = Guid.NewGuid();
                string path = System.IO.Path.Combine(currentDirectory, guid.ToString());
                System.IO.Directory.CreateDirectory(path);
                currentDirectory = path;
            }
        }

        private bool IsInRange(int val)
        {
            if (val >= 1 && val <= 5)
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
