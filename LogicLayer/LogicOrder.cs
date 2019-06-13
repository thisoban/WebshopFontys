using System;
using System.Collections.Generic;
using System.Text;
using DalLayer;
using DataModel;

namespace LogicLayer
{
    public class LogicOrder
    {
        private DalOrder order;
        public List<DataOrder> GetOrders()
        {
           return order.Orders();
        }
    }
}
