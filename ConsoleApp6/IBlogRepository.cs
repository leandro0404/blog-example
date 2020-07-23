using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApp6.Entities;
using Pottencial.Channels.Portals.Authorization.Shared.Models.Pagination;

namespace ConsoleApp6
{
    public interface IBlogRepository
    {
        Task<List<BlogEntity>> Get(PageSettings pageSettings);
    }
}
