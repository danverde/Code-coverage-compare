using TestCoverageCompare.Models;

namespace TestCoverageCompare.Interfaces;

public interface IReportReader
{
    public Task<List<CodeCoverageReport>> ReadReportsAsync(string folderPath);
}