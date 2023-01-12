using FinanceTrackerAPI.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Infrastructure.Persistence;

public class FinanceDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Budget> Budgets { get; set; }

    public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
    {
    }
}
