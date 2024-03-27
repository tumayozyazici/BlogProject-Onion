using BlogProject.Core.DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Infrasturacture_3.Configurations
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x=>x.AppUser).WithMany(x => x.Comments).HasForeignKey(x=>x.AppUserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
