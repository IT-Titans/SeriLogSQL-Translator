# SeriLogSQL-Translator

SeriLogSQL Translator is a dynamic tool designed to translate SeriLog log strings into SQL commands using a GUI. It also outputs these SQL commands for further utilization. It uses parameters as placeholders that are replaced with the accurate values during the parsing phase.

## Features

### GUI-based Translation
Allows you to interactively translate SeriLog log strings into SQL commands. Just paste the log string into the provided field, and the tool will generate the corresponding SQL commands. 

### Custom Console Sink Integration
The tool can be integrated directly into SeriLog without the need to use the GUI. This feature enables the interception of logs directly by the sink, allowing them to be translated as desired and displayed as a log in the console.

## Installation

<ol>
	<li>Clone the repository to your local machine</li>
 	<li>Open the project in your IDE</li>
</ol>

For integration with SeriLog:

Implement SeriLog as Logger in your project and configure the logging sink for your project like this:


```csharp
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Sink(new CustomConsoleSink(logHandler))
            .CreateLogger();
```		
   The sink to use is called "CustomConsoleSink" and it expects an Action of type ```LogEvent``` as parameter.

## Usage

### GUI-based Translation

<ol> 
<li>Open the SeriLog Translator GUI.</li>
<li>In the input field, paste or type the SeriLog string you wish to translate.</li>
<li>. Click the 'Parse' button.</li>
<li>. The translated SQL commands will appear in the output field. You can copy these for use in your SQL environment</li></ol>

### Custom Console Sink Integration

<ol>
<li>Ensure the custom console sink has been correctly integrated with SeriLog according to the installation instructions</li>
<li>In SeriLog, generate the logs you wish to translate.</li>
<li>The translated SQL commands will be automatically outputted to the console.</li>
</ol>

## Contributing

While we currently do not have an open call for contributions, we truly value the power of the developer community. We encourage you to explore the SeriLog Translator, test it, and share your feedback. This would immensely help us to improve the tool and provide a superior experience. For any feedback, feel free to raise an issue in the repository or reach out to us directly.

## License

MIT License

Copyright (c) 2023 IT Titans GmbH

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
