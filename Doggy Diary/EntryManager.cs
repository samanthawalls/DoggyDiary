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
            Console.WriteLine("Select a dog:");

            for (int i = 0; i < dogList.Dogs.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {dogList.Dogs[i].Name}");
            }

            int dogIndex;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out dogIndex))
                {
                    if (dogIndex >= 1 && dogIndex <= dogList.Dogs.Count)
                    {
                        break;
                    }
                }

                Console.WriteLine("Invalid selection. Please try again.");
            }

            Dog selectedDog = dogList.Dogs[dogIndex - 1];

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
            Console.WriteLine("Select a dog:");

            for (int i = 0; i < dogList.Dogs.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {dogList.Dogs[i].Name}");
            }

            int dogIndex;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out dogIndex))
                {
                    if (dogIndex >= 1 && dogIndex <= dogList.Dogs.Count)
                    {
                        break;
                    }
                }

                Console.WriteLine("Invalid selection. Please try again.");
            }

            Dog selectedDog = dogList.Dogs[dogIndex - 1];

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
    }
}