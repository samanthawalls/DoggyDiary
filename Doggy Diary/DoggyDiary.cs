using Doggy_Diary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Doggy_Diary
{
    class DoggyDiary
    {
        private List<Dog> dogs = new List<Dog>();

        public void AddDog(Dog dog)
        {
            dogs.Add(dog);
        }

        public void RecordPeePoo(string dogName, bool pee, bool poo)
        {
            var dog = dogs.FirstOrDefault(d => d.Name == dogName);
            if (dog == null)
            {
                Console.WriteLine($"Dog with name {dogName} does not exist.");
                return;
            }

            dog.AddPeePooEntry(new PeePooEntry { Timestamp = DateTime.Now, Pee = pee, Poo = poo });

        }

        public void RecordMeal(string dogName, bool ate)
        {
            var dog = dogs.FirstOrDefault(dogs => dogs.Name == dogName);
            if (dog == null)
            {
                Console.WriteLine($"Dog with name {dogName} does not exist.");
                return;
            }
            dog.AddMealEntry(new MealEntry { Timestamp = DateTime.Now, Ate = ate });
        }
        public void PrintEntriesReport()
        {
            Console.WriteLine("Please select an option to print entries:");
            Console.WriteLine("1. All entries");
            Console.WriteLine("2. Entries by dog name");
            Console.WriteLine("3. Entries by date");

            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid option selected.");
                return;
            }

            switch (option)
            {
                case 1:
                    PrintAllEntries();
                    break;
                case 2:
                    PrintEntriesByDogName();
                    break;
                case 3:
                    PrintEntriesByDate();
                default:
                    Console.WriteLine("Invalid option selected.");
                    break;
            }

        }

        public static void PrintAllEntries()
        {
            var allEntries = tydogs.SelectMany(dog => dog.PeePooEntries.Select(entry => new { DogName = dog.Name, Entry = (Entry)entry }))
                                 .Concat(dogs.SelectMany(dog => dog.MealEntries.Select(entry => new { DogName = dog.Name, Entry = (Entry)entry })))
                                 .OrderBy(entry => entry.Entry.Timestamp)
                                 .ThenBy(entry => entry.DogName);

            Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10} {4,-10} {5,-10}", "Dog", "Timestamp", "Pee", "Poo", "Ate", "Food");

            foreach (var entry in allEntries)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10} {4,-10} {5,-10}",
                    entry.DogName, entry.Entry.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                    entry.Entry.PeeAmount, entry.Entry.PooAmount,
                    (entry.Entry is MealEntry) ? ((MealEntry)entry.Entry).Amount.ToString() : "",
                    (entry.Entry is MealEntry) ? ((MealEntry)entry.Entry).Food : "");
            }
        }

    }
}

    }
}