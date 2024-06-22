using Microsoft.Extensions.Logging;


namespace CollectArticles.Service
{
	public class FindPttService
	{
		private int count = 0;
		private readonly ILogger<FindPttService> _logger;
		public FindPttService(ILogger<FindPttService> logger)
		{
			_logger = logger;
			_logger.LogInformation("int FindPttService");
		}

		public string GetSomeText()
		{
			count++;
			return "GetSomeText: " + count.ToString();
		}
	}
}
