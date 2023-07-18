namespace SeriSQLTranslator.Models;

/// <summary>
/// Model which represents an sql command. 
/// </summary>
public class SqlCommand
{
    /// <summary>
    /// The command string of an sql command containing sql keywords and parameters.
    /// </summary>
    public string Command { get; set; } = string.Empty;
}