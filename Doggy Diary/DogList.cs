using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using Newtonsoft.Json;

namespace Doggy_Diary
{
    public class DogList
    {
        
        public List<Dog> Dogs { get; set; }
        private string fileName = "doglist.txt";
       

        public DogList()
        {
            Dogs = new List<Dog>();
        }

        
        public void AddDog()
        {

            Console.Clear();
            Console.WriteLine("Enter the dog's name you would like to add:");
            string name = Console.ReadLine();

            if (name.Length == 0)
            {
                Console.WriteLine("Name Cannot Be Empty");
            }
            else
            {
                name = char.ToUpper(name[0]) + name.Substring(1).ToLower();

                Dogs.Add(new Dog(name));

                Console.Clear();
                Console.WriteLine($"New Dog \"{name}\" Added\r\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Console.Clear();

                PrintAllDogs();

                SaveDogs();
            }
        }

        public bool HasDogs()
        {
            return Dogs.Count > 0;
        }

        public void RemoveDog()
        {
            Console.Clear();
            Dog selectedDog = SelectDog();

            if (selectedDog != null)
            {
                Dogs.Remove(selectedDog);
                Console.Clear();
                Console.WriteLine($"Dog \"{selectedDog.Name}\" Removed\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                Console.Clear();

                PrintAllDogs();
                SaveDogs();
            }
        }

        public Dog SelectDog()
        {
            Console.WriteLine("Select a dog (or enter 0 to go back to main menu):");

            for (int i = 0; i < Dogs.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {Dogs[i].Name}");
            }

            int dogIndex;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out dogIndex))
                {
                    if (dogIndex == 0)
                    {
                        return null;
                    }
                    else if (dogIndex >= 1 && dogIndex <= Dogs.Count)
                    {
                        break;
                    }
                }
                Console.WriteLine("Invalid selection. Please try again.");
            }
            return Dogs[dogIndex - 1];
        }

        public void AddOrRemoveDogSelection()
        {
            Console.Clear();

            Console.WriteLine("Current Dogs In List:");
            for (int i = 0; i < Dogs.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {Dogs[i].Name}");
            }
            Console.WriteLine("\r\n");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Do you want to add or remove a dog? Select an option below:");
            Console.WriteLine("[1] Add A Dog");
            Console.WriteLine("[2] Remove A Dog\r\n");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Or Enter 0 to Return to Main Menu");
            string input = Console.ReadLine().ToLower();

            if (input == "1")
            {
                AddDog();
            }
            else if (input == "2")
            {
                RemoveDog();
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        public void PrintAllDogs()
        {
            Console.WriteLine("All dogs currently in record:");
            Console.WriteLine("-------------------------------");
            foreach (Dog dog in Dogs)
            {
                Console.WriteLine($"{dog.Name}");
            }
            Console.WriteLine("\r\nPress any key to return to main menu...");
            Console.ReadKey(true);
        }


        public static DogList LoadDogs()
        {
            DogList dogList = new DogList();
           if (File.Exists(dogList.fileName))
            {
                dogList.Dogs.Clear();
                using (StreamReader sr = new StreamReader(dogList.fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        dogList.Dogs.Add(new Dog(line));
                    }
                }
            }
            return dogList;
        }
        
        public void SaveDogs()
        {
           using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                foreach (Dog dog in Dogs)
                {
                    sw.WriteLine(dog.Name);
                }
            }
        }


    }

}
