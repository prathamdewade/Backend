using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Stylo_Spin.Models;

[Table("tblContactUs")]
public partial class TblContactU
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string? ContactNumber { get; set; }

    public string Query { get; set; } = null!;
}
