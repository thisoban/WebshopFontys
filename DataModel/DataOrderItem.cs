using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace DataModel
{
   public class DataOrderItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
