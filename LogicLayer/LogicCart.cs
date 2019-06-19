using System;
using System.Collections.Generic;
using DataModel;
using System.Text;
using DalLayer;
using System.Linq;

namespace LogicLayer
{
   public class LogicCart
   {//gaat naar dal order
       private DalProduct product;
        public List<Dataproduct> CartShow()
        {
            
            //List<DataProducts> filteredList = DataProducts.Where( artikelenID => product.id).ToList();
            //return filteredList;
            return product.ProductList();
        }
    }
}
