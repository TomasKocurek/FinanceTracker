using FinanceTrackerAPI.Dtos;
using FinanceTrackerAPI.Infrastructure.Entities;
using FinanceTrackerAPI.Infrastructure.Enums;
using FinanceTrackerAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Repositories;

public class BudgetsRepository
{
    private readonly FinanceDbContext _context;

    public BudgetsRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public List<BudgetDto> GetBudgesByUserId(string userId)
    {
        var budgets = _context.Budgets.Where(b => b.UserId == userId).ToList();
        List<BudgetDto> budgetsDto = new();

        foreach (var budget in budgets)
        {
            var transactions = _context.Transactions.Where(t => t.Date.Date >= budget.StartDate.Date && t.Date.Date <= budget.EndDate.Date && t.Type == TransactionType.Expense);
            var amount = transactions.Sum(t => t.Amount);
            var percentage = 100 - ((100 * amount) / budget.Amount);
            budgetsDto.Add(new(budget.Id, budget.Amount, budget.StartDate, budget.EndDate, budget.UserId, (int)percentage));
        }

        return budgetsDto;
    }

    public async Task AddNewBudget(NewBudgetDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == dto.UserId);
        Budget budget = new() { Id = Guid.NewGuid().ToString(), Amount = dto.Amount, StartDate = dto.StartDate, EndDate = dto.EndDate, User = user };
        _context.Add(budget);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBudgetById(string id)
    {
        var budget = await _context.Budgets.FirstOrDefaultAsync(b => b.Id == id);
        if (budget is null) return;
        _context.Remove(budget);
        await _context.SaveChangesAsync();
    }
}
