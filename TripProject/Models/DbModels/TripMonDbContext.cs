using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TripProject.Models.DbModels
{
    public partial class TripMonDbContext : DbContext
    {
        public TripMonDbContext()
        {
        }

        public TripMonDbContext(DbContextOptions<TripMonDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Certificate> Certificate { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Citytype> Citytype { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=652350vf;database=tripmondb", x => x.ServerVersion("8.0.20-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("certificate");

                entity.HasIndex(e => e.CityId)
                    .HasName("city_id");

                entity.HasIndex(e => e.WorkerId)
                    .HasName("worker_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Beginning)
                    .HasColumnName("beginning")
                    .HasColumnType("date");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.Ending)
                    .HasColumnName("ending")
                    .HasColumnType("date");

                entity.Property(e => e.WorkerId).HasColumnName("worker_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Certificate)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("certificate_ibfk_2");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Certificate)
                    .HasForeignKey(d => d.WorkerId)
                    .HasConstraintName("certificate_ibfk_1");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.TypeId)
                    .HasName("type_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("char(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TicketPrice).HasColumnName("ticket_price");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("city_ibfk_1");
            });

            modelBuilder.Entity<Citytype>(entity =>
            {
                entity.ToTable("citytype");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccommodationPrice).HasColumnName("accommodation_price");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("char(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("worker");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasColumnName("department")
                    .HasColumnType("char(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("char(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("char(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
