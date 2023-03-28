using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggy_Diary
{
    public class PeePooEntry : Entry
    {
        
        public bool IsPee { get; set; }
        public bool IsPoo { get; set; }
        

        public PeePooEntry(DateTime entryDateTime, Dog dog, bool isPee, bool isPoo) : base(entryDateTime, dog)
        {
            IsPee = isPee;
            IsPoo = isPoo;
            SavePeePooEntriesToFile();
        }

        public override void Display()
        {
            Console.WriteLine($"Entry for {Dog.Name} on {EntryDateTime.ToShortDateString()} @{EntryDateTime.ToShortTimeString()}");
            if (IsPee && IsPoo)
            {
                Console.WriteLine(" - Pee & Poo Recorded!");
            }
            else if (IsPee)
            {
                Console.WriteLine(" - Pee Recorded!");
            }
            else if (IsPoo)
            {
                Console.WriteLine(" - Poo Recorded!");
            }
        }
        private void SavePeePooEntriesToFile()
        {
            string fileName = "pee_poo_entries.txt";
            using (StreamWriter sr = new StreamWriter (fileName, true)) 
            {
                string entryString = $"{EntryDateTime.ToShortDateString()} {EntryDateTime.ToShortTimeString()} - {Dog.Name} - {(IsPee ? "Pee" : "")}{(IsPoo ? "Poo" : "")}";
                sr.WriteLine(entryString);
            }
        }
    }
}
