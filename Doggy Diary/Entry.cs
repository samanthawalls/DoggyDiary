using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggy_Diary
{
    public abstract class Entry
    {
        public DateTime EntryDateTime { get; set; }
        public Dog Dog { get; set; }
        
        public Entry(DateTime entryDateTime, Dog dog)
        {
            EntryDateTime= entryDateTime;
            Dog = dog;
        }
        public abstract void DisplayPeePooEntry();
    }
}
