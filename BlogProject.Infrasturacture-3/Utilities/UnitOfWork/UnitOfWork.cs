using BlogProject.Infrasturacture_3.Contexts;
using BlogProject_Application_2.IRepositories;
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

        public UnitOfWork(AppDbContext context, IApplicationUserRepo applicationUserRepo, IArticleRepo articleRepo, ICategoryRepo categoryRepo, ICommentRepo commentRepo)
        {
            _context = context;
            ApplicationUserRepo = applicationUserRepo;
            ArticleRepo = articleRepo;
            CategoryRepo = categoryRepo;
            CommentRepo = commentRepo;
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
