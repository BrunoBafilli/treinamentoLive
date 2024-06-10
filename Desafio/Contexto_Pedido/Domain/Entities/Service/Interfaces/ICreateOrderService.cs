﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Domain
{
    public interface ICreateOrderService
    {
        Task CreateNewOrder(int clientId, List<int> productsId);
    }
}
