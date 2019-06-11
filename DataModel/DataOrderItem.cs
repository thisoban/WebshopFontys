using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace DataModel
{
   public class DataOrderItem
    {
        private int Id { get; set; }
        private string ProductName { get; set; }
        private int Quantity { get; set; }
    }
}
