using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

[Table("Attendance")]
public partial class Attendance
{
    [Key]
    [Column("AttendanceID")]
    public int AttendanceId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [Column("Check_In", TypeName = "datetime")]
    public DateTime CheckIn { get; set; }

    [Column("Check_Out", TypeName = "datetime")]
    public DateTime? CheckOut { get; set; }

    [Column("Work_hours", TypeName = "decimal(5, 2)")]
    public decimal? WorkHours { get; set; }

    [StringLength(20)]
    public string? Status { get; set; }

    [Column("Create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Attendances")]
    public virtual Employee Employee { get; set; } = null!;
}
