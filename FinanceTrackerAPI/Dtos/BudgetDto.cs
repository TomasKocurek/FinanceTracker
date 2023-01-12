namespace FinanceTrackerAPI.Dtos;

public class BudgetDto
{
    public string Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string UserId { get; set; }
    public decimal Remaining { get; set; }

    public BudgetDto(string id, decimal amount, DateTime startDate, DateTime endDate, string userId)
    {
        Id = id;
        Amount = amount;
        StartDate = startDate;
        EndDate = endDate;
        UserId = userId;
    }

    public BudgetDto(string id, decimal amount, DateTime startDate, DateTime endDate, string userId, decimal remaining) : this(id, amount, startDate, endDate, userId)
    {
        Remaining = remaining;
    }
}