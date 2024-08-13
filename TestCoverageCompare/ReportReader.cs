using Ardalis.GuardClauses;
using Newtonsoft.Json;
using TestCoverageCompare.Interfaces;
using TestCoverageCompare.Models;

namespace TestCoverageCompare;

public class ReportReader(ILogger logger) : IReportReader
{
    private readonly ILogger _logger = Guard.Against.Null(logger);
    
    public async Task<List<CodeCoverageReport>> ReadReportsAsync(string folderPath)
    {
        Guard.Against.NullOrWhiteSpace(folderPath);
        
         List<FileInfo> files = GetReportFiles(folderPath);

        var reports = new List<CodeCoverageReport>();
        
        foreach (var file in files)
        {
            string text = await File.ReadAllTextAsync(file.FullName);
            CodeCoverageReport report;
            try
            {
                report = JsonConvert.DeserializeObject<CodeCoverageReport>(text) ?? throw new Exception($"Unable to parse file. Skipping: {file.Name}");
            }
            catch (Exception ex)
            {
                _logger.Warn($"Unable to parse file. Skipping: {file.Name}");
                continue;
            }
            
            report.FileName = file.Name;
            report.LastModified = file.LastWriteTime;
            
            reports.Add(report);
        }

        return reports;
    }

    private List<FileInfo> GetReportFiles(string dirPath)
    {
        Guard.Against.NullOrWhiteSpace(dirPath);
        
        FileInfo[] files = new DirectoryInfo(dirPath).GetFiles();

        // Sort files by LastWriteTime
        List<FileInfo> sortedFiles = files
            .Where(f => f.Extension.Equals(".json"))
            .OrderBy(f => f.LastWriteTime) // TODO might need to be order by descending
            .ToList();

        return sortedFiles;
    }
}