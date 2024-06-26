﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Order;

namespace Domain.ArchPatterns.Repositories.OrderRepository
{
    public interface IOrderRepository : ICreateOrderRepository, IReadOrderRepository, IUpdateOrderRepository
    {}
}
