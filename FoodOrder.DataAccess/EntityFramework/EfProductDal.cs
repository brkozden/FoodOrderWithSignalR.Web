using FoodOrder.DataAccess.Abstrack;
using FoodOrder.DataAccess.Concrete;
using FoodOrder.DataAccess.Repositories;
using FoodOrder.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.DataAccess.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(FoodOrderContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new FoodOrderContext();
            return context.Products.Include(x=>x.Category).ToList();
        }
    }
}
