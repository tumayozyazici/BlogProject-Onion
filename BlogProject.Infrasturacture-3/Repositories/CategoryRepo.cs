using BlogProject.Core.DomainModels.Models;
using BlogProject.Infrasturacture_3.Contexts;
using BlogProject.Infrasturacture_3.Repositories.BaseRepos;
using BlogProject_Application_2.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrasturacture_3.Repositories
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(AppDbContext context) : base(context)
        {
        }
    }
}
