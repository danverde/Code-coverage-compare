namespace TestCoverageCompare.Models;

public class ReportElement
{
    public string Name { get; set; } = "";
    public string Kind { get; set; } = "";
    public int CoveredStatements { get; set;}
    public int TotalStatements { get; set; }
    public int CoveragePercent { get; set; }
    public List<ReportElement> Children { get; set; } = [];
    
}

public class CodeCoverageReport : ReportElement
{
    public string FileName { get; set; } = "";
    public DateTime LastModified { get; set; }
}
