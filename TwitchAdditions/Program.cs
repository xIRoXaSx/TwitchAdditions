// See https://aka.ms/new-console-template for more information

using System.Reflection;
using TwitchAdditions.Twitch;

namespace TwitchAdditions {
    internal class Program {
        internal static readonly string BinName = Assembly.GetExecutingAssembly().GetName().Name ?? "TwitchAdditions";
        private static readonly Config Config = new();

        private static void Main(string[] args) {
            Config.Create();
            var client = new Client();
            client.Connect();
            while (true)
                Console.ReadLine();
        }
    }
}