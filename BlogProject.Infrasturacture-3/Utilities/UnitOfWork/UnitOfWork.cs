using BlogProject.Infrasturacture_3.Contexts;
using BlogProject.Infrasturacture_3.Repositories;
using BlogProject_Application_2.IRepositories;
using BlogProject_Application_2.Services.IServices;
using BlogProject_Application_2.Utilities.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrasturacture_3.Utilities.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ApplicationUserRepo = new AppUserRepo(_context);
            ArticleRepo = new ArticleRepo(_context);
            CategoryRepo = new CategoryRepo(_context);
            CommentRepo = new CommentRepo(_context);
        }

        public IApplicationUserRepo ApplicationUserRepo { get; }
        public IArticleRepo ArticleRepo { get; }
        public ICategoryRepo CategoryRepo { get; }
        public ICommentRepo CommentRepo { get; }
       

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
