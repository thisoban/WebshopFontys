using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DalLayer
{
  public  class Database
      {
        public static readonly string Connection = "Server=studmysql01.fhict.local;Uid=dbi419727;Database=dbi419727;Pwd=Test123!!;";
        public  MySqlConnection Conn = new MySqlConnection(Connection);

        public void DataQuery(string query, Dictionary<string, object> dictionary)
        {

            using (MySqlConnection conn = new MySqlConnection(Connection))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                for (int i = 0; i < dictionary.Count; i++)
                {
                    var Item = dictionary.ElementAt(i);
                    var ItemKey = Item.Key;
                    var ItemValue = Item.Value;
                    command.Parameters.AddWithValue(ItemKey, ItemValue);
                }
                command.ExecuteNonQuery();
            }
        }
    }
  }
      
