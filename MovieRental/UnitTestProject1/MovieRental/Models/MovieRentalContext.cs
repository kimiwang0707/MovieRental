using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MovieRental.Models
{
    public partial class MovieRentalContext : DbContext
    {
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Directors> Directors { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }

        public MovieRentalContext(DbContextOptions<MovieRentalContext> options) : 
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Directors>(entity =>
            {
                entity.HasKey(e => e.Did);

                entity.Property(e => e.Did).HasColumnName("DId");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Borrowers)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK_Borrower");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieDirector");
            });
        }
    }
}
