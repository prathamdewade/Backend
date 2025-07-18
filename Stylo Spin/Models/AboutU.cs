using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Stylo_Spin.Models;

public partial class AboutU
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string? Heading { get; set; }

    public string? Paragraph { get; set; }

    [StringLength(255)]
    public string? SubHeading { get; set; }

    public string? SubParagraph { get; set; }

    public byte[]? ImageData { get; set; }

    [StringLength(255)]
    public string? ImageName { get; set; }
}
