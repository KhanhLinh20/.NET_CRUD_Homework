using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Employee.Models;

public partial class HomeworkContext : DbContext
{
    public HomeworkContext()
    {
    }

    public HomeworkContext(DbContextOptions<HomeworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeTable> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:MyConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83FE5FE0DEB");

            entity.ToTable("employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
