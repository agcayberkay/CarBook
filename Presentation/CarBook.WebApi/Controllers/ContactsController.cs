using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _deleteContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        public ContactsController(CreateContactCommandHandler createContactCommandHandler,
            GetContactQueryHandler getContactQueryHandler,
            UpdateContactCommandHandler updateContactCommandHandler,
            RemoveContactCommandHandler deleteContactCommandHandler,
            GetContactByIdQueryHandler getContactByIdQueryHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _deleteContactCommandHandler = deleteContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var value = await _getContactQueryHandler.Handle();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("İletişim Eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _deleteContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("İletişim Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("İletişim Güncellendi.");

        }
    }
}
