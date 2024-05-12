using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PSSDotNetCore.ConsoleAppHttpClientExamples
{
    internal class HttpClientExample
    {
        private readonly HttpClient client = new HttpClient() { BaseAddress = new Uri("https://localhost:7050") };
        private readonly string _blogEndpoint = "api/blog";
        public async Task RunAsync()
        {
            //await ReadAsync();
            //await EditAsync(1);
            //await EditAsync(20);
            //await EditAsync(6011);
            //await CreateAsync("title", "author 2 ", "content 3");
            //await UpdateAsync(6011, "title 1", "author", "content");
            //await PatchUpdateAsync(6011, "title patch", null , null);
            //await DeleteAsync(6011);
        }

        private async Task ReadAsync()
        {
            var response = await client.GetAsync(_blogEndpoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
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
            var response = await client.GetAsync($"{_blogEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
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

            // To Json
            string blogJson = JsonConvert.SerializeObject(blogModel);

            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await client.PostAsync(_blogEndpoint, httpContent);
            if (response.IsSuccessStatusCode) 
            {
                string message = await response.Content.ReadAsStringAsync();
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

            // To Json
            string blogJson = JsonConvert.SerializeObject(blogModel);

            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await client.PutAsync($"{_blogEndpoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
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

            // To Json
            string blogJson = JsonConvert.SerializeObject(blogModel);

            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await client.PatchAsync($"{_blogEndpoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"{_blogEndpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }
}
