using FinanceTrackerAPI.Infrastructure.Enums;

namespace FinanceTrackerAPI.Dtos;

public class TransactionDto
{
    public string Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public Category Category { get; set; }
    public TransactionType Type { get; set; }
    public string UserId { get; set; }
    public string Note { get; set; } = string.Empty;

    public TransactionDto(string id, decimal amount, DateTime date, Category category, TransactionType type, string userId, string note)
    {
        Id = id;
        Amount = amount;
        Date = date;
        Category = category;
        Type = type;
        UserId = userId;
        Note = note;
    }
}
