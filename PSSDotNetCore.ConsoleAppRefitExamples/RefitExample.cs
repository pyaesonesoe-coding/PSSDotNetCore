using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSDotNetCore.ConsoleAppRefitExamples
{
    public class RefitExample
    {
        private readonly IBlogApi service = RestService.For<IBlogApi>("https://localhost:7270");

        public async Task RunAsync()
        {
            await ReadAsync();
            //await EditAsync(1);
            //await EditAsync(22);
            //await CreateAsyn("title 22", "author 22", "content 22");
            //await UpdateAsyn(8011,"title 23", "author 24", "content 25");
            //await DeleteAsyn(8011);
            await PatchUpdateAsyn(7011,"title 22",null ,null);
        }

        public async Task ReadAsync()
        {
            var lst = await service.GetBlogs();
            foreach (var item in lst)
            {
                Console.WriteLine($"Id => {item.BlogId}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("_________________________________");
            }
        }

        public async Task EditAsync(int id)
        {
            try
            {
                var item = await service.GetBlog(id);
                Console.WriteLine($"Id => {item.BlogId}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("_________________________________");
            }
            catch(ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }

        private async Task CreateAsyn(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            var message = await service.CreateBlog(blog);
            Console.WriteLine(message);
        }

        private async Task UpdateAsyn(int id, string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };

                var message = await service.UpdateBlog(id, blog);
                Console.WriteLine(message);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task PatchUpdateAsyn(int id, string? title, string? author, string? content)
        {
            try
            {
                BlogModel blog = new BlogModel();
                if (!string.IsNullOrEmpty(title))
                {
                    blog.BlogTitle = title;
                }
                if (!string.IsNullOrEmpty(author))
                {
                    blog.BlogAuthor = author;
                }
                if (!string.IsNullOrEmpty(content))
                {
                    blog.BlogContent = content;
                }

                var message = await service.UpdateBlog(id, blog);
                Console.WriteLine(message);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task DeleteAsyn(int id)
        {
            try
            {
                var message = await service.DeleteBlog(id);
                Console.WriteLine(message);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
