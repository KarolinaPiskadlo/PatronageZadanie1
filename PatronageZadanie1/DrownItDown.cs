using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PatronageZadanie1
{
    class DrownItDownGenerator
    {
        private const int MIN_RANGE = 1;
        private const int MAX_RANGE = 5;
        private const string FILE = "plik.txt";

        public void DrownItDown()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            int foldersCount = FoldersCountCurrentDirectory(currentDirectory);

            if (foldersCount == -1)
                return;

            int folderNumber = DrownItDownStart();

            if (folderNumber == -1)
                return;

            if (!IsInRange(folderNumber))
            {
                Console.WriteLine("Podano złą wartość.");
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
                Console.WriteLine("Nie można utworzyć pliku! Brak folderów w ścieżce głównej.");
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
            Console.Write($"W którym folderze utworzyć pusty plik? Podaj liczbę od {MIN_RANGE} do {MAX_RANGE}: ");

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
            for (int i = 1; i < folderNumber; i++)
            {
                path = Directory.GetDirectories(path)[0];
            }

            path = Path.Combine(path, FILE);

            if (File.Exists(path))
            {
                Console.Write($"Plik o nazwie {FILE} już istnieje. Czy nadpisać plik {FILE}? (T - tak, N - nie) ");

                switch (Console.ReadLine())
                {
                    case "T":
                        File.Create(path).Dispose();
                        Console.WriteLine($"\nNadpisano plik o nazwie {FILE}: ");
                        Console.WriteLine(path);
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
                Console.WriteLine($"\nUtworzono plik o nazwie {FILE}: ");
                Console.WriteLine(path);
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
