using FinanceTrackerAPI.Dtos;
using FinanceTrackerAPI.Infrastructure.Entities;
using FinanceTrackerAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Repositories;

public class TransactionsRepository
{
    private readonly FinanceDbContext _context;

    public TransactionsRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public List<TransactionDto> GetAllTransactionsByUserId(string id)
    {
        var transactions = _context.Transactions.Where(t => t.UserId == id).ToList();
        return transactions.ConvertAll(t => new TransactionDto(t.Id, t.Amount, t.Date, t.Category, t.Type, t.UserId, t.Note));
    }

    public List<CategorySummaryDto> GetTransactionCategoriesByUserId(string id)
    {
        var transactions = _context.Transactions.Where(t => t.UserId == id).ToList();
        var groups = transactions.GroupBy(t => t.Category).ToList();
        return groups.ConvertAll(g => new CategorySummaryDto(g.Key, g.Sum(i => i.Amount)));
    }

    public List<DaySummaryDto> GetDaySummariesByUserId(string id)
    {
        var transactions = _context.Transactions.Where(t => t.UserId == id).ToList();
        var groups = transactions.GroupBy(t => t.Date.Date).ToList();
        return groups.ConvertAll(g => new DaySummaryDto(g.Key, g.Sum(i => i.Amount)));
    }

    public async Task AddNewTransaction(NewTransactionDto newTransaction)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == newTransaction.UserId);
        Transaction transaction = new() { Id = Guid.NewGuid().ToString(), Amount = newTransaction.Amount, Category = newTransaction.Category, Date = newTransaction.Date, Type = newTransaction.Type, User = user, Note = newTransaction.Note };
        _context.Add(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTransactionById(string id)
    {
        var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);

        if (transaction == null) return;
        _context.Remove(transaction);
        await _context.SaveChangesAsync();
    }
}
