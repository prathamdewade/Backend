using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Stylo_Spin.Models;

[Table("tblCustomer")]
[Index("CEmail", Name = "UQ__tblCusto__5D1915F92ED82940", IsUnique = true)]
public partial class TblCustomer
{
    [Key]
    public int Id { get; set; }

    [Column("C_Name")]
    [StringLength(200)]
    public string CName { get; set; } = null!;

    [Column("C_Email")]
    [StringLength(200)]
    public string CEmail { get; set; } = null!;

    [StringLength(20)]
    public string? ContactNumber { get; set; }

    public string? Address { get; set; }

    [JsonIgnore]
    [InverseProperty("CIdNavigation")]
    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
