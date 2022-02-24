using TwitchLib.Api;
using TwitchLib.Api.Services;
using TwitchLib.Api.Services.Events;
using TwitchLib.Api.Services.Events.LiveStreamMonitor;

namespace TwitchAdditions.Twitch; 

public class Monitor {
    private readonly LiveStreamMonitorService _twitchMonitor;

    public Monitor() {
        var twitchApi = new TwitchAPI {
            Settings = {
                ClientId = Program.DeserializedConf.Settings.ClientId,
                AccessToken = Program.DeserializedConf.Settings.AccessToken
            }
        };
        _twitchMonitor = new LiveStreamMonitorService(twitchApi, 5);
    }
    
    /// <summary>
    /// Establish the connection to Twitch.
    /// </summary>
    internal async void Connect() {
        _twitchMonitor.OnStreamOnline += Monitor_OnStreamOnline;
        _twitchMonitor.OnStreamOffline += Monitor_OnStreamOffline;
        _twitchMonitor.OnChannelsSet += Monitor_OnChannelsSet;
        _twitchMonitor.OnServiceStarted += Monitor_OnServiceStarted;
        _twitchMonitor.OnServiceStopped += Monitor_OnServiceStopped;
        
        // Set the channel list.
        _twitchMonitor.SetChannelsByName(new List<string>());
        
        // Update live streams list.
        await _twitchMonitor.UpdateLiveStreamersAsync();
                    
        // Start the Monitor service.
        _twitchMonitor.Start();
    }

    /// <summary>
    /// Called when stream went live.
    /// </summary>
    /// <param name="sender"><c>Object</c> or <c>null</c></param>
    /// <param name="e"><c>OnStreamOnlineArgs</c></param>
    private static async void Monitor_OnStreamOnline(object? sender, OnStreamOnlineArgs e) {
        Logging.Info("Stream went live.");
    }
    
    /// <summary>
    /// Called when stream went offline.
    /// </summary>
    /// <param name="sender"><c>Object</c> or <c>null</c></param>
    /// <param name="e"><c>OnStreamOfflineArgs</c></param>
    private static async void Monitor_OnStreamOffline(object? sender, OnStreamOfflineArgs e) {
        Logging.Info("Stream went offline.");
    }
    
    /// <summary>
    /// Called when the channel list has been set.
    /// </summary>
    /// <param name="sender"><c>Object</c> or <c>null</c></param>
    /// <param name="e"><c>OnChannelsSetArgs</c></param>
    private static async void Monitor_OnChannelsSet(object? sender, OnChannelsSetArgs e) {
        Logging.Debug("Channel list has been set.");
    }
    
    /// <summary>
    /// Called when the LiveStreamMonitorService has started.
    /// </summary>
    /// <param name="sender"><c>Object</c> or <c>null</c></param>
    /// <param name="e"><c>OnServiceStartedArgs</c></param>
    private static async void Monitor_OnServiceStarted(object? sender, OnServiceStartedArgs e) {
       Logging.Info("Monitor service has started.");
    }
    
    /// <summary>
    /// Called when the LiveStreamMonitorService has stopped. 
    /// </summary>
    /// <param name="sender"><c>Object</c> or <c>null</c></param>
    /// <param name="e"><c>OnServiceStoppedArgs</c></param>
    private static async void Monitor_OnServiceStopped(object? sender, OnServiceStoppedArgs e) {
        Logging.Info("Monitor service has stopped.");
    }
}