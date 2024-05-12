using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using RestSharp;

namespace PSSDotNetCore.ConsoleAppRestClientExamples
{
    internal class RestClientExample
    {
        private readonly RestClient client = new RestClient(new Uri("https://localhost:7050"));
        private readonly string _blogEndpoint = "api/blog";
        public async Task RunAsync()
        {
            //await ReadAsync();
            //await EditAsync(1);
            //await EditAsync(20);
            //await EditAsync(6012);
            //await CreateAsync("title", "author 2 ", "content 3");
            //await UpdateAsync(6012, "title 1", "author", "content");
            //await PatchUpdateAsync(6012, "title patch", null, null);
            //await DeleteAsync(6012);
        }

        private async Task ReadAsync()
        {
            //RestRequest restRequest = new RestRequest(_blogEndpoint);
            //var response = await client.GetAsync(restRequest);

            RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Get);
            var response = await client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
                foreach (var blog in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(blog));
                    Console.WriteLine($"Title => {blog.BlogTitle}");
                    Console.WriteLine($"Author => {blog.BlogAuthor}");
                    Console.WriteLine($"Content => {blog.BlogContent}");
                }
            }
        }

        private async Task EditAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Get);
            var response = await client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                var item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogModel blogModel = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            }; //C# Object

            var restRequest = new RestRequest(_blogEndpoint, Method.Post);
            restRequest.AddJsonBody(blogModel);
            var response = await client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel blogModel = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            }; //C# Object

            var restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
            restRequest.AddJsonBody(blogModel);
            var response = await client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task PatchUpdateAsync(int id, string? title, string? author, string? content)
        {
            BlogModel blogModel = new BlogModel();
            if (!string.IsNullOrEmpty(title))
            {
                blogModel.BlogTitle = title;
            }
            if (!string.IsNullOrEmpty(author))
            {
                blogModel.BlogAuthor = author;
            }
            if (!string.IsNullOrEmpty(content))
            {
                blogModel.BlogContent = content;
            }

            var restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Patch);
            restRequest.AddJsonBody(blogModel);
            var response = await client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}",Method.Delete);

            var response = await client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }
    }
}
