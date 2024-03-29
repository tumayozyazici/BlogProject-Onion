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
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public int CreateComment(CommentDTO commentDTO)
        {
            var comment = mapper.Map<Comment>(commentDTO);
            return unitOfWork.CommentRepo.Add(comment);
        }

        public async Task<IEnumerable<CommentDTO>> GetCommentsByArticles(string articleId)
        {
            var comments = await unitOfWork.CommentRepo.GetAllByArticleIdAsync(articleId);
            return mapper.Map<IEnumerable<CommentDTO>>(comments);
        }
    }
}
