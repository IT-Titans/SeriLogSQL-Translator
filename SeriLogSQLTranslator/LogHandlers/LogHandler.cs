using Serilog.Events;
using SeriSQLTranslator.Services;

namespace SeriSQLTranslator.LogHandlers;

/// <summary>
/// Custom Log Handler to handle log events from SeriLog.
/// </summary>
public static class LogHandler 
{
    /// <summary>
    /// Method to handle log events. Log event is parsed to sql commands and logged to console. 
    /// </summary>
    /// <param name="logEvent">The log event to be handled.</param>
    public static void HandleLogEvent(LogEvent logEvent)
    {
        var parserService = new ParserService();
        
        string logMessage = logEvent.RenderMessage().Replace("\"", String.Empty);
        string parsedLogMessage = parserService.ParseLogStringToSqlCommand(logMessage);
        
        var consoleFormatter = new ConsoleFormatterService();

        Console.Out.Write(logEvent.Timestamp + " | ");
        consoleFormatter.FormatLogLevelOutput(logEvent);
        Console.Out.Write(parsedLogMessage);
        Console.Out.WriteLine();
    }
}