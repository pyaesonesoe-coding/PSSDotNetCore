// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PSSDotNetCore.ConsoleApp.AdoDotNetExamples;
using PSSDotNetCore.ConsoleApp.DapperExamples;
using PSSDotNetCore.ConsoleApp.EFCoreExamples;
using PSSDotNetCore.ConsoleApp.Services;
using System.Data;
using System.Data.SqlClient;

//Console.WriteLine("Hello, World!");

//Ctrl + . => suggestion
//F10
//F11 
//F9 => Breakpoint
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Update(11, "test title", "test author", "test content");
//adoDotNetExample.Delete(11);
//adoDotNetExample.Edit(11);
//adoDotNetExample.Edit(1);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Run();
var connectionString = ConnectionString.SqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

var serviceProvider = new ServiceCollection()
    .AddScoped(n => new AdoDotNetExample(sqlConnectionStringBuilder))
    .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlServer(connectionString);
    })
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

//AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>();
//var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
//adoDotNetExample.Read();

//var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
//dapperExample.Run();

var efCoreExample = serviceProvider.GetRequiredService<EFCoreExample>();
efCoreExample.Run();

Console.ReadKey();