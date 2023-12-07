using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mynewproject.Models;

public partial class TaskManagerContext : DbContext
{
    public TaskManagerContext()
    {
    }

    public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Pte> Ptes { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7TQD8DS\\SQLEXPRESS;Database=task_manager;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Empid);

            entity.ToTable("employee");

            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("designation");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("project");

            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Deadline)
                .HasColumnType("date")
                .HasColumnName("deadline");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Pte>(entity =>
        {
            entity.ToTable("pte");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Tid).HasColumnName("tid");

            entity.HasOne(d => d.Emp).WithMany(p => p.Ptes)
                .HasForeignKey(d => d.Empid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pte_employee");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.Ptes)
                .HasForeignKey(d => d.Pid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pte_project");

            entity.HasOne(d => d.TidNavigation).WithMany(p => p.Ptes)
                .HasForeignKey(d => d.Tid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pte_task");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Tid);

            entity.ToTable("task");

            entity.Property(e => e.Tid).HasColumnName("tid");
            entity.Property(e => e.Comment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.Deadline)
                .HasColumnType("date")
                .HasColumnName("deadline");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Priority)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("priority");
            entity.Property(e => e.Progress).HasColumnName("progress");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TaskTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("task_title");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Pid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_task_project");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
