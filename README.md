

# SeriLogSQL-Translator

SeriLogSQL Translator is a dynamic tool designed to translate SeriLog log strings into SQL commands. It also outputs these SQL commands for further utilization. It uses parameters as placeholders that are replaced with the accurate values during the parsing phase.

## Features

### Custom Console Sink Integration
The tool can be integrated directly into SeriLog. This feature enables the interception of logs directly by the sink, allowing them to be translated as desired and displayed as a log in the console.

## Installation

1. Clone the repository to your local machine
2. Open the project in your IDE

For integration with SeriLog:

Implement SeriLog as Logger in your project and configure the logging sink for your project like this:


```csharp
Log.Logger = new LoggerConfiguration()  
.WriteTo.Sink(new ConsoleLogParsingSink())  
.CreateLogger();
```		
   The sink to use is called ```ConsoleLogParsingSink```.

## Usage

### Custom Console Sink Integration

1. Ensure the custom console sink has been correctly integrated with 
2. SeriLog according to the installation instructions
3. In SeriLog, generate the logs you wish to translate.
4. The translated SQL commands will be automatically outputted to the console.


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
