using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace XiNghiep.Models;

public partial class Employee
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(255)]
    [Display(Name = "Hình ảnh")]

    public string? Image { get; set; }

    [StringLength(100)]
    [Display(Name = "Họ và Tên")]

    public string FullName { get; set; } = null!;

    [StringLength(20)]
    [Display(Name = "SĐT")]

    public string Phone { get; set; } = null!;

    [Column("Emergency_contact")]
    [StringLength(20)]
    [Display(Name = "SĐT khẩn cấp")]

    public string? EmergencyContact { get; set; }
    [Display(Name = "Địa chỉ")]

    public string? Address { get; set; }

    [Display(Name = "CCCD")]

    [Column("Identity_number")]
    [StringLength(20)]
    public string? IdentityNumber { get; set; }
    [Display(Name = "Ngày sinh")]

    public DateOnly? DayOfBirth { get; set; }

    [StringLength(20)]
    [Display(Name = "Giới tính")]

    public string Gender { get; set; } = null!;

    [Column("Marital_status")]
    [StringLength(20)]
    [Display(Name = "Trạng thái")]

    public string? MaritalStatus { get; set; }

    [Column("Hire_date")]
    [Display(Name = "Ngày vào")]

    public DateOnly HireDate { get; set; }

    [Column("Job_title")]
    [StringLength(100)]
    [Display(Name = "Chức vụ")]

    public string? JobTitle { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    [Display(Name = "Lương cơ bản")]

    public decimal? Salary { get; set; }

    [Column("DepartmentID")]
    public int? DepartmentId { get; set; }

    [Column("PositionID")]
    public int? PositionId { get; set; }

    [Column("Create_at", TypeName = "datetime")]
    [Display(Name = "Ngày tạo")]

    public DateTime? CreateAt { get; set; }

    [Column("Update_at", TypeName = "datetime")]
    [Display(Name = "Ngày cập nhật")]

    public DateTime? UpdateAt { get; set; }

    [InverseProperty("Employee")]
    public virtual Account? Account { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    [InverseProperty("Employee")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [InverseProperty("Employee")]
    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    [ForeignKey("DepartmentId")]
    [InverseProperty("Employees")]
    [Display(Name = "Phòng ban")]

    public virtual Department? Department { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

    [InverseProperty("Employee")]
    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();

    [ForeignKey("PositionId")]
    [InverseProperty("Employees")]
    [Display(Name = "Chức vụ")]

    public virtual Position? Position { get; set; }

    [InverseProperty("AssignedByNavigation")]
    public virtual ICollection<Task> TaskAssignedByNavigations { get; set; } = new List<Task>();

    [InverseProperty("AssignedToNavigation")]
    public virtual ICollection<Task> TaskAssignedToNavigations { get; set; } = new List<Task>();

    [InverseProperty("Employee")]
    public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
}
