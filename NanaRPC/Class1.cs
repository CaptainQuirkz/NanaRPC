using System;
using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.Message;
using Newtonsoft.Json;
using NanaManagerAPI.Attributes;
using NanaManagerAPI.UI;
namespace NanaRichPresence
{
	[EntryPoint]
	public static class DiscordRPC
	{
		public static DiscordRpcClient client;
		public static string PageID;
		public static string Message;
		[EntryPoint]
		public static void Initialize()
		{
			Console.SetOut(System.IO.TextWriter.Null);
			DiscordRpcClient client;
			client = new DiscordRpcClient("775858810816299009");
			client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
			client.Initialize();

			client.SetPresence(new RichPresence()
			{
				Details = "Managing Nana",
				Timestamps = Timestamps.Now,
				Assets = new Assets()
				{
					LargeImageKey = "image_large",
					LargeImageText = "Nana Manager",
					SmallImageKey = "image_small"
				}
			});

			var timer = new System.Timers.Timer(150);
			timer.Elapsed += (sender, args) => 
			{
				PageID = NanaManagerAPI.UI.Paging.GetCurrentPage();
				client.Invoke();
				if (PageID == "hydroxa.nanaManager:pg_in")
				{
					client.UpdateDetails("Importing Media");
				}
				else if (PageID == "hydroxa.nanaManager:pg_err")
				{
					client.UpdateDetails("Discovering Bugs");
				}
				else if (PageID == "hydroxa.nanaManager:pg_login")
				{
					client.UpdateDetails("Logging In");
				}
				else if (PageID == "hydroxa.nanaManager:pg_view")
				{
					client.UpdateDetails("Viewing Media");
				}
				else if (PageID == "hydroxa.nanaManager:pg_load")
				{
					client.UpdateDetails("Loading...");
				}
				else if (PageID == "hydroxa.nanaManager:pg_reg")
				{
					client.UpdateDetails("Creating An Account");
				}
				else if (PageID == "hydroxa.nanaManager:pg_search")
				{
					client.UpdateDetails("Looking for Content");
				}
				else if (PageID == "hydroxa.nanaManager:pg_sets")
				{
					client.UpdateDetails("Editing Settings");
				}
				else if (PageID == "hydroxa.nanaManager:pg_fsc")
				{
					client.UpdateDetails("Viewing Media");
				}
				else if (PageID == "hydroxa.nanaManager:pg_tagMan")
				{
					client.UpdateDetails("Editing Tags");
				}
				else if (PageID == null)
				{ 

				}
				else
				{
					client.UpdateDetails($"Using a Plugin: {NanaManagerAPI.UI.Paging.GetPage(PageID).GetType().Name}");
				};
			};
			timer.Start();
			
		}

	}
}