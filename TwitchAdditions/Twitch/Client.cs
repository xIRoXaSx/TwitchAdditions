using System.Text;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Models;
using YamlDotNet.Serialization;

namespace TwitchAdditions.Twitch; 

public class Client {
    private readonly TwitchClient _client;
    private readonly Config deConf;
    
    public Client() {
        var deserializer = new DeserializerBuilder().Build();
        deConf = deserializer.Deserialize<Config>(File.ReadAllText(Config.ConfigPath, Encoding.UTF8));
        var creds = new ConnectionCredentials(deConf.Settings.ClientId, deConf.Settings.AccessToken);
        var clientOpts = new ClientOptions {
            MessagesAllowedInPeriod = 750,
            ThrottlingPeriod = TimeSpan.FromSeconds(30)
        };
        
        var webClient = new WebSocketClient(clientOpts);
        _client = new TwitchClient(webClient);
        _client.Initialize(creds);
    }

    /// <summary>
    /// Initialize the connection to Twitch.
    /// </summary>
    internal void Connect() {
        _client.OnConnected += ClientOnConnected;
        _client.OnDisconnected += ClientOnDisconnected;
        _client.OnError += ClientOnError;
        _client.Connect();
    }

    /// <summary>
    /// Called whenever the client has successfully logged into Twitch's API.
    /// </summary>
    /// <param name="sender"><c>Object</c> or <c>null</c></param>
    /// <param name="e"><c>OnConnectedArgs</c></param>
    private static void ClientOnConnected(object? sender, OnConnectedArgs e) {
        Logging.Info("Successfully connected to Twitch");
    }
    
    /// <summary>
    /// Called whenever the client has successfully logged off Twitch's API.
    /// </summary>
    /// <param name="sender"><c>Object</c> or <c>null</c></param>
    /// <param name="e"><c>OnDisconnectedEventArgs</c></param>
    private static void ClientOnDisconnected(object? sender, OnDisconnectedEventArgs e) {
        Logging.Info("Disconnected from Twitch");
    }
    
    /// <summary>
    /// Called whenever an error occurred while using Twitch's API.
    /// </summary>
    /// <param name="sender"><c>Object</c> or <c>null</c></param>
    /// <param name="e"><c>OnErrorEventArgs</c></param>
    private static void ClientOnError(object? sender, OnErrorEventArgs e) {
        Logging.Warn("An unexpected error occurred: " + e.Exception.Message);
    }
}