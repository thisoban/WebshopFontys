using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace DalLayer
{
  public  class Database
      { public static string Connection = "Server=studmysql01.fhict.local;Uid=dbi419727;Database=dbi419727;Pwd=Kersen112!;";
        public  MySqlConnection Conn = new MySqlConnection(Connection);
         
      }
  }
      
