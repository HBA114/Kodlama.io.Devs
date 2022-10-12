using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserOperationClaimsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
    {
        CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetListByUserId([FromQuery] GetUserOperationClaimListByUserIdQuery getUserOperationClaimListByUserIdQuery)
    {
        GetListUserOperationClaimsModel result = await Mediator.Send(getUserOperationClaimListByUserIdQuery);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
    {
        GetByIdUserOperationClaimDto result = await Mediator.Send(updateUserOperationClaimCommand);
        return Ok(result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
    {
        GetByIdUserOperationClaimDto result = await Mediator.Send(deleteUserOperationClaimCommand);
        return Ok(result);
    }
}