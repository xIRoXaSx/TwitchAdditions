// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Text;
using TwitchAdditions.Twitch;
using YamlDotNet.Serialization;

namespace TwitchAdditions {
    internal class Program {
        internal static readonly string BinName = Assembly.GetExecutingAssembly().GetName().Name ?? "TwitchAdditions";
        private static readonly Config Config = new();
        internal static Config DeserializedConf = Config;

        private static void Main(string[] args) {
            if (!File.Exists(Config.ConfigPath)) {
                Config.Create();
                return;
            }
            
            var deserializer = new DeserializerBuilder().Build();
            DeserializedConf = deserializer.Deserialize<Config>(File.ReadAllText(Config.ConfigPath, Encoding.UTF8));
            var client = new Client();
            client.Connect();
            while (true)
                Console.ReadLine();
        }
    }
}