using Serilog.Events;
using SeriSQLTranslator.Services;

namespace SeriSQLTranslator.LogHandlers;

public static class LogHandler 
{
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