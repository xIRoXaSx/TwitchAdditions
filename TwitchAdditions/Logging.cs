namespace TwitchAdditions; 

public static class Logging {
    /// <summary>
    /// Log debug information.
    /// </summary>
    /// <param name="text">The text to log</param>
    public static void Debug(string text) {
        var colorBeforeChange = Console.ForegroundColor;
        Console.Write("[" + GetLogDateString() + "] ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("DBG: ");
        Console.ForegroundColor = colorBeforeChange;
        Console.WriteLine(text);
    }
    
    /// <summary>
    /// Log information.
    /// </summary>
    /// <param name="text">The text to log</param>
    public static void Info(string text) {
        var colorBeforeChange = Console.ForegroundColor;
        Console.Write("[" + GetLogDateString() + "] ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("DBG: ");
        Console.ForegroundColor = colorBeforeChange;
        Console.WriteLine(text);
    }
    
    /// <summary>
    /// Log errors.
    /// </summary>
    /// <param name="text">The text to log</param>
    public static void Error(string text) {
        var colorBeforeChange = Console.ForegroundColor;
        Console.Write("[" + GetLogDateString() + "] ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("ERR: ");
        Console.ForegroundColor = colorBeforeChange;
        Console.WriteLine(text);
    }
    
    /// <summary>
    /// Log warnings.
    /// </summary>
    /// <param name="text">The text to log</param>
    public static void Warn(string text) {
        var colorBeforeChange = Console.ForegroundColor;
        Console.Write("[" + GetLogDateString() + "] ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("ERR: ");
        Console.ForegroundColor = colorBeforeChange;
        Console.WriteLine(text);
    }

    /// <summary>
    /// Gets the date and time for console logging (eg.: 2021-05-21 09:00:01)
    /// </summary>
    private static string GetLogDateString() {
        return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    /// <summary>
    /// Gets the date and time for file logging (eg.: 2021-05-21_09-00-01)
    /// </summary>
    public static string GetLogFileDateString() {
        return DateTime.Now.ToString("yyyy-MM-dd");
    }
}