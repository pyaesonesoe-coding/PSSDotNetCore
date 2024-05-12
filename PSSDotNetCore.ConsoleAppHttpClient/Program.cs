// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");

string jsonStr = await File.ReadAllTextAsync("data.json");
var model = JsonConvert.DeserializeObject<MainDto>(jsonStr);

//Console.WriteLine(jsonStr);


foreach (var question in model.Questions)
{
    Console.WriteLine(question.QuestionId);
}
// JSON to C# ??? package
// C# to JSON
Console.ReadLine();


static string ToNumber(string num)
{
    num = num.Replace("၃", "3");
    return num;
}


public class MainDto
{
    public Question[] Questions { get; set; }
    public Answer[] Answers { get; set; }
}

public class Question
{
    public int QuestionId { get; set; }
    public string QuestionName { get; set; }
    public string QuestionDesp { get; set; }
}

public class Answer
{
    public int AnswerId { get; set; }
    public string AnswerImageUrl { get; set; }
    public string AnswerName { get; set; }
    public string AnswerDesp { get; set; }
    public int QuestionId { get; set; }
}

