using System.Collections.Generic;
using ConsoleApp6.Entities;
using ConsoleApp6.Models;
using Pottencial.Channels.Portals.Authorization.Shared.Models.Pagination;

namespace ConsoleApp6.Adapters
{
    public class BlogAdapter
    {
        public Blog ToBlog(BlogEntity blogEntity)
        {
            return new Blog
            {
                Id = blogEntity.Id,
                Title = blogEntity.Title.Rendered,
                Description = blogEntity.Content.Rendered
            };
        }

        public PagedResult<Blog> ToPageResultBlog(List<BlogEntity> blogEntities)
        {
            var list = new List<Blog>();

            foreach (var blog in blogEntities)
            {
                list.Add(ToBlog(blog));
            }
            return new PagedResult<Blog>() { Data = list };
        }
    }
}
