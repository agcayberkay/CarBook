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

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudsHandlers
{
    public class GetTagCloudsQueryHandler : IRequestHandler<GetTagCloudsQuery, List<GetTagCloudsQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudsQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudsQueryResult>> Handle(GetTagCloudsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTagCloudsQueryResult
            {    
                BlogId = x.BlogId,
                Title = x.Title,
                TagCloudId = x.TagCloudId
            }).ToList();
        }
    }
}
