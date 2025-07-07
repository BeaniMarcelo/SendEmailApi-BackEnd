using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SendEmailApi.Common
{
    public enum LogLevel
    {
        Debug,
        Trace,
        Warning,
        Major
    }

    public class Logger
    {
        private static string _logDirectory;
        private static readonly object _lock = new();

        static Logger()
        {
            // Carrega configuração apenas uma vez
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            _logDirectory = config["Logger:LogDirectory"] ?? "Logs";
            if (!Directory.Exists(_logDirectory))
                Directory.CreateDirectory(_logDirectory);
        }

        public static void Log(string message, LogLevel level = LogLevel.Debug)
        {
            var logFile = Path.Combine(_logDirectory, $"{DateTime.UtcNow:yyyyMMdd}.log");
            var logEntry = $"{DateTime.UtcNow:O} [{level}] {message}{Environment.NewLine}";

            lock (_lock)
            {
                File.AppendAllText(logFile, logEntry);
            }
        }
    }
}