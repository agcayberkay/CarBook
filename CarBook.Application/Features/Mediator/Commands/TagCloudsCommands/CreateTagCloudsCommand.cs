using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudsCommands
{
    public class CreateTagCloudsCommand:IRequest
    {
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
}
