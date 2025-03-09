using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

public partial class PayrollDetail
{
    [Key]
    [Column("PayrollDetailID")]
    public int PayrollDetailId { get; set; }

    [Column("PayrollID")]
    public int PayrollId { get; set; }

    [StringLength(100)]
    public string ItemName { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    [StringLength(20)]
    public string? Type { get; set; }

    [ForeignKey("PayrollId")]
    [InverseProperty("PayrollDetails")]
    public virtual Payroll Payroll { get; set; } = null!;
}
