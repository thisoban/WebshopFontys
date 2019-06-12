using System;
using System.Collections.Generic;
using System.Text;
using DataModel;

namespace DalLayer.Interfaces
{
    public interface IDalProduct
    {
        List<Dataproduct> ProductList();
        void ProductCreate(Dataproduct ProductNew);
        void ProductDelete(int id);
    }
}
