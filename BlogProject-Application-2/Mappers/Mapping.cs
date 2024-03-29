using AutoMapper;
using BlogProject.Core.DomainModels.Models;
using BlogProject_Application_2.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Application_2.Mappers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, AppUserDTO>().ForMember(dest=>dest.FullName,options=> options.MapFrom
            (src=>src.FirstName + " " + src.LastName));


            CreateMap<Article,ArticleDTO>().ReverseMap();
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
        }
    }
}
