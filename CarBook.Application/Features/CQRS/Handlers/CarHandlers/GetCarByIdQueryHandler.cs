using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Queries.CaarQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                CarId = values.CarId,
                BrandId = values.BrandId,
                Model = values.Model,
                CoverImageUrl = values.CoverImageUrl,
                BigImageUrl = values.BigImageUrl,
                Fuel = values.Fuel,
                Km = values.Km,
                Seat = values.Seat,
                Luggage = values.Luggage,
                Transmission = values.Transmission
            };
        }
    }
}
