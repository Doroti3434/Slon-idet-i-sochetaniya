using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
});

app.MapGet("/combination/{allNumbers}/{perGroup}", CominationsRequest);
app.MapGet("/slon/{x1}/{y1}/{x2}/{y2}", SlonRequest);
app.Run();



string SlonRequest(string x1, string y1, string x2, string y2)
{
    StreamWriter sr = new StreamWriter("./log.txt", true);
    int iX1 = int.Parse(x1);
    int iY1 = int.Parse(y1);
    int iX2 = int.Parse(x2);
    int iY2 = int.Parse(y2);
    if(Math.Abs(iX1 - iX2) == Math.Abs(iY1 - iY2))
    {
        sr.WriteLine("x1 - " + x1 + ", y1 - " + y1 + ", x2 - " + x2 + ", y2 - " + y2 + " ֱüוע");
        sr.Close();
        return "ֱüוע";
    }

    sr.WriteLine("x1 - " + x1 + ", y1 - " + y1 + ", x2 - " + x2 + ", y2 - " + y2 + " ֽו בüוע");
    sr.Close();
    return "ֽו בüוע";

}

string CominationsRequest(int allNumbers, int perGroup)
{
    StreamWriter sr = new StreamWriter("./log.txt", true);
    sr.WriteLine("n - " + allNumbers + ", k - " + perGroup +  " result - "  + Convert.ToString(Factorial(allNumbers) / (Factorial(allNumbers - perGroup) * Factorial(perGroup))));
    sr.Close();
    return Convert.ToString(Factorial(allNumbers) / (Factorial(allNumbers - perGroup) * Factorial(perGroup)));
}

int Factorial(int number)
{
    int n = 1;

    for (int i = 1; i < number + 1; i++)
    {
        n *= i;
    }

    return n; // returns 1 when number is 0
}