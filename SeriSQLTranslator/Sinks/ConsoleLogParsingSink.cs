using Serilog.Core;
using Serilog.Events;
using SeriSQLTranslator.LogHandlers;

namespace SeriSQLTranslator.Sinks;

/// <summary>
/// A custom console sink that offers a custom log handler for handling the LogEvent.
/// The sink needs to be given to SeriLog as sink to be logged to.
/// </summary>
public class ConsoleLogParsingSink : ILogEventSink
{

    /// <summary>
    /// Method for delegating the LogEvent to the custom log handler. 
    /// </summary>
    /// <param name="logEvent">LogEvent to be handled.</param>
    public void Emit(LogEvent logEvent)
    {
        LogHandler.HandleLogEvent(logEvent);
    }
}