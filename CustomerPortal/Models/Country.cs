using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CustomerPortal.Models
{
    public partial class Country
    {
        public Country()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? CountryName { get; set; }

        [InverseProperty(nameof(Customer.Country))]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
