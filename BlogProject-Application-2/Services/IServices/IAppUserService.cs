using BlogProject.Core.DomainModels.Models;
using BlogProject_Application_2.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Application_2.Services.IServices
{
    public interface IAppUserService
    {
        Task<AppUserDTO> GetUserByIdAsync(string userId);
        Task<IEnumerable<AppUserDTO>> GetUsersAsync();

        Task<int> CreateUserAsync(AppUserDTO user);
        Task<int> UpdateUserAsync(AppUserDTO user);
        Task<int> DeleteUserAsync(string userId);
    }
}
