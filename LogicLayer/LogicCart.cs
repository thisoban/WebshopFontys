﻿using System;
using System.Collections.Generic;
using DataModel;
using System.Text;
using DalLayer;
using System.Linq;

namespace LogicLayer
{
   public class LogicCart
   {
       private DalProduct product;
        public List<Dataproduct> CartShow()
        {
            product.ProductList();
            List<DataProducts> filteredList = DataProducts.Where( artikelenID => product.id).ToList();
            return filteredList;
        }
    }
}
