namespace FinanceTrackerAPI.Dtos;

public class NewBudgetDto
{
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string UserId { get; set; }
}
