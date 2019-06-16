using System;
using System.Collections.Generic;
using System.Text;
using DataModel;

namespace LogicLayer.Interfaces
{
    public interface ILogicOrder
    {
        List<DataOrder> GetOrders();
       
    }
}
