using BlogProject_Application_2.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Application_2.Services.IServices
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetCategoryByIdAsync(string categoryId);
        Task<IEnumerable<CategoryDTO>> GetAllCategoryiesAsync();

        int CreateCategory(CategoryDTO categoryDTO);
        int UpdateCategory(CategoryDTO categoryDTO);
        Task<int> DeleteCategory(string categoryId);
    }
}
