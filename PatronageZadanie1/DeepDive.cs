using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PatronageZadanie1
{
    class DeepDiveGenerator
    {
        private const int MIN_RANGE = 1;
        private const int MAX_RANGE = 5;

        public void DeepDive()
        {
            int numberOfFolders = DeepDiveStart();

            if (numberOfFolders == -1)
                return;

            if (!IsInRange(numberOfFolders))
            {
                Console.WriteLine("Podano złą wartość.");
                return;
            }
            CreateFolder(numberOfFolders);
        }

        private int DeepDiveStart()
        {
            Console.WriteLine("\n --------------- DeepDive ---------------");
            Console.Write($"Ile folderów zagnieżdżonych utworzyć? Podaj liczbę od {MIN_RANGE} do {MAX_RANGE}: ");

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

        private void CreateFolder(int number)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            Console.WriteLine("Tworzenie folderów w :");
            Console.WriteLine(currentDirectory);

            CreateFolder(number, currentDirectory);  
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

        private void CreateFolder(int number, string path)
        {
            if (number <= 0)
                return;

            Guid guid = Guid.NewGuid();
            path = System.IO.Path.Combine(path, guid.ToString());

            if (!Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            else
            {
                Console.WriteLine($"Nie można utworzyć folderu o nazwie: {guid}");
                Console.WriteLine("Folder o takiej nazwie już istnieje.");
            }

            CreateFolder(--number, path);
        }
    }
}
