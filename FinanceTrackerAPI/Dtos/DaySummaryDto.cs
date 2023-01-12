namespace FinanceTrackerAPI.Dtos;

public class DaySummaryDto
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }

    public DaySummaryDto(DateTime date, decimal amount)
    {
        Date = date;
        Amount = amount;
    }
}
