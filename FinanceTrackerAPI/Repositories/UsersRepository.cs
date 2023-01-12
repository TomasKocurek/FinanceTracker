using FinanceTrackerAPI.Infrastructure.Entities;
using FinanceTrackerAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Repositories;

public class UsersRepository
{
    private readonly FinanceDbContext _context;

    public UsersRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public Task CreateUser(User user)
    {
        _context.Users.Add(user);
        return _context.SaveChangesAsync();
    }

    public Task<User?> GetUserByEmail(string email)
    {
        return _context.Users
            .FirstOrDefaultAsync(u => string.Equals(u.Email, email));
    }
}
