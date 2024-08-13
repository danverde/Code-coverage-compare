using TestCoverageCompare.Models;

namespace TestCoverageCompare.Interfaces;

public interface IReportWriter
{
    /// <summary>
    /// Write an HTML report
    /// </summary>
    /// <returns>the file name of the generated file</returns>
    public string WriteComparison(string outputDir, List<ComparisonSnapshot> snapshots);
}