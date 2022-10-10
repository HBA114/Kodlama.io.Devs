using Application.Features.GithubLinks.Commands.DeleteGithubLink;
using Application.Features.GithubLinks.Commands.UpdateGithubLink;
using Application.Features.GithubLinks.Dtos;
using Application.Features.GithubLinks.Commands.CreateGithubLink;
using Application.Features.GithubLinks.Models;
using Application.Features.GithubLinks.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GithubLinksController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGithubLinkCommand createGithubLinkCommand)
    {
        CreatedGithubLinkDto result = await Mediator.Send(createGithubLinkCommand);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Getlist([FromQuery] PageRequest pageRequest)
    {
        GetListGithubLinkQuery getListGithubLinkQuery = new() { PageRequest = pageRequest };
        GithubLinkListModel result = await Mediator.Send(getListGithubLinkQuery);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGithubLinkCommand updateGithubLinkCommand)
    {
        UpdateGithubLinkDto result = await Mediator.Send(updateGithubLinkCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteGithubLinkCommand deleteGithubLinkCommand)
    {
        GithubLinkGetbyIdDto result = await Mediator.Send(deleteGithubLinkCommand);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdGithubLinkQuery getByIdGithubLinkQuery)
    {
        GithubLinkGetbyIdDto result = await Mediator.Send(getByIdGithubLinkQuery);
        return Ok(result);
    }
}