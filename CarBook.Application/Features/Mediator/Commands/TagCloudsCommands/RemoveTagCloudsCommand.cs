using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudsCommands
{
    public class RemoveTagCloudsCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveTagCloudsCommand(int id)
        {
            Id = id;
        }
    }
}
