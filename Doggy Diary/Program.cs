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
            Console.WriteLine("[2] Review Previous Entries");
            Console.WriteLine("[3] Add or Remove a Dog");
            Console.WriteLine("[4] EXIT");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    EntryManager.MakePeePooEntry(dogList);
                    break;
                case "2":                    
                    EntryManager.ViewAllEntries();
                    break;
                case "3":
                    dogList.AddOrRemoveDogSelection();
                    break;
                case "4":
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

