using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

// Users is the table name

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
}
