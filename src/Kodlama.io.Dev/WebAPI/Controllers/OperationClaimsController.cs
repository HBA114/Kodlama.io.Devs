using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperationClaimsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
    {
        CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOperationClaimQuery getListOperationClaimQuery = new()
        {
            PageRequest = pageRequest
        };
        GetListOperationClaimModel result = await Mediator.Send(getListOperationClaimQuery);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
    {
        GetByIdOperationClaimDto result = await Mediator.Send(updateOperationClaimCommand);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteOperationClaimCommand deleteOperationClaimCommand)
    {
        GetByIdOperationClaimDto result = await Mediator.Send(deleteOperationClaimCommand);
        return Ok(result);
    }
}