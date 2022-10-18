using DataAccessLayer.Abstract;
using EntitiesLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class CustomerDal : GenericRepository<Customer, DataContext>, ICustomerDal
    {   
    }
}
