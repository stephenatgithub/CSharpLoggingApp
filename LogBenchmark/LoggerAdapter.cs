using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBenchmark
{
    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {   
        private ILogger<T> _logger;
        public LoggerAdapter(ILogger<T> logger)
        {
            _logger = logger;
        }

        void ILoggerAdapter<T>.LogInformation(string message)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message);
            }
        }

        void ILoggerAdapter<T>.LogInformation<T0>(string message, T0 arg0)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message, arg0);
            }
        }

        void ILoggerAdapter<T>.LogInformation<T0, T1>(string message, T0 arg0, T1 arg1)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message, arg0, arg1);
            }
        }

        void ILoggerAdapter<T>.LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message, arg0, arg1, arg2);
            }
        }
    }


    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message);

        void LogInformation<T0>(string message, T0 arg0);

        void LogInformation<T0, T1>(string message, T0 arg0, T1 arg1);

        void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);
    }
}
