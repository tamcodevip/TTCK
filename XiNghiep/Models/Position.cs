using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

[Index("PositionName", Name = "UQ__Position__E46AEF4218376961", IsUnique = true)]
public partial class Position
{
    [Key]
    [Column("PositionID")]
    public int PositionId { get; set; }

    [StringLength(100)]
    public string PositionName { get; set; } = null!;

    [Column("Salary_range", TypeName = "decimal(18, 2)")]
    public decimal? SalaryRange { get; set; }

    [Column("DepartmentID")]
    public int? DepartmentId { get; set; }

    [Column("Create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [InverseProperty("Position")]
    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    [ForeignKey("DepartmentId")]
    [InverseProperty("Positions")]
    public virtual Department? Department { get; set; }

    [InverseProperty("Position")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
