using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CustomerPortal.DAL.Model
{
    public partial class CustomerAddress
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Column("CustomerAddress")]
        [StringLength(500)]
        public string? CustomerAddress1 { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("CustomerAddresses")]
        public virtual Customer Customer { get; set; } = null!;
    }
}
