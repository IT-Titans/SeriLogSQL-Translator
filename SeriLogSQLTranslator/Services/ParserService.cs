using System.Text.RegularExpressions;
using SeriSQLTranslator.Models;
using SeriSQLTranslator.Services.Interfaces;

namespace SeriSQLTranslator.Services;

/// <inheritdoc cref="IParserService"/>
public class ParserService : IParserService
{
    private readonly List<string> _sqlCommandList = new List<string>
    {
        "INSERT",
        "UPDATE",
        "DELETE",
        "SELECT",
        "ALTER",
        "CREATE",
        "DROP",
    };

    public string ParseLogStringToSqlCommand(string logString)
    {
        string updatedLogString;
        if (CheckIfLogMustBeParsed(logString))
        {
            int endOfLogIntroduction = logString.IndexOf(')');
            string logIntroduction = logString.Substring(0, endOfLogIntroduction + 2);
            updatedLogString = logIntroduction;

            logString = logString.Replace(" \r\n ", String.Empty);
            if (logString.Contains("@__p_"))
            {
                logString = ParseParameterSchema(logString);
            }

            var parameters = ExtractParametersFromLog(logString);
            var sqlCommands = GetSqlCommandsFromLog(logString);
            sqlCommands = ReplacePlaceholdersInSqlCommands(sqlCommands, parameters);

            foreach (var command in sqlCommands)
            {
                if (command.Command != "")
                {
                    updatedLogString = updatedLogString + command.Command + "\r\n ";
                }
            }
        }
        else
        {
            updatedLogString = logString;
        }

        return updatedLogString;
    }
    
    private bool CheckIfLogMustBeParsed(string logString)
    {
        if (!_sqlCommandList.Any(logString.Contains))
        {
            return false;
        }

        if (logString.StartsWith("info:"))
        {
            return false;
        }

        return true;
    }

    private List<SqlCommand> GetSqlCommandsFromLog(string logString)
    {
        List<SqlCommand> sqlCommands = new List<SqlCommand>();
        var logSplitted = Regex.Split(logString, @"\b");

        foreach (var command in _sqlCommandList)
        {
            for (int i = 0; i < logSplitted.Length; i++)
            {
                if (command == logSplitted[i])
                {
                    string singleCommand = "";
                    string commandEndMarker = ";";
                    for (int j = i; j < logSplitted.Length; j++)
                    {
                        if (logSplitted[j].EndsWith(commandEndMarker))
                        {
                            singleCommand += logSplitted[j];
                            break;
                        }

                        singleCommand += logSplitted[j];
                        i = j;
                    }

                    sqlCommands.Add(CreateSqlCommand(singleCommand));
                }
            }
        }

        return sqlCommands;
    }

    private SqlCommand CreateSqlCommand(string commandString)
    {
        SqlCommand command = new SqlCommand
        {
            Command = commandString
        };

        return command;
    }


    private List<ParameterModel> ExtractParametersFromLog(string logString)
    {
        List<ParameterModel> parameters = new List<ParameterModel>();

        for (int i = 0; i < logString.Length; i++)
        {
            string paramNumber = $"@p{i}='";
            if (!logString.Contains(paramNumber))
            {
                break;
            }

            int startIndex = logString.IndexOf(paramNumber, StringComparison.Ordinal);
            int endIndex = logString.IndexOf("'", startIndex + paramNumber.Length, StringComparison.Ordinal);

            if (startIndex != -1 && endIndex != -1)
            {
                int substringStart = startIndex + paramNumber.Length;
                int substringLength = endIndex - substringStart;
                string extractedSubstring = logString.Substring(substringStart, substringLength);

                ParameterModel parameterModel = new ParameterModel
                {
                    ParamNumber = $"@p{i}",
                    Value = extractedSubstring
                };

                parameters.Add(parameterModel);
            }
        }

        return parameters;
    }

    private string ParseParameterSchema(string logString)
    {
        logString = Regex.Replace(logString, "@__p_", "@p");
        return logString;
    }

    private List<SqlCommand> ReplacePlaceholdersInSqlCommands(List<SqlCommand> sqlCommands,
        List<ParameterModel> parameters)
    {
        foreach (var sqlCommand in sqlCommands)
        {
            string replacedCommand = sqlCommand.Command;

            foreach (var parameter in parameters)
            {
                string pattern = $@"(?<!\w){Regex.Escape(parameter.ParamNumber)}(?!\w)";

                replacedCommand = Regex.Replace(replacedCommand, pattern, $"'{parameter.Value}'");
            }

            sqlCommand.Command = replacedCommand;
        }

        return sqlCommands;
    }
}