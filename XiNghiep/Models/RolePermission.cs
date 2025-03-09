using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

[PrimaryKey("RoleId", "Permission")]
[Table("Role_Permissions")]
public partial class RolePermission
{
    [Key]
    [Column("RoleID")]
    public int RoleId { get; set; }

    [Key]
    [StringLength(100)]
    public string Permission { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("RolePermissions")]
    public virtual Role Role { get; set; } = null!;
}
