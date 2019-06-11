using System;
using System.Collections.Generic;
using System.Linq;
using DalLayer;
using DataModel;
namespace LogicLayer
{
    public class LogicProduct
    {

        private DalProduct dallaag = new DalProduct();

        public List<Dataproduct> Productlist()
        {
            List<Dataproduct> Producten = dallaag.ProductList();
           
            return Producten;
        }
        public void productadd()
        {

        }

        public void ProductShow()
        {

        }

       
    }
}
