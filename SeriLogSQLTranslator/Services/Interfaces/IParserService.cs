namespace SeriSQLTranslator.Services.Interfaces;

/// <summary>
/// Service to parse an input log string to sql commands. Parameters from the log are placed in the sql command.
/// </summary>
public interface IParserService
{
    /// <summary>
    /// A log string is parsed to a sql command. Placeholder parameters from the sql command are replaced from the log string.
    /// </summary>
    /// <param name="logString">The log string which contains sql commands and parameters to be replaced.</param>
    /// <returns></returns>
    string ParseLogStringToSqlCommand(string logString);
}