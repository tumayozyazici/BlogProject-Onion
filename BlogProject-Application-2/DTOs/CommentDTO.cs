using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject_Application_2.DTOs
{
    public class CommentDTO
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string AppUserId { get; set; }
        public string ArticleId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
