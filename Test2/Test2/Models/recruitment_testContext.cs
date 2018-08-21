using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test2.Models
{
    public partial class recruitment_testContext : DbContext
    {
        //public recruitment_testContext()
        //{
        //}

        public recruitment_testContext(DbContextOptions<recruitment_testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Interview> Interview { get; set; }
        public virtual DbSet<Recruiter> Recruiter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=recruitment_test;User=root;Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Interview>(entity =>
            {
                entity.ToTable("interview");

                entity.HasIndex(e => e.IdRecruiter)
                    .HasName("id_recruiter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdRecruiter)
                    .HasColumnName("id_recruiter")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(20)");

                entity.HasOne(d => d.IdRecruiterNavigation)
                    .WithMany(p => p.Interview)
                    .HasForeignKey(d => d.IdRecruiter)
                    .HasConstraintName("interview_ibfk_1");
            });

            modelBuilder.Entity<Recruiter>(entity =>
            {
                entity.ToTable("recruiter");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)");
            });
        }
    }
}
