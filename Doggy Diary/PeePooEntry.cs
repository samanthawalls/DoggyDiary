using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggy_Diary
{
    public class PeePooEntry : Entry
    {
        public bool Pee { get; set; }
        public bool Poo { get; set; }

        public PeePooEntry(bool Pee, bool Poo) { }
        // public PeePooEntry(DateTime timestamp, bool pee, bool poo) 
        //{
        //  Timestamp = timestamp;
        //Pee = pee;
        // Poo = poo;
        // }


    }
}
