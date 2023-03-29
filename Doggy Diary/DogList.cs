using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

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
            String name = Console.ReadLine();

            Dogs.Add(new Dog(name));

            Console.Clear();
            Console.WriteLine($"New Dog \"{name}\" Added\r\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();

            PrintAllDogs();

            SaveDogs();
        }

        public bool HasDogs()
        {
            return Dogs.Count > 0;
        }

        public void RemoveDog()
        {
            Console.Clear();
            Console.WriteLine("Select a dog to remove by entering its index number:");
            for (int i = 0; i < Dogs.Count; i++)
            {
                Console.WriteLine($"{i}: {Dogs[i].Name}");
            }

            int index;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index < Dogs.Count)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid index number.");
            }

            string name = Dogs[index].Name;
            Dogs.RemoveAt(index);

            Console.Clear();
            Console.WriteLine($"Dog \"{name}\" Removed\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();

            PrintAllDogs();

            SaveDogs();
        }

        public void AddOrRemoveDogSelection()
        {
            Console.Clear();
            Console.WriteLine("Do you want to add or remove a dog? Enter \"A\" to add or \"R\" to remove:");
            string input = Console.ReadLine().ToLower();

            if (input == "a")
            {
                AddDog();
            }
            else if (input == "r")
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
        public void AddEntry(Entry entry)
        {

            var dog = Dogs.FirstOrDefault(d => d.Name == entry.Dog.Name);
            if (dog != null)
            {
                dog.Entries.Add(entry);
            }
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
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (Dog dog in Dogs)
                {
                    writer.WriteLine(dog.Name);
                }
            }
        }
    }

}
