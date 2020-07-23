namespace Pottencial.Channels.Portals.Authorization.Shared.Models.Pagination
{
    public class PageSettings
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Direction Direction { get; set; }
        public string OrderBy { get; set; }

        public PageSettings()
        {
            PageNumber = 1;
            PageSize = 10;
            Direction = Direction.ASC;
        }
    }
}
