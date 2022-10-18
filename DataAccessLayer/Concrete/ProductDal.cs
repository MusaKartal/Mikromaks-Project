using DataAccessLayer.Abstract;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ProductDal : GenericRepository<Product, DataContext>, IProductDal
    {
    }
}
