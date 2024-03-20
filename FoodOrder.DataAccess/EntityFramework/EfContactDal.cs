using FoodOrder.DataAccess.Abstrack;
using FoodOrder.DataAccess.Concrete;
using FoodOrder.DataAccess.Repositories;
using FoodOrder.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.DataAccess.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        public EfContactDal(FoodOrderContext context) : base(context)
        {
        }
    }
}
