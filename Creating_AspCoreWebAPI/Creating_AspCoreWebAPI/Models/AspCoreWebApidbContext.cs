using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Creating_AspCoreWebAPI.Models;

public partial class AspCoreWebApidbContext : DbContext
{
    public AspCoreWebApidbContext()
    {

    }

    public AspCoreWebApidbContext(DbContextOptions<AspCoreWebApidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Standard)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StudentGender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
