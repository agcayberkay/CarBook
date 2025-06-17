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
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var value = await _repository.GetAllAsync();
           return value.Select(x => new GetCarQueryResult
           {
               CarId = x.CarId,
               BrandId = x.BrandId,
               Model = x.Model,
               CoverImageUrl = x.CoverImageUrl,
               BigImageUrl = x.BigImageUrl,
               Fuel = x.Fuel,
               Km = x.Km,
               Seat = x.Seat,
               Luggage = x.Luggage,
               Transmission = x.Transmission
           }).ToList();
    }
    }
}
