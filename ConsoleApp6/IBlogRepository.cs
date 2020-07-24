using System.Threading.Tasks;
using ConsoleApp6.Models;
using Pottencial.Channels.Portals.Authorization.Shared.Models.Pagination;

namespace ConsoleApp6
{
    public interface IBlogRepository
    {
        Task<PagedResult<Blog>> Get(PageSettings pageSettings);
    }
}
