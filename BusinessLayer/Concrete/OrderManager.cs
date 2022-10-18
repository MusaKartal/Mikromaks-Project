using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;

        }

        public string OrderNumber()
        {
            Random random = new Random();
            string key = "123456789abcçdefgğhıijklmnoöprsştuüvyz";
            string orderNumber = "";
            for (int i = 0; i < 11; i++)
            {
                orderNumber += key[random.Next(key.Length)];
            }
            return orderNumber;
        }  
        public void Create(Order entity)
        {       
            entity.OrderNumber = OrderNumber();
            _orderDal.Create(entity);
        }

        public void Delete(int id)
        {
            _orderDal.Delete(id);
        }

        public Order FirstOrDefault(Order entity)
        {
            return _orderDal.FirstOrDefault(c => c.ProductId == entity.ProductId);
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetAll(); 
        }

        public Order GetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public void Update(Order entity, int id)
        {
           _orderDal.Update(entity, id);
        }
    }
}
