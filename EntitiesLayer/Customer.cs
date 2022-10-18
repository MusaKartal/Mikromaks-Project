using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "This field must be 11 characters")]
        public string TCKN { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual List<Order> Orders { get; set; }


    }
}
