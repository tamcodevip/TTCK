using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

[Index("EmployeeId", Name = "UQ__Accounts__7AD04FF0B95C4576", IsUnique = true)]
[Index("Email", Name = "UQ__Accounts__A9D1053418C6CB11", IsUnique = true)]
public partial class Account
{
    [Key]
    [Column("AccountID")]
    public int AccountId { get; set; }
    [Required]

    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(100)]
    [Required]

    public string Email { get; set; } = null!;

    [Column("Password_hash")]
    [Required]

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(20)]
    [Required]

    public string? Role { get; set; }

    [Column("Status_activity")]
    [StringLength(20)]
    [Required]

    public string? StatusActivity { get; set; }

    [Column("Create_at", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("Update_at", TypeName = "datetime")]
    public DateTime? UpdateAt { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Account")]
    public virtual Employee Employee { get; set; } = null!;

    [InverseProperty("Account")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
