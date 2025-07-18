using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Stylo_Spin.Models;

[Table("tblProduct")]
public partial class TblProduct
{
    [Key]
    [Column("p_Id")]
    public int PId { get; set; }

    [Column("c_id")]
    public int? CId { get; set; }

    [Column("p_Name")]
    [StringLength(200)]
    public string? PName { get; set; }

    public bool Status { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    public byte[]? ImageData { get; set; }

    [StringLength(255)]
    public string? ImageName { get; set; }

    [Column("price", TypeName = "decimal(18, 2)")]
    public decimal? Price { get; set; }

    public int ProductQuantity { get; set; }
    [JsonIgnore]
    [ForeignKey("CId")]
    [InverseProperty("TblProducts")]
    public virtual TblCategory? CIdNavigation { get; set; }
    [JsonIgnore]
    [InverseProperty("PIdNavigation")]
    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
