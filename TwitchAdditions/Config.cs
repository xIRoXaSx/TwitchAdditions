namespace TwitchAdditions; 

public class Config {
    private const string ConfigName = "config.yml";
    private static readonly string ConfigDir = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Program.BinName
    );
    internal static readonly string ConfigPath = Path.Combine(ConfigDir, ConfigName);

    public TwitchSettings Settings { get; set; } = new();
    
    internal void Create() {
        Console.WriteLine("ConfigDir: {0}, ConfigPath: {1}", ConfigDir, ConfigPath);
        if (File.Exists(ConfigPath))
            return;

        if (!Directory.Exists(ConfigDir)) {
            try {
                Directory.CreateDirectory(ConfigDir);
                Logging.Info("Config directory has been created!");
            } catch (Exception ex) {
                Logging.Error("Config directory has been created!");
                Logging.Error(ex.Message);
                Logging.Error("Press any key to exit the application...");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        var config = new Config();
        var serialized = Parser.Serialize(config);
        if (File.Exists(ConfigPath))
            return;

        File.WriteAllText(ConfigPath, serialized);
        Logging.Info("Config file has been written to \"" + ConfigPath + "\"");
    }
}

/// <summary>
/// Settings for the Twitch channel which are creating events
/// </summary>
public class TwitchSettings {
    public string ClientId { get; set; } = "Your Client ID";
    public string AccessToken { get; set; } = "Your App Access Token";
}