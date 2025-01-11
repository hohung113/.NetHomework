﻿using BusinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        public Task AddNewOrderDetail(OrderDetail orderDetail);
        public List<OrderDetail> GetAllOrdersDetail();
        public List<OrderDetail> GetAllOrderDetailByMember();
    }
}