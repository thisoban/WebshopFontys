using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
   public class DataOrder
    {
        public int Id { get; set; }
        public int CustomId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public List<DataOrderItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set;}
        public bool Payed { get; set;}
    }
}
