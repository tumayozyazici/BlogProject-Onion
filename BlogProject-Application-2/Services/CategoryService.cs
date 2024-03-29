using AutoMapper;
using BlogProject.Core.DomainModels.Enums;
using BlogProject.Core.DomainModels.Models;
using BlogProject_Application_2.DTOs;
using BlogProject_Application_2.Services.IServices;
using BlogProject_Application_2.Utilities.IUnitOfWork;
using BlogProject_Application_2.Utilities.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Application_2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        //private readonly ILogging logging;           ctora eklemeyi unutma

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int CreateCategory(CategoryDTO categoryDTO)
        {
            var category = mapper.Map<Category>(categoryDTO);
            return unitOfWork.CategoryRepo.Add(category);
        }

        public async Task<int> DeleteCategory(string categoryId)
        {
            var category = await unitOfWork.CategoryRepo.GetByIdAsync(categoryId);
            category.DeleteDate= DateTime.Now;
            category.Status = EntityStatus.Deleted;

            //logging.LogError("Delete işlemi yapıldı.");

            return unitOfWork.CategoryRepo.Delete(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoryiesAsync()
        {
            var category = await unitOfWork.CategoryRepo.GetAllAsync();

            return mapper.Map<IEnumerable<CategoryDTO>>(category);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(string categoryId)
        {
            var category = await unitOfWork.CategoryRepo.GetByIdAsync(categoryId);
            return mapper.Map<CategoryDTO>(category);
        }

        public int UpdateCategory(CategoryDTO categoryDTO)
        {
            var category = mapper.Map<Category>(categoryDTO);
            category.UpdateDate = DateTime.Now;
            category.Status = EntityStatus.Updated;
            return unitOfWork.CategoryRepo.Update(category);
        }
    }
}
