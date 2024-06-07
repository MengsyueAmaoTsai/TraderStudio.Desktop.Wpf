using Microsoft.Extensions.Hosting;

namespace RichillCapital.Logging;

public static class LoggingExtensions
{
    private const string ConsoleTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} - {Message:lj}{NewLine}{Exception}{NewLine}";
    private const string FileTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] [TraceId: {TraceId}] [MachineName: {MachineName}] [ProcessId: {ProcessId}] {Message:lj}{NewLine}{Exception}";
    private const string LogDirectory = "Logs";

    public static IHostBuilder UseTraderStudioDesktopLogger(this IHostBuilder builder)
    {
        return builder;
    }
}
