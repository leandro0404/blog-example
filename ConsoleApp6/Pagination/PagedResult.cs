using System.Collections.Generic;

namespace Pottencial.Channels.Portals.Authorization.Shared.Models.Pagination
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Total { get; set; }
    }
}
