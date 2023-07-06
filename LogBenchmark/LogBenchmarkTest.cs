using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace LogBenchmark
{
    [MemoryDiagnoser]
    public class LogBenchmarkTest
    {
        private readonly ILogger<LogBenchmarkTest> _logger;

        private readonly ILoggerAdapter<LogBenchmarkTest> _loggerAdapter;

        private const string LogMessage = "This is log message";

        private const string LogMessageWithPara = "This is log message with parameters {0}, {1}, {2}";

        private readonly ILoggerFactory _loggerFactory =
                LoggerFactory.Create(builder =>
                    builder
                    .SetMinimumLevel(LogLevel.Warning)
                    .AddSimpleConsole(options =>
                    {
                        options.IncludeScopes = true;
                        options.SingleLine = true;
                        options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
                    }));


        public LogBenchmarkTest()
        {
            _logger = new Logger<LogBenchmarkTest>(_loggerFactory);
            _loggerAdapter = new LoggerAdapter<LogBenchmarkTest>(_logger);
        }

        [Benchmark]
        public void LogWithoutIf()
        {
            _logger.LogInformation(LogMessage);
        }

        [Benchmark]
        public void LogWithIf()
        {
            if(_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(LogMessage);
            }            
        }

        [Benchmark]
        public void LogWithoutIfWithPara()
        {
            _logger.LogInformation(LogMessageWithPara, 69, 411, 5646);
        }

        [Benchmark]
        public void LogWithIfWithPara()
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(LogMessageWithPara, 69, 411, 5646);
            }
        }

        [Benchmark]
        public void LogAdapterWithIfWithPara()
        {
            _loggerAdapter.LogInformation(LogMessageWithPara, 69, 411, 5646);
        }
    }
}
