using BlogProject.Core.DomainModels.Models;
using BlogProject_Application_2.IRepositories.BaseRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Application_2.IRepositories
{
    public interface IApplicationUserRepo :IBaseRepo<AppUser>
    {
        Task<AppUser> GetUserByNameAsync(string userName);
        Task<AppUser> GetUserByEmailAsync(string UserEmail);
    }
}
