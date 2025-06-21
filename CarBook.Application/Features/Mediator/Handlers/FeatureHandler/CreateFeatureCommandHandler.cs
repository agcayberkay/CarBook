using CarBook.Application.Features.Mediator.Commands.FeatureCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandler
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {

        private readonly IRepository<Feature> _repository;
        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
           await _repository.CrateAsync(new Feature
           {
               Name = request.Name
           });
        }
    }
}
