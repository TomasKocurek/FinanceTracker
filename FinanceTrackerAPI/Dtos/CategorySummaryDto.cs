using FinanceTrackerAPI.Infrastructure.Enums;

namespace FinanceTrackerAPI.Dtos;

public class CategorySummaryDto
{
    public Category Category { get; set; }
    public decimal Amount { get; set; }

    public CategorySummaryDto(Category category, decimal amount)
    {
        Category = category;
        Amount = amount;
    }
}
