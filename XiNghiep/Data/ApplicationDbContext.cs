using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using XiNghiep.Models;

namespace XiNghiep.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<PayrollDetail> PayrollDetails { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<Models.Task> Tasks { get; set; }

    public virtual DbSet<TaskProgress> TaskProgresses { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-I4QOP46\\SQLEXPRESS;Initial Catalog=XiNghiep;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__349DA5866E108288");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Role).HasDefaultValue("employee");
            entity.Property(e => e.StatusActivity).HasDefaultValue("active");
            entity.Property(e => e.UpdateAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Employee).WithOne(p => p.Account).HasConstraintName("FK__Accounts__Employ__68487DD7");
        });

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Assignme__32499E57CDF47877");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Department).WithMany(p => p.Assignments).HasConstraintName("FK__Assignmen__Depar__73BA3083");

            entity.HasOne(d => d.Employee).WithMany(p => p.Assignments).HasConstraintName("FK__Assignmen__Emplo__72C60C4A");

            entity.HasOne(d => d.Position).WithMany(p => p.Assignments).HasConstraintName("FK__Assignmen__Posit__74AE54BC");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69263CBFA99294");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue("on-time");

            entity.HasOne(d => d.Employee).WithMany(p => p.Attendances).HasConstraintName("FK__Attendanc__Emplo__7F2BE32F");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Contract__C90D3409670AA1F0");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue("active");

            entity.HasOne(d => d.Employee).WithMany(p => p.Contracts).HasConstraintName("FK__Contracts__Emplo__17036CC0");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDCC12619D");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF15AC5D2A7");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.MaritalStatus).HasDefaultValue("single");
            entity.Property(e => e.UpdateAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Employees__Depar__5CD6CB2B");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Employees__Posit__5DCAEF64");
        });

        modelBuilder.Entity<LeaveRequest>(entity =>
        {
            entity.HasKey(e => e.LeaveRequestId).HasName("PK__LeaveReq__6094218E6CC0B64E");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue("pending");

            entity.HasOne(d => d.Employee).WithMany(p => p.LeaveRequests).HasConstraintName("FK__LeaveRequ__Emplo__10566F31");
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.PayrollId).HasName("PK__Payroll__99DFC6924DB036CE");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Deductions).HasDefaultValue(0m);
            entity.Property(e => e.NetSalary).HasDefaultValue(0m);
            entity.Property(e => e.OverTime).HasDefaultValue(0m);

            entity.HasOne(d => d.Employee).WithMany(p => p.Payrolls).HasConstraintName("FK__Payroll__Employe__05D8E0BE");
        });

        modelBuilder.Entity<PayrollDetail>(entity =>
        {
            entity.HasKey(e => e.PayrollDetailId).HasName("PK__PayrollD__010127A96587C6B6");

            entity.HasOne(d => d.Payroll).WithMany(p => p.PayrollDetails).HasConstraintName("FK__PayrollDe__Payro__09A971A2");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__60BB9A59891518BE");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Department).WithMany(p => p.Positions)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Positions__Depar__5535A963");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A668399D3");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.Permission }).HasName("PK__Role_Per__35A6BDB4169BF2CC");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions).HasConstraintName("FK__Role_Perm__RoleI__4CA06362");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__Shifts__C0A838E104BF687B");
        });

        modelBuilder.Entity<Models.Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949D1C8D21605");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue("pending");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.AssignedByNavigation).WithMany(p => p.TaskAssignedByNavigations).HasConstraintName("FK__Tasks__Assigned___1DB06A4F");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.TaskAssignedToNavigations).HasConstraintName("FK__Tasks__Assigned___1EA48E88");
        });

        modelBuilder.Entity<TaskProgress>(entity =>
        {
            entity.HasKey(e => e.ProgressId).HasName("PK__TaskProg__BAE29C85F9B576A3");

            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Task).WithMany(p => p.TaskProgresses).HasConstraintName("FK__TaskProgr__TaskI__236943A5");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A556B9E033A");

            entity.HasOne(d => d.Account).WithMany(p => p.UserRoles).HasConstraintName("FK__UserRoles__Accou__6C190EBB");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasConstraintName("FK__UserRoles__RoleI__6D0D32F4");
        });

        modelBuilder.Entity<WorkSchedule>(entity =>
        {
            entity.HasKey(e => e.WorkScheduleId).HasName("PK__WorkSche__C6AC635E94281883");

            entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Employee).WithMany(p => p.WorkSchedules).HasConstraintName("FK__WorkSched__Emplo__787EE5A0");

            entity.HasOne(d => d.Shift).WithMany(p => p.WorkSchedules).HasConstraintName("FK__WorkSched__Shift__797309D9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
