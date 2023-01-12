using FinanceTrackerAPI.Infrastructure.Enums;

namespace FinanceTrackerAPI.Infrastructure.Entities;

public class Transaction
{
    public string Id { get; set; }
    public TransactionType Type { get; set; }
    public User User { get; set; }
    public string UserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public Category Category { get; set; }
    public string Note { get; set; }
}
