using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataModel;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;

namespace DalLayer
{
   public class DalOrder
   {
      Database data = new Database();
        public List<DataOrder> Orders()
        {
            List<DataOrder> orders = new List<DataOrder>();
            int id = 1;
            // stored procedure
          
            data.Conn.Open();
            
            MySqlCommand Com = new MySqlCommand();
            Com.Connection = data.Conn;
            Com.CommandText = "bestellingen ";
            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.AddWithValue("@customid", id);
            Com.Parameters["@customid"].Direction = ParameterDirection.Input;

            Com.ExecuteNonQuery();
            MySqlDataReader reader = Com.ExecuteReader();
            try
            { 
                //read through all the data
                while (reader.Read())
                {
                    //create productlist
                    DataOrder order = new DataOrder();
                    order.Id = reader.GetInt32("Id");
                    order.CustomId = reader.GetInt32("CustomUser_Id");
                    order.TotalPrice = reader.GetDecimal("totalprice");
                    // save uitlening to the list
                    orders.Add(order);
                }
            }
            catch
            {
                Console.WriteLine("kan de query niet uitvoeren! LOL");
            }
            data.Conn.Close();
            return orders;
        }
    }
}
