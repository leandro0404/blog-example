using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApp6.Entities;
using Newtonsoft.Json;
using Pottencial.Channels.Portals.Authorization.Shared.Models.Pagination;

namespace ConsoleApp6
{
    public class BlogRepository : IBlogRepository
    {
        private readonly HttpClient _httpClient;
        public BlogRepository( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BlogEntity>> Get(PageSettings pageSettings)
        {
            pageSettings.OrderBy = "date";

            var url = $"posts?" +
                $"categories=19" +
                $"&page={pageSettings.PageNumber}" +
                $"&per_page={pageSettings.PageSize}" +
                $"&offset=0" +
                $"&order={pageSettings.Direction.ToString().ToLower()}" +
                $"&orderby={pageSettings.OrderBy}";

            var uri = new Uri(url, UriKind.Relative);

            var result = await _httpClient.GetAsync(uri);

            string data = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<BlogEntity>>(data);
        }

    }
}
