using AutoMapper;
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
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AppUserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int CreateUserAsync(AppUserDTO user)
        {
            var appUser = mapper.Map<AppUser>(user);
            return unitOfWork.ApplicationUserRepo.Add(appUser);
        }

        public async Task<int> DeleteUserAsync(string userId)
        {
            var appUser = await unitOfWork.ApplicationUserRepo.GetByIdAsync(userId);
            return unitOfWork.ApplicationUserRepo.Delete(appUser);
        }

        public async Task<AppUserDTO> GetUserByIdAsync(string userId)
        {
            var appUser = await unitOfWork.ApplicationUserRepo.GetByIdAsync(userId);
            return mapper.Map<AppUserDTO>(appUser);
        }

        public async Task<IEnumerable<AppUserDTO>> GetUsersAsync()
        {
            var appUsers = await unitOfWork.ApplicationUserRepo.GetAllAsync();
            return mapper.Map<IEnumerable<AppUserDTO>>(appUsers);
        }

        public int UpdateUserAsync(AppUserDTO user)
        {
            var appUser = mapper.Map<AppUser>(user);
            return unitOfWork.ApplicationUserRepo.Update(appUser);
        }
    }
}
