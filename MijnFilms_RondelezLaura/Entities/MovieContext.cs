using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MijnFilms_RondelezLaura.Entities
{
    public partial class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
        {

        }

        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<MovieActor> MovieActor { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Data Source=KEZZIES-LAPTOP\SQLEXPRESS;Initial Catalog=MovieBase;Integrated Security=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreID)
                    .IsRequired();
                entity.Property(e => e.Description)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieID)
                    .IsRequired();
                entity.Property(e => e.Title)
                    .HasMaxLength(128)
                    .IsRequired();
                entity.Property(e => e.Year)
                    .IsRequired();
                entity.Property(e => e.GenreID)
                    .IsRequired();
                entity.Property(e => e.DirectorID)
                    .IsRequired();
                entity.Property(e => e.Stars)
                    .IsRequired();
                entity.Property(e => e.Description)
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.Property(e => e.MovieID)
                    .IsRequired();
                entity.Property(e => e.ActorID)
                    .IsRequired();
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonID)
                    .IsRequired();
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(128);
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(128);
            });
        }
    }
}
