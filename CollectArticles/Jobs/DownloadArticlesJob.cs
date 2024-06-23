using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectArticles.Service;
using Microsoft.Extensions.Logging;
using Quartz;

namespace CollectArticles.Jobs
{
	public class DownloadArticlesJob : IJob
	{
		private readonly ILogger<DownloadArticlesJob> _logger;
		private readonly FindPttService _findPttService;

		public DownloadArticlesJob(ILogger<DownloadArticlesJob> logger,
			                       FindPttService findPttService)
		{
			_logger = logger;
			_findPttService = findPttService;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			_logger.LogInformation(DateTime.Now.ToString());
			var test = await _findPttService.GetSomeText();
			_logger.LogInformation(test);

			return;
		}
	}
}
