using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

public partial class Assignment
{
    [Key]
    [Column("AssignmentID")]
    public int AssignmentId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [Column("DepartmentID")]
    public int DepartmentId { get; set; }

    [Column("PositionID")]
    public int PositionId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    [Column("Create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("Assignments")]
    public virtual Department Department { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("Assignments")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("PositionId")]
    [InverseProperty("Assignments")]
    public virtual Position Position { get; set; } = null!;
}
