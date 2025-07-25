using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var comments = _commentRepository.GetAll();
            return Ok(comments);
        }

        [HttpPost]
        public IActionResult AddCommand(Comment comment)
        {
            _commentRepository.Add(comment);
            return Ok("Yorum başarıyla yapıldı.");
        }

        [HttpDelete]
        public IActionResult DeleteCommand(int id)
        {
            var comment = _commentRepository.GetById(id);
            _commentRepository.Delete(comment);

            return Ok("Yorum başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult UpdateCommand(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Yorum başarıyla güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdComment(int id)
        {
            _commentRepository.GetById(id);
            return Ok("Yorum başarıyla getirildi." + id);
        }
    }
}
