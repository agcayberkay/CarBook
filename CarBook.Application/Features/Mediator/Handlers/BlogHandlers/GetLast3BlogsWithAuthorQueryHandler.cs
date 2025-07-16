using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorQuery, List<GetLast3BlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogsWithAuthorQueryResult>> Handle(GetLast3BlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values= _repository.GetLast3BlogsWithAuthor();
            return values.Select(b => new GetLast3BlogsWithAuthorQueryResult
            {   AuthorId= b.AuthorId,
                AuthorName = b.Author.Name,
                CategoryId = b.CategoryId,
                BlogId = b.BlogId,
                Title = b.Title,
                CreatedDate = b.CreatedDate,
                CoverImageUrl = b.CoverImageUrl
            }).ToList();
        }
    }
}
