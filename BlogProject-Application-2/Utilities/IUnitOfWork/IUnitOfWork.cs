using BlogProject_Application_2.IRepositories;
using BlogProject_Application_2.Services.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Application_2.Utilities.IUnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        IApplicationUserRepo ApplicationUserRepo { get; }
        IArticleRepo ArticleRepo { get; }
        ICategoryRepo CategoryRepo { get; }
        ICommentRepo CommentRepo { get; }

        

        Task<int> SaveAsync();
    }
}
