using CarBook.Application.Features.CQRS.Commands.BannerCommand;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _deleteBannerCommandHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        public BannersController(CreateBannerCommandHandler createBannerCommandHandler,
            GetBannerQueryHandler getBannerQueryHandler,
            UpdateBannerCommandHandler updateBannerCommandHandler,
            RemoveBannerCommandHandler deleteBannerCommandHandler,
            GetBannerByIdQueryHandler getBannerByIdQueryHandler)
        {
            _createBannerCommandHandler = createBannerCommandHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _deleteBannerCommandHandler = deleteBannerCommandHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var value = await _getBannerQueryHandler.Handle();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Banner Bilgisi Eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _deleteBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner Bilgisi Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Banner Bilgisi Güncellendi.");

        }

    }
}
