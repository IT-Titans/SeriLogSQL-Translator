using Serilog.Events;

namespace SeriSQLTranslator.Services;

/// <summary>
/// Service to Format parts of the console.
/// </summary>
public class ConsoleFormatterService
{
    /// <summary>
    /// Format and outputs the LogLevel in the console depending of the LogEvent.
    /// </summary>
    /// <param name="logEvent">The LogEvent where console parts should be formatted.</param>
    public void FormatLogLevelOutput(LogEvent logEvent)
    {
        switch (logEvent.Level)
        {
            case LogEventLevel.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case LogEventLevel.Information:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case LogEventLevel.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case LogEventLevel.Debug:
                Console.ForegroundColor = ConsoleColor.DarkGray;
                break;
            case LogEventLevel.Verbose:
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
            case LogEventLevel.Fatal:
                Console.ForegroundColor = ConsoleColor.Red;
                break;

            default:
                Console.ResetColor();
                break;
        }

        Console.Out.Write(logEvent.Level);
        Console.ResetColor();
        Console.Out.Write(" | ");
    }
}