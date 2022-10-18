using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService
    {
        void Register(Customer entity);
        string Login(Customer entity);
        Customer FirstOrDefault(Customer entity);
    }
}
