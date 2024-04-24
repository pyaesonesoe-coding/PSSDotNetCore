// See https://aka.ms/new-console-template for more information
using PSSDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//Ctrl + . => suggestion
//F10
//F11 
//F9 => Breakpoint
AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Update(11, "test title", "test author", "test content");
//adoDotNetExample.Delete(11);
//adoDotNetExample.Edit(11);
//adoDotNetExample.Edit(1);

DapperExample dapperExample = new DapperExample();
dapperExample.Run();
Console.ReadKey();