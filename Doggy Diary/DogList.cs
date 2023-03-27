using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Doggy_Diary
{
    public class DogList
    {
        static List<Dog> dogs = new List<Dog>();
        private string fileName = "doglist.txt";
        public void AddDog()
        {
            if (File.Exists(fileName))
            {
                dogs.Clear();
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        dogs.Add(new Dog(line));
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Enter the dog's name you would like to add:");
            String name = Console.ReadLine();

            dogs.Add(new Dog(name));

            Console.Clear();
            Console.WriteLine($"New Dog \"{name}\" Added\r\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();


            Console.WriteLine("All dogs currently in record:");
            Console.WriteLine("-------------------------------");
            foreach (Dog dog in dogs)
            {
                Console.WriteLine($"{dog.Name}");
            }
            Console.WriteLine("\r\r\n\nPress any key to return to main menu...");
            Console.ReadKey(true);

            SaveDogListToFile();
        }

        private void SaveDogListToFile()
        {
       
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (Dog dog in dogs)
                {
                    writer.WriteLine(dog.Name);
                }
            }
        }
    }

}
