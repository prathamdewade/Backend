using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Stylo_Spin.Models;

[Table("tblCategory")]
public partial class TblCategory
{
    [Key]
    [Column("C_Id")]
    public int CId { get; set; }

    [Column("c_Name")]
    [StringLength(255)]
    public string CName { get; set; } = null!;

    public bool Status { get; set; }

    [JsonIgnore]
    [InverseProperty("CIdNavigation")]
    public virtual ICollection<TblProduct> TblProducts { get; set; } = new List<TblProduct>();
}
