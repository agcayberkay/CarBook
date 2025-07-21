using CarBook.Application.Features.Mediator.Commands.TagCloudsCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudsHandlers
{
    public class UpdateTagCloudsCommandHandler : IRequestHandler<UpdateTagCloudsCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudsCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCloudsCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TagCloudId);
            value.Title = request.Title;
            value.BlogId = request.BlogId;
            await _repository.UpdateAsync(value);

        }
    }
}
