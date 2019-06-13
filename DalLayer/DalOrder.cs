using System;
using System.Collections.Generic;
using System.Text;
using DataModel;
using MySql.Data.MySqlClient;

namespace DalLayer
{
   public class DalOrder
   {
      Database data = new Database();
        public List<DataModel.DataOrder> Orders()
        {
            int id = 1;
            // stored procedure
            string query = "call bestellingen(@id)";
            data.Conn.Open();

            MySqlCommand Com = new MySqlCommand(query, data.Conn);
            Com.Parameters.Add(new MySqlParameter("@id", id));
            MySqlDataReader reader = Com.ExecuteReader();
            try
            { 
                //read through all the data
                while (reader.Read())
                {
                    //create productlist
                    DataOrder order = new DataOrder();
                    order.Id = reader.GetInt32("Id");
                    order.CustomId = reader.GetInt32("Name");
                    order.TotalPrice = reader.GetDecimal("totalprice");
                    // save uitlening to the list
                    Orders().Add(order);
                }
            }
            catch
            {
                Console.WriteLine("kan de query niet uitvoeren! LOL");
            }

            data.Conn.Close();

            return Orders();
        }
    }
}
