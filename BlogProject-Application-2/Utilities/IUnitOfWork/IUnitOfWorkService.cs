using BlogProject_Application_2.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Application_2.Utilities.IUnitOfWork
{
    public interface IUnitOfWorkService
    {
        public IAppUserService AppUserService { get; }
        public IArticleService ArticleService { get; }
        public ICategoryService CategoryService { get; }
        public ICommentService CommentService { get; }
    }
}
