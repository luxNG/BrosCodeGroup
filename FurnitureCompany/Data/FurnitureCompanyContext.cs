using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FurnitureCompany.Models;

namespace FurnitureCompany.Data
{
    public partial class FurnitureCompanyContext : DbContext
    {
        public FurnitureCompanyContext()
        {
        }

        public FurnitureCompanyContext(DbContextOptions<FurnitureCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Assign> Assigns { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeDayOff> EmployeeDayOffs { get; set; } = null!;
        public virtual DbSet<EmployeeOrderService> EmployeeOrderServices { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderService> OrderServices { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceDetail> ServiceDetails { get; set; } = null!;
        public virtual DbSet<Specialty> Specialties { get; set; } = null!;
        public virtual DbSet<WorkingStatus> WorkingStatuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=FurnitureCompanyDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("account_id");

                entity.Property(e => e.AccountStatus).HasColumnName("account_status");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Username).HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_accounts_roles");
            });

            modelBuilder.Entity<Assign>(entity =>
            {
                entity.ToTable("assign");

                entity.Property(e => e.AssignId).HasColumnName("assign_id");

                entity.Property(e => e.CreateAssignAt)
                    .HasColumnType("date")
                    .HasColumnName("create_assign_at");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Assigns)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assign_employee");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Assigns)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assign_manager");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Assigns)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_assign_order");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customer_phone");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_customers_accounts");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .HasColumnName("employee_name");

                entity.Property(e => e.EmployeePhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("employee_phone_number");

                entity.Property(e => e.ImageUrl).HasColumnName("image_url");

                entity.Property(e => e.SpecialtyId).HasColumnName("specialty_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.WorkingStatus).HasColumnName("working_status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employees_accounts");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_specialty");
            });

            modelBuilder.Entity<EmployeeDayOff>(entity =>
            {
                entity.ToTable("employee_day_off");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DayOff)
                    .HasColumnType("date")
                    .HasColumnName("day_off");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Reason).HasColumnName("reason");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDayOffs)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_day_off_employee");
            });

            modelBuilder.Entity<EmployeeOrderService>(entity =>
            {
                entity.ToTable("employee_order_service");

                entity.Property(e => e.EmployeeOrderServiceId).HasColumnName("employee_order_service_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.OrderServiceId).HasColumnName("order_service_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeOrderServices)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_order_service_employee");

                entity.HasOne(d => d.OrderService)
                    .WithMany(p => p.EmployeeOrderServices)
                    .HasForeignKey(d => d.OrderServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employee_order_service_order_service");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("manager");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(50)
                    .HasColumnName("manager_name");

                entity.Property(e => e.ManagerPhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("manager_phone_number");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_managers_accounts");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("date")
                    .HasColumnName("update_at");

                entity.Property(e => e.WorkingStatusId).HasColumnName("working_status_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_customer");

                entity.HasOne(d => d.WorkingStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WorkingStatusId)
                    .HasConstraintName("FK_order_working_status");
            });

            modelBuilder.Entity<OrderService>(entity =>
            {
                entity.ToTable("order_service");

                entity.Property(e => e.OrderServiceId).HasColumnName("order_service_id");

                entity.Property(e => e.EstimateTimeFinish)
                    .HasMaxLength(50)
                    .HasColumnName("estimate_time_finish");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderServices)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_service_order");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.OrderServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_service_service");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("service");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.Price)
                    .HasMaxLength(50)
                    .HasColumnName("price");

                entity.Property(e => e.ServiceDescription).HasColumnName("service_description");

                entity.Property(e => e.ServiceName).HasColumnName("service_name");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("date")
                    .HasColumnName("update_at");
            });

            modelBuilder.Entity<ServiceDetail>(entity =>
            {
                entity.ToTable("service_detail");

                entity.Property(e => e.ServiceDetailId).HasColumnName("service_detail_id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("date")
                    .HasColumnName("create_at");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Price)
                    .HasMaxLength(50)
                    .HasColumnName("price");

                entity.Property(e => e.ServiceDetailName)
                    .HasMaxLength(50)
                    .HasColumnName("service_detail_name");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("date")
                    .HasColumnName("update_at");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceDetails)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_service_detail_service");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.ToTable("specialty");

                entity.Property(e => e.SpecialtyId).HasColumnName("specialty_id");

                entity.Property(e => e.SpecialtyName)
                    .HasMaxLength(50)
                    .HasColumnName("specialty_name");
            });

            modelBuilder.Entity<WorkingStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_status");

                entity.ToTable("working_status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .HasColumnName("status_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
