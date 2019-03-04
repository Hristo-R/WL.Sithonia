namespace WL.Sithonia.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WL.Sithonia.Models;

    public class SithoniaDbContext : IdentityDbContext<User>
    {
        public SithoniaDbContext(DbContextOptions<SithoniaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}