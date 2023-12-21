using System.Data.Common;
using HealthyTracker.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyTracker.DAL.Contexts;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public virtual DbSet<CaloriesConsumed> CaloriesConsumed { get; set; } = null!;
    public virtual DbSet<CalorieGoal> CalorieGoal { get; set; } = null!;
    public virtual DbSet<Food> Food { get; set; } = null!;
    public virtual DbSet<Meal> Meal { get; set; } = null!;
    public virtual DbSet<Nutrition> Nutrition { get; set; } = null!;
    public virtual DbSet<User> User { get; set; } = null!;

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        base.ConfigureConventions(builder);
    }
}