namespace Doggy_Diary
{
    public class EntryManager
    {
        public static void MakePeePooEntry(DogList dogList)
        {
            if (!dogList.HasDogs())
            {
                Console.WriteLine("There are no dogs on the list. Press any key to continue...");
                Console.ReadKey(true);
                return;
            }

            Console.Clear();
            Dog selectedDog = dogList.SelectDog();

            if (selectedDog != null)
            {
                Console.WriteLine($"Did {selectedDog.Name} pee? (Y/N)");
                bool isPee = false;
                while (true)
                {
                    string input = Console.ReadLine().ToUpper();
                    if (input == "Y")
                    {
                        isPee = true;
                        break;
                    }
                    else if (input == "N")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input. Please Enter Y or N.");
                    }
                }


                Console.WriteLine($"Did {selectedDog.Name} poo? (Y/N)");
                bool isPoo = false;
                while (true)
                {
                    string input = Console.ReadLine().ToUpper();
                    if (input == "Y")
                    {
                        isPoo = true;
                        break;
                    }
                    else if (input == "N")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input. Please Enter Y or N.");
                    }
                }

                DateTime now = DateTime.Now;
                PeePooEntry peePooEntry = new PeePooEntry(now, selectedDog, isPee, isPoo);
                selectedDog.Entries.Add(peePooEntry);
                dogList.SaveDogs();
                peePooEntry.DisplayPeePooEntrySummary();


                Console.WriteLine("\r\n Press any key to return to main menu...");
                Console.ReadKey(true);
            }
            else
            {
                return;
            }
        }

        public static void ViewAllEntries()
        {
            Console.WriteLine("Viewing All Entries:");

            var entries = File.ReadAllLines("pee_poo_entries.txt");


            foreach(var entry in entries)
            {
                Console.WriteLine(entry);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
        public static void ViewEntriesByDog(DogList dogList)
        {
            if (!dogList.HasDogs())
            {
                Console.WriteLine("There are no dogs on the list. Press any key to continue...");
                Console.ReadKey(true);
                return;
            }

            Console.Clear();
            Dog selectedDog = dogList.SelectDog();
            if (selectedDog != null)
            {
                var entries = from line in File.ReadAllLines("pee_poo_entries.txt")
                              where line.Contains(selectedDog.Name)
                              select line;

                if (!entries.Any())
                {
                    Console.WriteLine($"No entries found for {selectedDog.Name}\r\n");
                }
                else
                {
                    Console.WriteLine($"Viewing Entries for Dog: {selectedDog.Name}");
                    Console.WriteLine("-----------------------------------------\r\n");

                    foreach (var entry in entries)
                    {
                        Console.WriteLine(entry);
                    }
                }

                Console.WriteLine("\r\nPress any key to continue...");
                Console.ReadKey(true);
            }
            else
            {
                return;
            }
        }

        public static void ViewEntriesTodaysDate()
        {
            DateTime today = DateTime.Today;

            var entries = from line in File.ReadAllLines("pee_poo_entries.txt")
                          let entryDate = DateTime.ParseExact(line.Split('-')[0].Trim(), "M/d/yyyy h:mm tt", null)
                          where entryDate.Date == today
                          select line;

            if (!entries.Any())
            {
                Console.WriteLine($"No entries found for {today.ToString("d")}\r\n");
            }
            else
            {
                Console.WriteLine($"Viewing Entries for {today.ToString("d")}\r\n");
                Console.WriteLine("---------------------------------\r\n");

                foreach (var entry in entries)
                {
                    Console.WriteLine(entry);
                }
            }

            Console.WriteLine("\r\nPress any key to continue...");
            Console.ReadKey(true);
        }

        public static void TimeSinceLastEntry(DogList dogList)
        {
            if (!dogList.HasDogs())
            {
                Console.WriteLine("There are no dogs on the list. Press any key to continue...");
                Console.ReadKey(true);
                return;
            }

            Console.Clear();
            Dog selectedDog = dogList.SelectDog();
            if (selectedDog != null)
            {
                Console.WriteLine($"Records for {selectedDog.Name}");

                var entries = from line in File.ReadAllLines("pee_poo_entries.txt")
                              let parts = line.Split('-')
                              let entryDate = DateTime.ParseExact(parts[0].Trim() + " " + parts[1].Trim(), "M/d/yyyy h:mm tt", null)
                              where parts[2].Trim() == selectedDog.Name
                              orderby entryDate descending
                              select entryDate;


                if (!entries.Any())
                {
                    Console.WriteLine($"No entries found for {selectedDog.Name}");
                }
                else
                {
                    DateTime lastEntry = entries.First();
                    TimeSpan timeSinceLastEntry = DateTime.Now - lastEntry;
                    Console.WriteLine($"Time since last entry: {timeSinceLastEntry}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
            else
            {
                return;
            }
        }
    }
}