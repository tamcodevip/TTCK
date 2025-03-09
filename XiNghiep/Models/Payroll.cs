using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

[Table("Payroll")]
public partial class Payroll
{
    [Key]
    [Column("PayrollID")]
    public int PayrollId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    public DateOnly Date { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal BaseSalary { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? OverTime { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Deductions { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? NetSalary { get; set; }

    [Column("Create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Payrolls")]
    public virtual Employee Employee { get; set; } = null!;

    [InverseProperty("Payroll")]
    public virtual ICollection<PayrollDetail> PayrollDetails { get; set; } = new List<PayrollDetail>();
}
