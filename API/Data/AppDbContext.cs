using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data;

// Creates all the database tables

public class AppDbContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
{
    public DbSet<Member> Members { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<MemberLike> Likes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Connection> Connections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Below is seeding data for the roles
        modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole
                {
                    Id = "member-id",
                    Name = "Member",
                    NormalizedName = "MEMBER",
                    ConcurrencyStamp = "3b844e8c-018b-401b-bce0-bc29fe94cb6a"
                },
                new IdentityRole
                {
                    Id = "moderator-id",
                    Name = "Moderator",
                    NormalizedName = "MODERATOR",
                    ConcurrencyStamp = "b2da2c1a-9a08-4163-8dd6-3bb9852a533d"
                },
                new IdentityRole
                {
                    Id = "admin-id",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "68bdb2a1-14c3-48ea-b708-bd9d358e2b94"
                }
            );

        modelBuilder.Entity<Message>()
        .HasOne(x => x.Recipient)
        .WithMany(x => x.MessagesReceived)
        .HasForeignKey(x => x.RecipientId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Message>()
            .HasOne(x => x.Sender)
            .WithMany(x => x.MessagesSent)
            .HasForeignKey(x => x.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        // Below sets the primary key for the table
        modelBuilder.Entity<MemberLike>()
            .HasKey(x => new {x.SourceMemberId, x.TargetMemberId});

        // One source member can have many liked members
        modelBuilder.Entity<MemberLike>()
            .HasOne(s => s.SourceMember)
            .WithMany(t => t.LikedMembers)
            .HasForeignKey(s => s.SourceMemberId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MemberLike>()
            .HasOne(s => s.TargetMember)
            .WithMany(t => t.LikedByMembers)
            .HasForeignKey(s => s.TargetMemberId)
            .OnDelete(DeleteBehavior.NoAction);

        var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
            v => v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
        );

        var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
            v => v.HasValue ? v.Value.ToUniversalTime() : null,
            v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : null
        );

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(dateTimeConverter);
                }
                else if (property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(nullableDateTimeConverter);
                }
            }
        }
    }
}
