using CarBook.Application.Features.Mediator.Commands.TagCloudsCommands;
using CarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTagClouds()
        {
            var value = await _mediator.Send(new GetTagCloudsQuery());
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagClouds(CreateTagCloudsCommand command)
        {
            await _mediator.Send(command);
            return Ok("Bulut Etiketi başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTagClouds(UpdateTagCloudsCommand command)
        {
            await _mediator.Send(command);
            return Ok("Bulut Etiketi başarıyla güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTagClouds(int id)
        {
            await _mediator.Send(new RemoveTagCloudsCommand(id));
            return Ok("Bulut Etiketi başarıyla silindi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloudsById(int id)
        {
            var result = await _mediator.Send(new GetTagCloudsByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("GetTagCloudsByBlogId")]
        public async Task<IActionResult> GetTagCloudsByBlogId(int blogId)
        {
            var result = await _mediator.Send(new GetTagCloudsByBlogIdQuery(blogId));
            return Ok(result);
        }
    }
}
