using Doggy_Diary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Doggy Diary";
        DogList dogList = new DogList();
        dogList = DogList.LoadDogs();

        while (true)

        {
            Console.Clear();
            Console.WriteLine("Welcome to Doggy Diary!");
            Console.WriteLine("-----------------------\r\n");
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
                    EntryManager.TimeSinceLastEntry(dogList);
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
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
        }
    }
}

