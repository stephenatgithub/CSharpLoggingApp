# C# Logging

## Program.cs

Call WebApplication.CreateBuilder, which adds the following default logging providers:
- Console
- Debug
- EventSource
- EventLog: Windows only


## Providers aliases

The built-in providers aliases are:
- Console
- Debug
- EventSource
- EventLog
- AzureAppServicesFile
- AzureAppServicesBlob
- ApplicationInsights


## Logging Level

Trace = 0, Debug = 1, Information = 2, Warning = 3, Error = 4, Critical = 5, and None = 6.


## Structured event logging

- Serilog.AspNetCore
- Serilog.Enrichers.Environment
- Serilog.Enrichers.Process
- Serilog.Enrichers.Thread
- Serilog.Settings.Configuration
- Serilog.Sinks.Seq


## Docker

`docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest`

to save log files in harddisk, but not container storage
`-v <path>`

[Seq Localhost](http://localhost:8081)



## Performance

Even if the debug level is lower and log message is hidden, the logger code is still run and the heap memory is allocated. This affects performance and wastes memory.


|                   Method |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|------------------------- |-----------:|----------:|----------:|-------:|----------:|
|             LogWithoutIf |  40.015 ns | 0.8198 ns | 1.8336 ns |      - |         - |
|                LogWithIf |   8.751 ns | 0.2091 ns | 0.2489 ns |      - |         - |
|     LogWithoutIfWithPara | 139.208 ns | 2.8145 ns | 5.0029 ns | 0.0572 |     120 B |
|        LogWithIfWithPara |   8.608 ns | 0.2024 ns | 0.2409 ns |      - |         - |
| LogAdapterWithIfWithPara |  17.577 ns | 0.3862 ns | 0.4597 ns |      - |         - |

