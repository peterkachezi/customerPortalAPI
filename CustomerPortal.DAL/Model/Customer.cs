using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CustomerPortal.DAL.Model
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
        }

        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [StringLength(100)]
        public string? CustomerName { get; set; }
        [StringLength(100)]
        public string? FatherName { get; set; }
        [StringLength(100)]
        public string? MotherName { get; set; }
        public int? MaritalStatus { get; set; }
        public byte[]? CustomerPhoto { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Country.Customers))]
        public virtual Country CustomerNavigation { get; set; } = null!;
        [InverseProperty(nameof(CustomerAddress.Customer))]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
