using System;
using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.Message;
using Newtonsoft.Json;
using NanaManagerAPI.Attributes;
namespace NanaRichPresence
{
    [EntryPoint]
    public static class DiscordRPC
    {

        public static DiscordRpcClient client;
        [EntryPoint]
        public static void Initialize()
        {
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
            Console.ReadLine();


        }
    }
}