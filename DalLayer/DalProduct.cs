using System;
using System.Collections.Generic;
using System.Data;
using DalLayer.Interfaces;
using DataModel;
using MySql.Data.MySqlClient;

namespace DalLayer
{
    public class DalProduct: IDalProduct
    {
        Database dal = new Database();

        public List<Dataproduct> ProductList()
        {
           List<Dataproduct>  productList = new List<Dataproduct>();
           string query = "SELECT * FROM product";
           dal.Conn.Open();
           MySqlCommand command = new MySqlCommand(query, dal.Conn);
           MySqlDataReader reader = command.ExecuteReader();
           try
           { 
               //read through all the data
               while (reader.Read())
               {
                   //create productlist
                   Dataproduct product = new Dataproduct();
                   product.Id = reader.GetInt32("Id");
                   product.Name = reader.GetString("Name");
                   product.Sellprice = reader.GetDecimal("Sellprice");
                   // save uitlening to the list
                   productList.Add(product);
               }
           }
           catch
           {
               Console.WriteLine("kan de query niet uitvoeren! LOL");
           }
           dal.Conn.Close();
           return  productList;
        }

        public void ProductCreate(Dataproduct ProductNew)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@Name", ProductNew.Name);
            dict.Add("@Description", ProductNew.Description);
            dict.Add("@Sellprice", ProductNew.Sellprice);
            dict.Add("@Quantity", ProductNew.Quantity);

            string query = "INSERT INTO `product`( `Name`, `Description`, `Quantity`, `Sellprice`) VALUES (@Name,@Description, @Quantity , @Sellprice)";
            dal.DataQuery(query, dict);
        }

        public void ProductDelete(int id)
        {
            string query = "DELETE FROM product WHERE Id = @Id";
            dal.Conn.Open();
            MySqlCommand command = new MySqlCommand(query, dal.Conn);
            try
            {
                command.Parameters.Add(new MySqlParameter("@Id", id));
                command.ExecuteNonQuery();
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            dal.Conn.Close();
        }
        public void producten(Dataproduct productadd)
        {
            dal.Conn.Open();
            
            MySqlCommand Com = new MySqlCommand();
            Com.Connection = dal.Conn;
            Com.CommandText = "productadd";
            Com.CommandType = CommandType.StoredProcedure;

            Com.Parameters.AddWithValue("@name", productadd.Name);
            Com.Parameters["@name"].Direction = ParameterDirection.Input;

            Com.Parameters.AddWithValue("@description", productadd.Description);
            Com.Parameters["@description"].Direction = ParameterDirection.Input;

            Com.Parameters.AddWithValue("@quantity", productadd.Quantity);
            Com.Parameters["@quantity"].Direction = ParameterDirection.Input;

            Com.Parameters.AddWithValue("@sellprice", productadd.Sellprice);
            Com.Parameters["@sellprice"].Direction = ParameterDirection.Input;

            Com.ExecuteNonQuery();
        }
    }
}
