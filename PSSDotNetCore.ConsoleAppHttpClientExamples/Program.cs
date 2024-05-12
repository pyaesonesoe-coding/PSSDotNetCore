using Newtonsoft.Json;
using PSSDotNetCore.ConsoleAppHttpClientExamples;

Console.WriteLine("Hello, World!");

// Console App - Client (Frontend)
// ASP.NET Core Web API - Server (Backend)

//HttpClient client = new HttpClient();
//var response = await client.GetAsync("https://localhost:7050/api/blog");
//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    //Console.WriteLine(jsonStr);
//    List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
//    foreach (var blog in lst)
//    {
//        Console.WriteLine(JsonConvert.SerializeObject(blog));
//        Console.WriteLine($"Title => {blog.BlogTitle}");
//        Console.WriteLine($"Author => {blog.BlogAuthor}");
//        Console.WriteLine($"Content => {blog.BlogTitle}");
//    }
//}

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();

Console.ReadLine();