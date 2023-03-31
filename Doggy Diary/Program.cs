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
        DogList dogList = DogList.LoadDogs();
        dogList = DogList.LoadDogs();


        while (true)

        {
            Console.Clear();
            Console.WriteLine("Welcome to Doggy Diary!");
            Console.WriteLine("-----------------------\r\n");
            Console.WriteLine("Select an Option:");
            Console.WriteLine("[1] Make a Pee/Poo Entry");
            Console.WriteLine("[2] View Today's Entries For All Dogs");
            Console.WriteLine("[3] Filter Entries by Dog Name");
            Console.WriteLine("[4] View All Previous Entries");
            Console.WriteLine("[5] Add or Remove Dogs");
            Console.WriteLine("[6] EXIT");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    EntryManager.MakePeePooEntry(dogList);
                    break;
                case "2":
                    EntryManager.ViewEntriesTodaysDate();
                    break;
                case "3":
                    EntryManager.ViewEntriesByDog(dogList);
                    break;
                case "4":
                    EntryManager.ViewAllEntries();
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

