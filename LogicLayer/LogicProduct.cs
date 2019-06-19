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
            if (Producten != null)
            {
                return Producten;
            }

            return null;
        }
        public void productadd(Dataproduct ProductNew)
        {
                dallaag.producten(ProductNew);
        }

        public void ProductDelete(int id)
        {
            dallaag.ProductDelete(id);
        }

        public void ProductShow()
        {

        }

       
    }
}
