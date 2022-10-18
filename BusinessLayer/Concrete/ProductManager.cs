using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{

    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;

        }

        public void Create(Product entity)
        {
            _productDal.Create(entity);
        }

        public void Delete(int id)
        {
            _productDal.Delete(id);
        }

        public List<Product> GetAll()
        {
           return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
           return _productDal.GetById(id);
        }

        public void Update(Product entity, int id)
        {
           _productDal.Update(entity, id);
        }
    }
}
