using System.Data.Common;
using HealthyTracker.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.DAL.Contexts;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public virtual DbSet<Daily> Daily { get; set; } = null!;
    public virtual DbSet<NutritionGoal> NutritionGoal { get; set; } = null!;
    public virtual DbSet<Product> Product { get; set; } = null!;
    public virtual DbSet<Meal> Meal { get; set; } = null!;
    public virtual DbSet<User> User { get; set; } = null!;
    public virtual DbSet<UserRegistration> UserRegistrations { get; set; } = null!;
    
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        base.ConfigureConventions(builder);
    }
}