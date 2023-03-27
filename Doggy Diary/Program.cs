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

        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu(dogList);
        }

       

    }




    static bool MainMenu(DogList dogList)
    {
        

        Console.Clear();
        Console.WriteLine("Select an Option:");
        Console.WriteLine("[1] Make an Entry (Pee/Poo/Meal)");
        Console.WriteLine("[2] Review Previous Entries");
        Console.WriteLine("[3] Add New Dog");
        Console.WriteLine("[4] EXIT");

        switch (Console.ReadLine())
        {
            case "1":
                //Entry
                return true;
            case "2":
                //LINQ Queries
                return true;
            case "3":
                //Create Dog & Add to List
                dogList.AddDog();
                return true;
            case "4":
                //EXIT
                return false;
            default:
                return true;

        }
    }















    //Main Menu Method



}

