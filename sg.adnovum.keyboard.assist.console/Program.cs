// See https://aka.ms/new-console-template for more information


using Microsoft.Extensions.Configuration;
using sg.adnovum.keyboard.assist.console;
internal class Program
{
    private static void Main(string[] args)
    {

        string input = @"To us on Earth, the sun is a smiling orange-yellow circle among the cottony clouds. But the fiery
ball of fire out in space is so much more than that. The Sun is the star, the center of our solar
system. It is the most important source of energy for life on earth. With its humongous size and
heavy composition of chemicals, this blazing star has a magnified gravitational force, compelling
all the planets, including the earth to revolve around it. Due to its importance in our lives, man
since prehistoric times has considered it a deity and I personally believe it is nothing less than
that.";
        var config = LoadConfiguration();
        var keyboard = new KeyBoardAssist();
        var output = keyboard.Process(input, config.GetValue<string>("RegexScanInputPattern"),
            config.GetValue<int>("MinimumInputLength"),
            config.GetValue<int>("MaximumPercentage"),
            config.GetValue<int>("ParserType"));
        Console.WriteLine(output);
    }

    public static IConfiguration LoadConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, false);
        return builder.Build();
    }
}