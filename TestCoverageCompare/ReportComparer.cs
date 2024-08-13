using Ardalis.GuardClauses;
using AutoMapper;
using TestCoverageCompare.Interfaces;
using TestCoverageCompare.Models;

namespace TestCoverageCompare;

public class ReportComparer(ILogger logger, IMapper mapper) : IReportComparer
{
    private readonly ILogger _logger = Guard.Against.Null(logger);
    private readonly IMapper _mapper = Guard.Against.Null(mapper);
    
    public List<ComparisonSnapshot> CompareCoverageReports(List<CodeCoverageReport> reports)
    {
        Guard.Against.NullOrEmpty(reports);

        if (reports.Count < 2)
            throw new Exception("Unable to compare. Fewer than 2 reports found");

        var snapshots = _mapper.Map<List<ComparisonSnapshot>>(reports);
        
        // calc percent diff for files
        for (var i = 1; i < snapshots.Count; i++)
        {
            var snapshot = snapshots[i];
            var previousSnapshot = snapshots[i - 1];

            snapshot.PercentChange = snapshot.CoveragePercent - previousSnapshot.CoveragePercent;
            
            foreach (var project in snapshot.Projects)
            {
                var previousPrj =
                    previousSnapshot.Projects.SingleOrDefault(prj => project.Name == prj.Name);
                
                project.PercentChange =
                    project.CoveragePercent - previousPrj?.CoveragePercent ?? project.CoveragePercent;
            }
        }

        return snapshots;
    }
}