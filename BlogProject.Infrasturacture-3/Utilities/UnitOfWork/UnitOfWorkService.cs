using AutoMapper;
using BlogProject_Application_2.Services;
using BlogProject_Application_2.Services.IServices;
using BlogProject_Application_2.Utilities.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrasturacture_3.Utilities.UnitOfWork
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnitOfWorkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            AppUserService = new AppUserService(_unitOfWork, _mapper);
            ArticleService = new ArticleService(_unitOfWork, _mapper);
            CategoryService = new CategoryService(_unitOfWork, _mapper);
            CommentService = new CommentService(_unitOfWork, _mapper);
        }

        public IAppUserService AppUserService { get; }
        public IArticleService ArticleService { get; }
        public ICategoryService CategoryService { get; }
        public ICommentService CommentService { get; }
    }
}
