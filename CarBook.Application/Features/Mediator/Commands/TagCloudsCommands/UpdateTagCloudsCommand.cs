using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudsCommands
{
    public class UpdateTagCloudsCommand:IRequest
    {
        public int TagCloudId { get; set; }
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
}
