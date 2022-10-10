using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaimCommand;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserOperationClaimsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetListByUserId([FromQuery] GetUserOperationClaimListByUserIdQuery getUserOperationClaimListByUserIdQuery)
    {
        GetListUserOperationClaimsModel result = await Mediator.Send(getUserOperationClaimListByUserIdQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
    {
        CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
        return Ok(result);
    }
}