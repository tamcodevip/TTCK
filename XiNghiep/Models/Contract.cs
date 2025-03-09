using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

public partial class Contract
{
    [Key]
    [Column("ContractID")]
    public int ContractId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(20)]
    public string ContractType { get; set; } = null!;

    [Column("Start_Date")]
    public DateOnly StartDate { get; set; }

    [Column("End_Date")]
    public DateOnly? EndDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Salary { get; set; }

    [StringLength(20)]
    public string? Status { get; set; }

    [Column("Create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Contracts")]
    public virtual Employee Employee { get; set; } = null!;
}
