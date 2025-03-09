using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

public partial class LeaveRequest
{
    [Key]
    [Column("LeaveRequestID")]
    public int LeaveRequestId { get; set; }

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(20)]
    public string LeaveType { get; set; } = null!;

    [Column("Start_Date")]
    public DateOnly StartDate { get; set; }

    [Column("End_Date")]
    public DateOnly EndDate { get; set; }

    [StringLength(20)]
    public string? Status { get; set; }

    [Column("Reason_Leave")]
    public string? ReasonLeave { get; set; }

    [Column("Create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("LeaveRequests")]
    public virtual Employee Employee { get; set; } = null!;
}
