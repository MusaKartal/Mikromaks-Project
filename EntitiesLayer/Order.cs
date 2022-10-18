using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string OrderNumber { get; set; }

        public int ProductId { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }

        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }

    }
}
