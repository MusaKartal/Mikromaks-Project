using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiesLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private IConfiguration _config;
        public CustomerManager(ICustomerDal customerDal, IConfiguration config)
        {
            _config = config;
            _customerDal = customerDal;
        }

        public Customer FirstOrDefault(Customer entity)
        {
           return _customerDal.FirstOrDefault(c => c.Email == entity.Email);
        }

        public virtual string Login(Customer entity)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credetianls = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, entity.Email)

            };

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credetianls);
            var Jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Jwt;
        }

        public virtual void Register(Customer entity)
        {
            // email sorgusu ekle
            _customerDal.Create(entity);
        }
    }
}
