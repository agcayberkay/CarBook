using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogsWithAuthor()
        {
            var values = _context.Blogs.Include(b => b.Author).Include(b => b.Category)
                .OrderByDescending(b => b.BlogId)
                .ToList();
            return values;
        }

        public List<Blog> GetBlogByAuthorId(int id)
        {
            var values = _context.Blogs.Include(b => b.Author)
                .Where(b => b.BlogId == id)
                .ToList();
            return values;
        }

        public List<Blog> GetLast3BlogsWithAuthor()
        {
            var values= _context.Blogs.Include(b => b.Author)
                .OrderByDescending(b => b.BlogId)
                .Take(3)
                .ToList();
            return values;
        }
    }
}
