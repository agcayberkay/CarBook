using CarBook.Application.Features.Mediator.Commands.TagCloudsCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class CreateTagCloudsCommandHandler : IRequestHandler<CreateTagCloudsCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public CreateTagCloudsCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTagCloudsCommand request, CancellationToken cancellationToken)
        {
            await _repository.CrateAsync(new TagCloud
            {  
                BlogId = request.BlogId,
                Title = request.Title

            });
        }
    }
}
