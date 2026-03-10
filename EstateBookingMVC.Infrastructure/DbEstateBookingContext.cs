using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EstateBookingDomain.Model;
using Type = EstateBookingDomain.Model.Type; // помилки з типами
namespace EstateBookingInfrastructure;

public partial class DbEstateBookingContext : DbContext
{
    public DbEstateBookingContext()
    {
    }

    public DbEstateBookingContext(DbContextOptions<DbEstateBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Estate> Estates { get; set; }

    public virtual DbSet<EstateActivity> EstateActivities { get; set; }

    public virtual DbSet<EstateAmenity> EstateAmenities { get; set; }

    public virtual DbSet<EstateDetail> EstateDetails { get; set; }

    public virtual DbSet<EstatePhoto> EstatePhotos { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Saved> Saveds { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EcoSadyba;Username=yulia;Password=pass;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("activities_pkey");

            entity.ToTable("activities");

            entity.HasIndex(e => e.Name, "activities_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("amenities_pkey");

            entity.ToTable("amenities");

            entity.HasIndex(e => e.Name, "amenities_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("booking_pkey");

            entity.ToTable("booking");

            entity.HasIndex(e => e.EstateId, "booking_estate_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CheckIn).HasColumnName("check_in");
            entity.Property(e => e.CheckOut).HasColumnName("check_out");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EstateId).HasColumnName("estate_id");
            entity.Property(e => e.FixedPrice)
                .HasPrecision(10, 2)
                .HasColumnName("fixed_price");
            entity.Property(e => e.GuestComment).HasColumnName("guest_comment");
            entity.Property(e => e.GuestsCount).HasColumnName("guests_count");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Estate).WithOne(p => p.Booking)
                .HasForeignKey<Booking>(d => d.EstateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_booking_estate");

            entity.HasOne(d => d.Status).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_booking_status");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_booking_user");
        });

        modelBuilder.Entity<Estate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("estate_pkey");

            entity.ToTable("estate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Latitude)
                .HasPrecision(9, 6)
                .HasColumnName("latitude");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Longitude)
                .HasPrecision(9, 6)
                .HasColumnName("longitude");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PricePerNight)
                .HasPrecision(10, 2)
                .HasColumnName("price_per_night");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Admin).WithMany(p => p.Estates)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estate_admin");

            entity.HasOne(d => d.Location).WithMany(p => p.Estates)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estate_location");

            entity.HasOne(d => d.Type).WithMany(p => p.Estates)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estate_type");
        });

        modelBuilder.Entity<EstateActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("estate_activities_pkey");

            entity.ToTable("estate_activities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.EstateId).HasColumnName("estate_id");

            entity.HasOne(d => d.Activity).WithMany(p => p.EstateActivities)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("estate_activities_activity_id_fkey");

            entity.HasOne(d => d.Estate).WithMany(p => p.EstateActivities)
                .HasForeignKey(d => d.EstateId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("estate_activities_estate_id_fkey");
        });

        modelBuilder.Entity<EstateAmenity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("estate_amenities_pkey");

            entity.ToTable("estate_amenities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmenitiesId).HasColumnName("amenities_id");
            entity.Property(e => e.EstateId).HasColumnName("estate_id");

            entity.HasOne(d => d.Amenities).WithMany(p => p.EstateAmenities)
                .HasForeignKey(d => d.AmenitiesId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("estate_amenities_amenities_id_fkey");

            entity.HasOne(d => d.Estate).WithMany(p => p.EstateAmenities)
                .HasForeignKey(d => d.EstateId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("estate_amenities_estate_id_fkey");
        });

        modelBuilder.Entity<EstateDetail>(entity =>
        {
            entity.HasKey(e => e.EstateId).HasName("estate_details_pkey");

            entity.ToTable("estate_details");

            entity.Property(e => e.EstateId)
                .ValueGeneratedNever()
                .HasColumnName("estate_id");
            entity.Property(e => e.BathroomsCount).HasColumnName("bathrooms_count");
            entity.Property(e => e.BedsCount).HasColumnName("beds_count");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.GuestsCount).HasColumnName("guests_count");
            entity.Property(e => e.RoomsCount).HasColumnName("rooms_count");

            entity.HasOne(d => d.Estate).WithOne(p => p.EstateDetail)
                .HasForeignKey<EstateDetail>(d => d.EstateId)
                .HasConstraintName("estate_details_estate_id_fkey");
        });

        modelBuilder.Entity<EstatePhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("estate_photos_pkey");

            entity.ToTable("estate_photos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EstateId).HasColumnName("estate_id");
            entity.Property(e => e.IsMain)
                .HasDefaultValue(false)
                .HasColumnName("is_main");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");

            entity.HasOne(d => d.Estate).WithMany(p => p.EstatePhotos)
                .HasForeignKey(d => d.EstateId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("estate_photos_estate_id_fkey");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("location_pkey");

            entity.ToTable("location");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .HasColumnName("district");
            entity.Property(e => e.Region)
                .HasMaxLength(100)
                .HasColumnName("region");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reviews_pkey");

            entity.ToTable("reviews");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EstateId).HasColumnName("estate_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Estate).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.EstateId)
                .HasConstraintName("fk_reviews_estate");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_reviews_user");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role");

            entity.HasIndex(e => e.Name, "role_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Saved>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("saved_pkey");

            entity.ToTable("saved");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EstateId).HasColumnName("estate_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Estate).WithMany(p => p.Saveds)
                .HasForeignKey(d => d.EstateId)
                .HasConstraintName("fk_saved_estate");

            entity.HasOne(d => d.User).WithMany(p => p.Saveds)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_saved_user");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_pkey");

            entity.ToTable("status");

            entity.HasIndex(e => e.Name, "status_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("type_pkey");

            entity.ToTable("type");

            entity.HasIndex(e => e.Name, "type_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "User_email_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.IsBlocked)
                .HasDefaultValue(false)
                .HasColumnName("is_blocked");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
