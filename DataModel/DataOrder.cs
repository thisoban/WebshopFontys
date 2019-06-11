using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
   public class DataOrder
    {
        public int id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public List<> OrderProduct { get; set; }
        public int TotalPrice { get; set; }
    }
}
