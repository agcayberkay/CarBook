using CarBook.Application.Features.Mediator.Queries.TagCloudsQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudsResults;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudsHandlers
{
    public class GetTagCloudsByBlogIdQueryHandler : IRequestHandler<GetTagCloudsByBlogIdQuery, 
        List<GetTagCloudsByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _tagCloudRepository;

        public GetTagCloudsByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public async Task<List<GetTagCloudsByBlogIdQueryResult>> Handle(GetTagCloudsByBlogIdQuery request,
            CancellationToken cancellationToken)
        {
            var values = _tagCloudRepository.GetTagCloudByBlogId(request.Id);
            return values.Select(x => new GetTagCloudsByBlogIdQueryResult
            {
                BlogId = x.BlogId,
                Title= x.Title,
                TagCloudId = x.TagCloudId
            }).ToList();

        }
    }
}
