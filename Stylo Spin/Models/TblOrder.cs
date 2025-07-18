using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Stylo_Spin.Models;

[Table("tblOrder")]
public partial class TblOrder
{
    [Key]
    [Column("O_Id")]
    public int OId { get; set; }

    [Column("C_Id")]
    public int CId { get; set; }

    [Column("P_Id")]
    public int PId { get; set; }

    public int ProductQuantity { get; set; }

    [Column("Total_Price", TypeName = "decimal(10, 2)")]
    public decimal TotalPrice { get; set; }

    [StringLength(200)]
    public string? Message { get; set; }

    [StringLength(20)]
    public string PaymentStatus { get; set; } = null!;

    [Column("ordaerDate", TypeName = "datetime")]
    public DateTime OrdaerDate { get; set; }

    [JsonIgnore]
    [ForeignKey("CId")]
    [InverseProperty("TblOrders")]
    public virtual TblCustomer CIdNavigation { get; set; } = null!;

    [JsonIgnore]
    [ForeignKey("PId")]
    [InverseProperty("TblOrders")]
    public virtual TblProduct PIdNavigation { get; set; } = null!;
}
