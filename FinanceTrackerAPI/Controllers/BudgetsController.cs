using FinanceTrackerAPI.Dtos;
using FinanceTrackerAPI.Infrastructure.Entities;
using FinanceTrackerAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.Controllers;

[Route("api/[controller]")]
[ApiController, Authorize]
public class BudgetsController : ControllerBase
{
    private readonly BudgetsRepository _budgetsRepository;

    public BudgetsController(BudgetsRepository budgetsRepositry)
    {
        _budgetsRepository = budgetsRepositry;
    }

    [HttpGet("by-user/{id}")]
    public async Task<ActionResult<List<Budget>>> GetBudgetsByUserId([FromRoute] string id)
    {
        return Ok(_budgetsRepository.GetBudgesByUserId(id));
    }

    [HttpPost]
    public async Task<ActionResult> AddNewBudget([FromBody] NewBudgetDto dto)
    {
        await _budgetsRepository.AddNewBudget(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBudgetById([FromRoute] string id)
    {
        await _budgetsRepository.DeleteBudgetById(id);
        return Ok();
    }
}
