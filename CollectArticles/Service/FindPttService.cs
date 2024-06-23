using AngleSharp;
using AngleSharp.Dom;
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

        public async Task<string> GetSomeText()
		{
			var config = AngleSharp.Configuration.Default
			.WithDefaultLoader()
			.WithDefaultCookies();

			var browser = BrowsingContext.New(config);


			// 這邊用的型別是 AngleSharp 提供的 AngleSharp.Dom.Url
			var url = new Url("https://www.ptt.cc/bbs/movie/index.html");
			browser.SetCookie(url, "over18=1'");

			// 使用 OpenAsync 來打開網頁抓回內容
			var document = await browser.OpenAsync(url);
			Console.WriteLine(document.DocumentElement.OuterHtml);
			Console.WriteLine("");

			count++;
			return "GetSomeText: " + count.ToString();
		}
	}
}
