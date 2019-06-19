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
            List<DataOrderItem> items = new List<DataOrderItem>();
            string id = "8ec5b379-90f5-11e9-b0f5-005056a73cc6";
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
                    DataOrderItem itemr = new DataOrderItem();
                  
                    order.Id = reader.GetInt32("Id");
                    order.CustomId = reader.GetChar("CustomUser_Id");
                    order.TotalPrice = reader.GetDecimal("totalprice");
                    itemr.ProductName = reader.GetString("Name");
                    itemr.Price = reader.GetDecimal("Sellprice");

                    // save uitlening to the list
                    orders.Add(order);
                    items.Add(itemr);
                }
            }
            catch
            {
                Console.WriteLine("kan de query niet uitvoeren! LOL");
            }
            data.Conn.Close();
            return orders;
        }

        public void SingleOrder()
        {
            data.Conn.Open();
            string query = "SELECT * from ordor inner join ordoritem inner join product inner join customer where ordor.id = @id";
            MySqlCommand Com = new MySqlCommand(query, data.Conn);
            
        }
    }
}
