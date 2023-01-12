namespace FinanceTrackerAPI.Infrastructure.Entities;

public class Budget
{
    public string Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}
