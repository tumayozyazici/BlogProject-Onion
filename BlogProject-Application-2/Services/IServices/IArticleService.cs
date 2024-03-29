using BlogProject_Application_2.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Application_2.Services.IServices
{
    public interface IArticleService
    {
        Task<ArticleDTO> GetArticleByIdAsync(string articleId);
        Task<IEnumerable<ArticleDTO>> GetArticlesAsync();
        Task<IEnumerable<ArticleDTO>> GetArticlesByUserIdAsync(string userId);
        Task<IEnumerable<ArticleDTO>> GetArticlesByCategoryIdAsync(string categoryId);
        
        int CreateArticle(ArticleDTO articleDTO);
        int UpdateArticle(ArticleDTO articleDTO);
        Task<int> DeleteArticle(string articleId);
    }
}
