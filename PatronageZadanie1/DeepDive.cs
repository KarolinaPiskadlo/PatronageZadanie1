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

            Recurrence(number, currentDirectory);  
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

        private void Recurrence(int number, string path)
        {
            if (number <= 0)
                return;

            Guid guid = Guid.NewGuid();
            string path2 = System.IO.Path.Combine(path, guid.ToString());

            if (!Directory.Exists(path2))
            {
                System.IO.Directory.CreateDirectory(path2);
            }
            else
            {
                Console.WriteLine("Nie można utworzyć folderu o nazwie: ", guid);
                Console.WriteLine("Folder o takiej nazwie już istnieje.");
            }

            path = path2;
            Recurrence(--number, path);
        }
    }
}
