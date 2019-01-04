using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PatronageZadanie1
{
    class DrownItDownGenerator
    {
        public void DrownItDown()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            int foldersCount = FoldersCountCurrentDirectory(currentDirectory);

            if (foldersCount == -1)
                return;

            int folderNumber = DrownItDownStart();

            if (folderNumber == -1)                             // jesli nie podano liczby to idz do menu
                return;

            if (!IsInRange(folderNumber))                       // jesli liczba mniejsza od 1 i wieksza od 5 to idz do menu
            {
                Console.WriteLine("Podano złą wartość!");
                return;
            }

            bool fileIsCreated = false;
            string[] files = Directory.GetDirectories(currentDirectory);

            foreach (string file in files)
            {
                if (IsFolderExist(folderNumber, file))
                {
                    CreateFile(file, folderNumber);
                    fileIsCreated = true;
                    break;
                }
                else
                {
                    fileIsCreated = false;
                    continue;
                }
            }

            if (!fileIsCreated)
            {
                Console.WriteLine("Brak wystarczjącej liczby folderów zagnieżdżonych. Skorzystaj z aplikacji DeepDive.");
            }
        }

        private int FoldersCountCurrentDirectory(string currentDirectory)
        {
            int folderCount = 0;
            string[] files = Directory.GetDirectories(currentDirectory);

            foreach (string file in files)
            {
                folderCount++;
            }

            if (folderCount == 0)
            {
                Console.WriteLine("Nie można utworzyć pliku! Brak folderów w ścieżce głównej!");
                Console.WriteLine("Uruchom aplikację DeepDive i utwórz odpowiednią ilość folderów zagnieżdżonych, " +
                    " \n a następnie ponownie uruchom aplikację DrownItDown");
                return -1;
            }
            else
                return folderCount;
        }

        private int DrownItDownStart()
        {
            Console.WriteLine("\n --------------- DrownItDown ---------------");
            Console.Write("W którym folderze utworzyć pusty plik? Podaj cyfrę od 1 do 5: ");

            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Musisz podać cyfrę!");
                return -1;
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

        private bool IsFolderExist(int folderNumber, string path)
        {
            int counter = 1;

            while (counter < folderNumber)
            {   
                if (IsNotEmpty(path))
                {
                    path = Directory.GetDirectories(path)[0];
                    counter++;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void CreateFile(string path, int folderNumber)
        {
            string file = "plik.txt";
            for (int i = 1; i < folderNumber; i++)
            {
                path = Directory.GetDirectories(path)[0];
            }

            path = Path.Combine(path, file);

            if (File.Exists(path))
            {
                Console.Write("Plik o nazwie {0} już istnieje. Czy nadpisać plik {0}? (T - tak, N - nie) ", file);

                switch (Console.ReadLine())
                {
                    case "T":
                        File.Create(path).Dispose();
                        Console.WriteLine("\nNadpisano plik o nazwie {0} ", file);
                        break;
                    case "N":
                        break;
                    default:
                        break;
                }
            }
            else
            {
                File.Create(path).Dispose();
                Console.WriteLine("\nUtworzono plik o nazwie {0} ", file);
            }
        }

        private bool IsNotEmpty(string path)
        {
            bool isFolder = false;
            foreach (var folder in Directory.GetDirectories(path))
            {
                isFolder = true;
            }

            return isFolder;
        }
    }
}
