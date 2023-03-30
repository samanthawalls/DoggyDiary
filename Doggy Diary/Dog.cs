using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json.Serialization;

namespace Doggy_Diary
{
    public class Dog
    {
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }


        public Dog(string name) 
        {
            Name = name;
            Entries = new List<Entry>();
        }    

       
    }
   
}
