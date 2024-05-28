using DcHRally.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RallyBaneTest.Models;

namespace DcHRally.Areas.Identity.Data;

public class DcHRallyIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public DcHRallyIdentityDbContext(DbContextOptions<DcHRallyIdentityDbContext> options)
        : base(options)
    {
    }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Category> Categories { get; set; }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //    builder.Entity<Tracks>()
    //        .HasOne(t => t.User)
    //        .WithMany(u => u.Tracks);

    //    builder.Entity<Category>()
    //        .ToTable("Categories");
    //}
}
