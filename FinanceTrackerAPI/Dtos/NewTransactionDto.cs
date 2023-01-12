using FinanceTrackerAPI.Infrastructure.Enums;

namespace FinanceTrackerAPI.Dtos;

public class NewTransactionDto
{
    public decimal Amount { get; set; }
    public Category Category { get; set; }
    public DateTime Date { get; set; }
    public TransactionType Type { get; set; }
    public string UserId { get; set; }
    public string Note { get; set; }
}
