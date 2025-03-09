using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

public partial class Task
{
    [Key]
    [Column("TaskID")]
    public int TaskId { get; set; }

    [StringLength(255)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [Column("Assigned_By")]
    public int AssignedBy { get; set; }

    [Column("Assigned_To")]
    public int? AssignedTo { get; set; }

    [Column("Due_Date")]
    public DateOnly? DueDate { get; set; }

    [StringLength(20)]
    public string? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("AssignedBy")]
    [InverseProperty("TaskAssignedByNavigations")]
    public virtual Employee AssignedByNavigation { get; set; } = null!;

    [ForeignKey("AssignedTo")]
    [InverseProperty("TaskAssignedToNavigations")]
    public virtual Employee? AssignedToNavigation { get; set; }

    [InverseProperty("Task")]
    public virtual ICollection<TaskProgress> TaskProgresses { get; set; } = new List<TaskProgress>();
}
