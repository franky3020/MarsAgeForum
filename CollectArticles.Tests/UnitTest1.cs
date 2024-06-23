using CollectArticles.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace CollectArticles.Tests;

public class UnitTest1
{
    private readonly ITestOutputHelper _output;

    public UnitTest1(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async void Test1()
    {
        var serviceProvider = new ServiceCollection()
        .AddLogging()
        .BuildServiceProvider();

        var factory = serviceProvider.GetService<ILoggerFactory>();

        var logger = factory!.CreateLogger<FindPttService>();

        var findPttService = new FindPttService(logger);
        await findPttService.GetSomeText();

        _output.WriteLine("test over");

    }
}