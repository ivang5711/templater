# templater



![Static Badge](https://img.shields.io/badge/dotnet-stanatd%202.0-blue)

<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="c#" height="28px"> <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" alt=".NET" height="28px"> 


The Templater library generates HTML based on a template provided.

The app consists of a **class library** and 
a **console app**.

The Templater Library targets **.NET Standard 2.0** and is highly compatible accross all .NET and .NET Framewoek versions.

## How to build and run

1. In your terminal window go the folder containing the TemplaterApp.\
Assume this is Documents/Templater/TemplaterConsole in a user's home directory:
>This will work for Bash and PowerShell both on Linux and Windows:
>```
>cd ~/Documents/Templater/TemplaterConsole
>```

2. Build the app with the following command:
>```
>dotnet build
>```
3. Run the app with the following command:
>```
>dotnet run
>```
4. To use the app you also have to pass command line arguments on start.


>```
>dotnet run [templateFilePath] [dataFilePath] [outputFilePath]
>```

## Dependencies

- the Templater Library targets **.Net Standard 2.0** specification
- The Console App targets **.NET 8**
- The Templater Library uses <a href="https://github.com/sebastienros/fluid">Fluid.Core</a> to work with template
- The Templater Library uses <a href="https://www.newtonsoft.com/json">Newtonsoft.Json</a> to work with data in JSON.
