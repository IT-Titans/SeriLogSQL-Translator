namespace SeriSQLTranslator.Models;

/// <summary>
/// Model which represents a parameter.
/// </summary>
public class ParameterModel
{
    /// <summary>
    /// The parameter number of an parameter. Has the schema "@p" and a number, e.g. "@p3".
    /// </summary>
    public string ParamNumber { get; set; } = string.Empty;
    
    /// <summary>
    /// The value of a parameter.
    /// </summary>
    public string? Value { get; set; } = string.Empty;
}