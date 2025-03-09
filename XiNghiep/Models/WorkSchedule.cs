using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

public partial class WorkSchedule
{
    [Key]
    [Column("WorkScheduleID")]
    public int WorkScheduleId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [Column("Work_date")]
    public DateOnly WorkDate { get; set; }

    [Column("Start_Date", TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("End_Date", TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [Column("ShiftID")]
    public int? ShiftId { get; set; }

    [Column("Create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("WorkSchedules")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("ShiftId")]
    [InverseProperty("WorkSchedules")]
    public virtual Shift? Shift { get; set; }
}
