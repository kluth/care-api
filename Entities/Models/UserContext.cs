using Microsoft.EntityFrameworkCore;
namespace CareApi.Entities.Models;

public class UserContext : DbContext {
    public UserContext(DbContextOptions<UserContext> options) : base(options) {

    }

    public DbSet<User> Users { get; set; } = null!;
}
