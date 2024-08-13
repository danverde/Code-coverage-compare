using System.Text;
using Ardalis.GuardClauses;
using TestCoverageCompare.Interfaces;
using TestCoverageCompare.Models;

namespace TestCoverageCompare;

public class ReportWriter(ILogger logger) : IReportWriter
{
    private readonly ILogger _logger = Guard.Against.Null(logger);
    
    public string WriteComparison(string outputDir, List<ComparisonSnapshot> snapshots)
    {
        Guard.Against.NullOrWhiteSpace(outputDir);
        Guard.Against.NullOrEmpty(snapshots);

        var docString = GenerateDocString(snapshots);

        string filePath = GetFilePath(outputDir);
        
        File.WriteAllText(filePath, docString);

        return filePath;
    }

    private string GenerateDocString(List<ComparisonSnapshot> snapshots)
    {
        StringBuilder htmlBuilder = new StringBuilder();

        htmlBuilder.Append("""
                               <!DOCTYPE html>
                               <html>
                               <head>
                                   <title>Compare Code Coverage</title
                               </head>
                               <body>
                               <h1>Code Coverage Comparison</h1>
                               <table>
                           """);
        
        WriteTableHeader(htmlBuilder, snapshots);
        WriteTableBody(htmlBuilder, snapshots);
        
        htmlBuilder.Append("""
                           </body>
                           </html>
                           """);

        return htmlBuilder.ToString();
    }

    private void WriteTableHeader(StringBuilder sb, List<ComparisonSnapshot> snapshots)
    {
        throw new NotImplementedException();
        foreach (var snapshot in snapshots)
        {
        }
    }

    private void WriteTableBody(StringBuilder sb, List<ComparisonSnapshot> snapshots)
    {
        throw new NotImplementedException();
    }
    
    private string GetFilePath(string outputDir)
    {
        var i = 1;
        
        // TODO what exactly does DateTime.Now print?
        const string extension = ".html";
        var fileNameBase = $"CoverageReport_{DateTime.Now}";
        var fileName = fileNameBase + extension;

        while (File.Exists(Path.Join(outputDir, fileName)))
        {
            fileName = $"{fileNameBase}_{i}{extension}";
            i++;
        }

        return Path.Join(outputDir, fileName);
    }
}