using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggy_Diary
{
    public class MealEntry : Entry
    {
        public bool Ate { get; set; }


        public MealEntry(bool Ate) { }
        //public MealEntry(DateTime timestamp, bool ate)
        //{
        //    Timestamp = timestamp;
        //    Ate = ate;
        //}

    }
}
