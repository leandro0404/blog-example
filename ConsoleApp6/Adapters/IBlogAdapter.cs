using ConsoleApp6.Entities;
using ConsoleApp6.Models;
using System.Collections.Generic;
using Pottencial.Channels.Portals.Authorization.Shared.Models.Pagination;


namespace ConsoleApp6.Adapters
{
    public interface IBlogAdapter
    {
        Blog ToBlog(BlogEntity blogEntity);
        PagedResult<Blog> ToPageResultBlog(List<BlogEntity> blogEntities);
    }
}
