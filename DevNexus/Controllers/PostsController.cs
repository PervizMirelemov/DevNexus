using DevNexus.Application.Features.Posts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevNexus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostsController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreatePostCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, new { id });
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id) => Ok(new { Message = "GetById not implemented yet", Id = id });
}