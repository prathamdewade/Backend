using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Stylo_Spin.Models;

[Table("tblUser")]
public partial class TblUser
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Username { get; set; }

    [Column("userEmail")]
    [StringLength(100)]
    [Unicode(false)]
    public string? UserEmail { get; set; }

    [Column("password")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Password { get; set; }
}
