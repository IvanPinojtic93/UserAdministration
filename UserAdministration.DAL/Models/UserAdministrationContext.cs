using Microsoft.EntityFrameworkCore;


namespace UserAdministration.DAL.Models
{
    public class UserAdministrationContext : DbContext
    {

        public UserAdministrationContext(DbContextOptions<UserAdministrationContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<History> Histories { get; set; } = null!;
    }
}
