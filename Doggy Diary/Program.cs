using Doggy_Diary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        DogList dogList = new DogList();
        dogList = DogList.LoadDogs();

        while (true)

        {
            Console.Clear();
            Console.WriteLine("Select an Option:");
            Console.WriteLine("[1] Make a Pee/Poo Entry");
            Console.WriteLine("[2] Check How Long Since Last Pee/Poo");
            Console.WriteLine("[3] View Today's Entries");
            Console.WriteLine("[4] View Entries by Dog Name");
            Console.WriteLine("[5] View Dog List & Add or Remove Dogs");
            Console.WriteLine("[6] EXIT");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    EntryManager.MakePeePooEntry(dogList);
                    break;
                case "2":
                   // need code for this
                    break;
                case "3":
                    EntryManager.ViewEntriesTodaysDate();
                    break;
                case "4":
                    EntryManager.ViewEntriesByDog(dogList);
                    break;
                case "5":
                    dogList.AddOrRemoveDogSelection();
                    break;
                case "6":  
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey(true);
                    break;
            }
        }
    }
}

