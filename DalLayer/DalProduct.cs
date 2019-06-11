using System;
using System.Collections.Generic;
using DalLayer.Interfaces;
using DataModel;
using MySql.Data.MySqlClient;

namespace DalLayer
{
    public class DalProduct: IDalProduct
    {
        public static string Connection = "Server=studmysql01.fhict.local;Uid=dbi419727;Database=dbi419727;Pwd=Kersen112!;";
        public  MySqlConnection Conn = new MySqlConnection(Connection);

        public List<Dataproduct> ProductList()
        {
           List<Dataproduct>  productList = new List<Dataproduct>();
           string query = "SELECT * FROM product";
           Conn.Open();
           MySqlCommand command = new MySqlCommand(query, Conn);
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
           Conn.Close();
           return  productList;
        }

        public void ProductCreate(Dataproduct ProductNew)
        {
            string query = "INSERT INTO `product`( `Name`, `Description`, `Quantity`, `Sellprice`) VALUES ( @name,@Description,@Quanitity,@Sellprice)";
            Conn.Open();
            MySqlCommand command = new MySqlCommand(query, Conn);
            
        }
    }
}
