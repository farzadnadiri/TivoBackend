﻿using System;
using System.Collections.Generic;
using System.Linq;
using App.DataLayer.Context;
using App.Entities;
using App.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class EfProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Product> _products;

        public EfProductService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _products = _uow.Set<Product>();
        }

        public void AddNewProduct(Product product)
        {
            _products.Add(product);
        }

        public IList<Product> GetAllProducts()
        {
            return _products.Include(x => x.Category).ToList();
        }
    }
}
