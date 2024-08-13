using TestCoverageCompare.Models;

namespace TestCoverageCompare.Interfaces;

public interface IReportComparer
{
    public List<ComparisonSnapshot> CompareCoverageReports(List<CodeCoverageReport> reports);
}