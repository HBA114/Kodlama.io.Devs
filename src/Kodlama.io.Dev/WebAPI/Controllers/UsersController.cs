// using Application.Features.AppUsers.Commands.RegisterAppUser;
// using Application.Features.Users.Commands.LoginUser;
// using Core.Security.JWT;
// using Microsoft.AspNetCore.Mvc;

// namespace WebAPI.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class UsersController : BaseController
//     {
//         [HttpPost("register")]
//         public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
//         {
//             AccessToken accessToken = await Mediator.Send(registerUserCommand);
//             return Ok(accessToken);
//         }

//         [HttpPost("login")]
//         public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
//         {
//             AccessToken accessToken = await Mediator.Send(loginUserCommand);
//             return Ok(accessToken);
//         }
//     }
// }
