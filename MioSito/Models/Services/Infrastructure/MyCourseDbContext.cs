using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MioSito.Models.Entities;

namespace MioSito.Models.Services.Infrastructure
{
    public partial class MyCourseDbContext : DbContext
    {
        public MyCourseDbContext()
        {
        }

        public MyCourseDbContext(DbContextOptions<MyCourseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apples> Apples { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Lessons> Lessons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=superdatabaseditest.database.windows.net;Database=Superdatabase;User Id=SuperUser;Password=MarcoGraziottiRegna33;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apples>(entity =>
            {
                entity.Property(e => e.Color).HasColumnType("text");

                entity.Property(e => e.Origin).HasColumnType("text");

                entity.Property(e => e.Variety).HasColumnType("text");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.ToTable("Courses");
                entity.HasKey(course => course.Id);

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnType("text");
            #region
            //entity.Property(e => e.CurrentPriceAmount)
            //    .HasColumnName("CurrentPrice_Amount")
            //    .HasColumnType("money");

            //entity.Property(e => e.CurrentPriceCurrency)
            //    .IsRequired()
            //    .HasColumnName("CurrentPrice_Currency")
            //    .HasColumnType("text")
            //    .HasDefaultValueSql("('EUR')");
            #endregion

            entity.OwnsOne(course => course.CurrentPrice, builder => {
                    builder.Property(money => money.Currency)
                    .HasConversion<string>()
                    .HasColumnName("CurrentPrice_Currency");
                    builder.Property(money => money.Amount).HasColumnName("CurrentPrice_Amount");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Email).HasColumnType("text");
            #region
                //entity.Property(e => e.FullPriceAmount)
                //    .HasColumnName("FullPrice_Amount")
                //    .HasColumnType("money");

                //entity.Property(e => e.FullPriceCurrency)
                //    .IsRequired()
                //    .HasColumnName("FullPrice_Currency")
                //    .HasColumnType("text")
                //    .HasDefaultValueSql("('EUR')");
                #endregion
                entity.OwnsOne(course => course.FullPrice, builder => {
                        builder.Property(money => money.Currency).HasConversion<string>();

                entity.Property(e => e.ImagePath).HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasMany(course => course.Lessons)
                .WithOne(lesson => lesson.Course)
                .HasForeignKey(lesson => lesson.CourseId);
            });

            modelBuilder.Entity<Lessons>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Duration)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('00:00:00')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Lessons__CourseI__5070F446");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
