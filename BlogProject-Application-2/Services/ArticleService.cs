using AutoMapper;
using BlogProject.Core.DomainModels.Enums;
using BlogProject.Core.DomainModels.Models;
using BlogProject_Application_2.DTOs;
using BlogProject_Application_2.Services.IServices;
using BlogProject_Application_2.Utilities.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Application_2.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int CreateArticle(ArticleDTO articleDTO)
        {
            var article = mapper.Map<Article>(articleDTO);
            return unitOfWork.ArticleRepo.Add(article);
        }

        public async Task<int> DeleteArticle(string articleId)
        {
            var article = await unitOfWork.ArticleRepo.GetByIdAsync(articleId);
            if (article is not null)
            {
                article.DeleteDate = DateTime.Now;
                article.Status = EntityStatus.Deleted;
                return unitOfWork.ArticleRepo.Delete(article);
            }
            return 0;
        }

        public async Task<ArticleDTO> GetArticleByIdAsync(string articleId)
        {
            var article = await unitOfWork.ArticleRepo.GetByIdAsync(articleId);
            return mapper.Map<ArticleDTO>(article);
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticlesAsync()
        {
            var article = await unitOfWork.ArticleRepo.GetAllAsync(x=>x.Status != EntityStatus.Deleted);
            return mapper.Map<IEnumerable<ArticleDTO>>(article);
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticlesByCategoryIdAsync(string categoryId)
        {
            var article = await unitOfWork.ArticleRepo.GetAllAsync(x => x.CategoryId == categoryId);
            return mapper.Map<IEnumerable<ArticleDTO>>(article);
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticlesByUserIdAsync(string userId)
        {
            var article = await unitOfWork.ArticleRepo.GetAllAsync(x=>x.AppUserId == userId);
            return mapper.Map<IEnumerable<ArticleDTO>>(article);
        }

        public int UpdateArticle(ArticleDTO articleDTO)
        {
            var article = mapper.Map<Article>(articleDTO);
            article.UpdateDate = DateTime.Now;
            article.Status = EntityStatus.Updated;
            return unitOfWork.ArticleRepo.Update(article);
        }
    }
}
