
using CarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudsResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudsByIdQuery, GetTagCloudsByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudsByIdQueryResult> Handle(GetTagCloudsByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetTagCloudsByIdQueryResult
            {
                TagCloudId = value.TagCloudId,
                Title = value.Title,
                BlogId = value.BlogId

            };

        }
    }
}
