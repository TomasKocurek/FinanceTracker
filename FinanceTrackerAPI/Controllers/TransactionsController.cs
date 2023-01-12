using FinanceTrackerAPI.Dtos;
using FinanceTrackerAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackerAPI.Controllers;

[Route("api/[controller]")]
[ApiController, Authorize]
public class TransactionsController : ControllerBase
{
    private readonly TransactionsRepository _transactionsRepository;

    public TransactionsController(TransactionsRepository transactionsRepository)
    {
        _transactionsRepository = transactionsRepository;
    }

    [HttpGet("by-user/{id}")]
    public async Task<ActionResult<List<TransactionDto>>> GetAllTransactionsByUserId([FromRoute] string id)
    {
        return Ok(_transactionsRepository.GetAllTransactionsByUserId(id));
    }

    [HttpPost]
    public async Task<ActionResult> AddNewTransaction([FromBody] NewTransactionDto dto)
    {
        await _transactionsRepository.AddNewTransaction(dto);
        return Ok();
    }

    [HttpGet("by-user/{id}/categories")]
    public async Task<ActionResult> GetTransactionCategoriesByUserId([FromRoute] string id)
    {
        return Ok(_transactionsRepository.GetTransactionCategoriesByUserId(id));
    }

    [HttpGet("by-user/{id}/days")]
    public async Task<ActionResult> GetDaySummariesByUserId([FromRoute] string id)
    {
        return Ok(_transactionsRepository.GetDaySummariesByUserId(id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTransactionById([FromRoute] string id)
    {
        await _transactionsRepository.DeleteTransactionById(id);
        return Ok();
    }
}
