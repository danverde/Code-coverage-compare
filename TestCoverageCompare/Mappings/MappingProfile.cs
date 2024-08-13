using AutoMapper;
using TestCoverageCompare.Models;

namespace TestCoverageCompare.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<ReportElement, SnapshotBase>()
            .ForMember(dest => dest.PercentChange, opt => opt.Ignore());

        CreateMap<CodeCoverageReport, ComparisonSnapshot>()
            .ForMember(dest => dest.PercentChange, opt => opt.Ignore())
            .ForMember(dest => dest.Projects,
                opt => opt.MapFrom(src => src.Children.Where(c => c.Kind.Equals(Constants.Project))));
    }
}