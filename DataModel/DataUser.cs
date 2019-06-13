using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
   public class DataUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       public int Role { get; set; }
    }
}
