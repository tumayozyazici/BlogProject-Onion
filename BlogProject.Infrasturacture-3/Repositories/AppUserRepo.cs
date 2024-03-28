using BlogProject.Core.DomainModels.Models;
using BlogProject.Infrasturacture_3.Contexts;
using BlogProject.Infrasturacture_3.Repositories.BaseRepos;
using BlogProject_Application_2.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrasturacture_3.Repositories
{
    public class AppUserRepo : BaseRepo<AppUser>, IApplicationUserRepo
    {
        private readonly AppDbContext _context;

        public AppUserRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AppUser> GetUserByEmailAsync(string userEmail)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == userEmail);
        }

        public async Task<AppUser> GetUserByNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }
    }
}
