using CarBook.Application.Features.Mediator.Results.FeatureResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FeatureQuery
{
    public class GetFeatureQuery:IRequest<List<GetFeatureQueryResult>>
    {

    }
}
