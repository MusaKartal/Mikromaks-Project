using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOrderService
    {
        Order FirstOrDefault(Order entity);
        List<Order> GetAll();
        Order GetById(int id);
        void Create(Order entity);
        void Delete(int id);
        void Update(Order entity, int id);
       
    }
}
