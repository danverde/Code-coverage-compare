namespace TestCoverageCompare.Models;

public class SnapshotBase
{
    public string Name { get; set; } = "";
    public int CoveragePercent { get; set; }
    public int PercentChange { get; set; }
    
    // TODO might be worth adding covered & uncovered lines!
}

public class ComparisonSnapshot : SnapshotBase
{
    public DateTime LastModified { get; set; }
    public List<SnapshotBase> Projects { get; set; } = new ();
}