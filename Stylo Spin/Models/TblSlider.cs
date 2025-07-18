using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Stylo_Spin.Models;

[Table("tblSlider")]
public partial class TblSlider
{
    [Key]
    public int Id { get; set; }

    public byte[]? ImageData { get; set; }

    [StringLength(255)]
    public string? ImageName { get; set; }
}
