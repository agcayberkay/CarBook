using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _carBookContext;

        public CommentRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public void Add(Comment entity)
        {
            _carBookContext.Add(entity);
            _carBookContext.SaveChanges();
        }

        public void Delete(Comment entity)
        {
            
            _carBookContext.Comments.Remove(entity);
            _carBookContext.SaveChanges();

        }

        public List<Comment> GetAll()
        {
            return _carBookContext.Comments.Select(x => new Comment
            {
                CommentId = x.CommentId,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                BlogId = x.BlogId
            }).ToList();
        }

        public Comment GetById(int id)
        {
            return _carBookContext.Comments.Find(id);
        }

        public void Update(Comment entity)
        {
            _carBookContext.Comments.Update(entity);
            _carBookContext.SaveChanges();
        }
    }
}
