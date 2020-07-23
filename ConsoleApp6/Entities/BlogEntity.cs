using Newtonsoft.Json;

namespace ConsoleApp6.Entities
{
    public class BlogEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public Title Title { get; set; }

        public Content Content { get; set; }
    }


    public class Title
    {
        [JsonProperty("rendered")]
        public string Rendered { get; set; }
    }

    public class Content
    {
        [JsonProperty("rendered")]
        public string Rendered { get; set; }
    }
}
