using BlogProject.Core.DomainModels.Models;
using BlogProject.Infrasturacture_3.Contexts;
using BlogProject.Infrasturacture_3.Repositories.BaseRepos;
using BlogProject_Application_2.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrasturacture_3.Repositories
{
    public class CommentRepo : BaseRepo<Comment>, ICommentRepo
    {
        private readonly AppDbContext _context;
        public CommentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetAllByArticleIdAsync(string Id)
        {
            return await _context.Comments.Where(x => x.ArticleId == Id).ToListAsync();

        }
    }
}
