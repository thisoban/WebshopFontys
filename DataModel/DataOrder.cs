using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
   public class DataOrder
    {
        public int Id { get; set; }
        public int CustomId { get; set; }
        public List<DataOrderItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set;}
    }
}
