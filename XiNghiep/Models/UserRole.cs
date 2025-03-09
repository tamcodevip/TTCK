using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

[Index("AccountId", "RoleId", Name = "UQ__UserRole__8C320964BCFAED49", IsUnique = true)]
public partial class UserRole
{
    [Key]
    [Column("UserRoleID")]
    public int UserRoleId { get; set; }

    [Column("AccountID")]
    public int AccountId { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("UserRoles")]
    public virtual Account Account { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("UserRoles")]
    public virtual Role Role { get; set; } = null!;
}
