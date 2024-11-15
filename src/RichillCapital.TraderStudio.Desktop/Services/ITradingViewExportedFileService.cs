using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.TraderStudio.Desktop.Services;

public interface ITradingViewExportedFileService
{
    Result<IEnumerable<TradingViewTradeRecord>> ReadListOfTrades(string filePath);
}

internal sealed class TradingViewExportedFileService : ITradingViewExportedFileService
{
    private const int ExpectedColumns = 14;
    private const char ColumnSeparator = ',';
    private const string DateTimeFormat = "yyyy-MM-dd HH:mm";

    private static readonly Regex FileNamePattern = new(@"^.*_List_of_Trades_\d{4}-\d{2}-\d{2}\.[a-zA-Z0-9]+$", RegexOptions.Compiled);
    
    private static readonly Result<IEnumerable<TradingViewTradeRecord>> InvalidFileNameResult = Result<IEnumerable<TradingViewTradeRecord>>.Failure(Error.Invalid("Invalid file name"));

    public Result<IEnumerable<TradingViewTradeRecord>> ReadListOfTrades(string listOfTradesFile)
    {
        if (!FileNamePattern.IsMatch(listOfTradesFile))
        {
            return InvalidFileNameResult;
        }

        using var reader = new StreamReader(listOfTradesFile);

        var records = new List<TradingViewTradeRecord>();

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();

            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            var fields = line.Split(ColumnSeparator);

            if (fields.Length != ExpectedColumns || 
                !int.TryParse(fields[0], out _))
            {
                continue;
            }

            records.Add(new TradingViewTradeRecord
            {
                TradeNumber = int.Parse(fields[0]),
                Type = fields[1],
                Signal = fields[2],
                DateTime = DateTimeOffset.ParseExact(
                    fields[3], 
                    DateTimeFormat,
                    CultureInfo.InvariantCulture, 
                    DateTimeStyles.AssumeUniversal),
                Price = decimal.Parse(fields[4]),
                Contracts = decimal.Parse(fields[5]),
                Profit = decimal.Parse(fields[6]),
                ProfitPercent = decimal.Parse(fields[7]),
                CumulativeProfit = decimal.Parse(fields[8]),
                CumulativeProfitPercent = decimal.Parse(fields[9]),
                RunUp = decimal.Parse(fields[10]),
                RunUpPercent = decimal.Parse(fields[11]),
                Drawdown = decimal.Parse(fields[12]),
                DrawdownPercent = decimal.Parse(fields[13]),
            });
        }

        records.Reverse();

        return Result<IEnumerable<TradingViewTradeRecord>>.With(records);
    }
}

public sealed record TradingViewTradeRecord
{
    public required int TradeNumber { get; init; }
    public required string Type { get; init; }
    public required string Signal { get; init; }
    public required DateTimeOffset DateTime { get; init; }
    public required decimal Price { get; init; }
    public required decimal Contracts { get; init; }
    public required decimal Profit { get; init; }
    public required decimal ProfitPercent { get; init; }
    public required decimal CumulativeProfit { get; init; }
    public required decimal CumulativeProfitPercent { get; init; }
    public required decimal RunUp { get; init; }
    public required decimal RunUpPercent { get; init; }
    public required decimal Drawdown { get; init; }
    public required decimal DrawdownPercent { get; init; }
}
