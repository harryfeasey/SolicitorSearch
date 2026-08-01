using Models;

public class LocationReport
{
    public string Location { get; set; } = string.Empty;
    public List<Solicitor> TopSolicitors { get; set; } = new List<Solicitor>();
    public double? AverageStarRating { get; set; }
}