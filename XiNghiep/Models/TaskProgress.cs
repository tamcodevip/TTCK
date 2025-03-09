using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

[Table("TaskProgress")]
public partial class TaskProgress
{
    [Key]
    [Column("ProgressID")]
    public int ProgressId { get; set; }

    [Column("TaskID")]
    public int TaskId { get; set; }

    [StringLength(20)]
    public string Status { get; set; } = null!;

    [Column("Update_Note")]
    public string? UpdateNote { get; set; }

    [Column("Updated_At", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("TaskId")]
    [InverseProperty("TaskProgresses")]
    public virtual Task Task { get; set; } = null!;
}
