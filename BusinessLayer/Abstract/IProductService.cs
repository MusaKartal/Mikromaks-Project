using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Create(Product entity);
        void Delete(int id);
        void Update(Product entity, int id);
    }
}
