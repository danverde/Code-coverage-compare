// See https://aka.ms/new-console-template for more information

using AutoMapper;
using TestCoverageCompare;
using TestCoverageCompare.Interfaces;
using TestCoverageCompare.Mappings;
using TestCoverageCompare.Models;

// define constants
const string outputDir = "/Users/verde/repos/code-coverage-reports/output";
const string reportDir = "/Users/verde/repos/code-coverage-reports";

// Init classes
ILogger logger = new Logger();
IMapper mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())));
IReportReader reportReader = new ReportReader(logger);
IReportComparer reportComparer = new ReportComparer(logger, mapper);
IReportWriter reportWriter = new ReportWriter(logger);

// Run App
try
{
    logger.Info($"Start using reports in: {reportDir}");

    // Read Reports
    List<CodeCoverageReport> reports = await reportReader.ReadReportsAsync(reportDir);
    logger.Info($"Found {reports.Count} reports.\nComparing Code Coverage");

    List<ComparisonSnapshot> snapshots = reportComparer.CompareCoverageReports(reports);
    logger.Info("Comparison Complete. Generating Report");
    
    string filePath = reportWriter.WriteComparison(outputDir, snapshots);
    logger.Success($"HTML document created at {filePath}");
    
    logger.Info("Done");
}
catch (Exception ex)
{
    logger.Error(ex);
}


