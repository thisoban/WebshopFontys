using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DalLayer;
using DataModel;

namespace LogicLayer
{
    public class LogicOrder
    {
        private DalOrder order = new DalOrder();
        public List<DataOrder> GetOrders()
        {
            List<DataOrder> orders = order.Orders().ToList();
           return orders;
        }
    }
}
