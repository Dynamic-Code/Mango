using Mango.Services.AuthApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.AuthApi.Data
{
    //In order to using Identity for auth, we will have ti implement form IdentityDbContet<IdentityUser>
    // applicationusers to add more col. to capture in Identity
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //added new table to capture new Name data within Identity
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        // Seeding data in our db tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}