using CollectArticles.Jobs;
using CollectArticles.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;

namespace CollectArticles
{
	internal static class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			var host = CreateHost(args);

			var schedulerFactory = host.Services.GetRequiredService<ISchedulerFactory>();
			var scheduler = await schedulerFactory.GetScheduler();

			var job = JobBuilder.Create<DownloadArticlesJob>()
			.WithIdentity("myJob", "group1")
			.Build();

			var trigger = TriggerBuilder.Create()
			.WithIdentity("myTrigger", "group1")
			.StartNow()
			.WithSimpleSchedule(x => x
				.WithIntervalInSeconds(4)
				.RepeatForever())
			.Build();

			await scheduler.ScheduleJob(job, trigger);
			await host.RunAsync();


		}

		private static IHost CreateHost(string[] args)
		{
			return Host.CreateDefaultBuilder(args)
		   .ConfigureServices(services =>
		   {
			   services.AddQuartz();

			   services.AddQuartzHostedService(options =>
			   {
				   // 主程式關閉時，會確保當前任務已經完成
				   options.WaitForJobsToComplete = true;
			   });

			   services.AddSingleton<FindPttService>();

		   })
		   .Build();
		}
	}
}
