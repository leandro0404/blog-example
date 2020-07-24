using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApp6.Adapters;
using ConsoleApp6.Entities;
using ConsoleApp6.Models;
using Newtonsoft.Json;
using Pottencial.Channels.Portals.Authorization.Shared.Models.Pagination;

namespace ConsoleApp6
{
    public class BlogRepository : IBlogRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IBlogAdapter _blogAdapter;
        public BlogRepository
        (
            HttpClient httpClient,
            IBlogAdapter blogAdapter
        )
        {
            _httpClient = httpClient;
            _blogAdapter = blogAdapter;
        }



        public async Task<PagedResult<Blog>> Get(PageSettings pageSettings)
        {
            var offset = ((pageSettings.PageNumber - 1) * pageSettings.PageSize) -1;
            var url = $"posts?" +
                $"categories=19" +
                $"&page={pageSettings.PageNumber}" +
                $"&per_page={pageSettings.PageSize}" +
                $"&offset={offset}" +
                $"&order={pageSettings.Direction.ToString().ToLower()}" +
                $"&orderby={pageSettings.OrderBy}";

            var uri = new Uri(url, UriKind.Relative);
            var result = await _httpClient.GetAsync(uri);
            var total = Convert.ToInt32(result.Headers.FirstOrDefault(i => i.Key == "X-WP-Total").Value.FirstOrDefault());
            string data = await result.Content.ReadAsStringAsync();
            var pageResult = _blogAdapter.ToPageResultBlog(JsonConvert.DeserializeObject<List<BlogEntity>>(data));
            pageResult.Total = total;

            return pageResult;
        }
    }
}
