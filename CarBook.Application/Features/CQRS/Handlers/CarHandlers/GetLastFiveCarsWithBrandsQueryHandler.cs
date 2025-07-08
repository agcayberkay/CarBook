using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLastFiveCarsWithBrandsQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLastFiveCarsWithBrandsQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }  

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var value = _repository.GetLastFiveCarsWithBrands();
            return value.Select(x => new GetCarWithBrandQueryResult
            {
                CarId = x.CarId,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name,
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
