using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        { 
           var value = await _repository.GetAllAsync();
            return value.Select(x => new GetContactQueryResult
            {
                ContactId = x.ContactId,
                Name = x.Name,
                Email = x.Email,
                SendDate = x.SendDate,
                Message = x.Message,
                Subject = x.Subject
            }).ToList();
        }
    }
}
