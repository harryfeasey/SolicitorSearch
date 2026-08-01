using Models;

public interface ISolicitorService
{
    Task<List<Solicitor>> GetSolicitorsByLocation(string location);
    Task<NationalReport> GetSolicitorsReportForAllLocations();
}

public class SolicitorService : ISolicitorService
{
    private readonly ISolicitorScraper _solicitorScraper;
    private readonly ISolicitorParser _solicitorParser;

    public SolicitorService(ISolicitorScraper solicitorScraper, ISolicitorParser solicitorParser)
    {
        _solicitorScraper = solicitorScraper;
        _solicitorParser = solicitorParser;
    }

    public async Task<List<Solicitor>> GetSolicitorsByLocation(string location)
    {
        //Scrape data from solicitors.com for the given location
        var scrapedData = await _solicitorScraper.ScrapeSolicitorsByLocation(location);

        // Parse scrapedData to solicitor parser and create List<Solicitor>
        var solicitors = _solicitorParser.Parse(scrapedData).OrderByDescending(s => s.StarRating).ToList();
        return solicitors;
    }


    public async Task<NationalReport> GetSolicitorsReportForAllLocations()
    {
        //Scrape data from solicitors.com for all locations
        var locations = new List<string>
        {
            "london",
            "birmingham",
            "leeds",
            "manchester",
            "sheffield",
            "bradford",
            "liverpool",
            "bristol"
        };

        var report = new NationalReport();
        var allSolicitors = new List<Solicitor>();

        foreach (var location in locations)
        {
            var scrapedData = await _solicitorScraper.ScrapeSolicitorsByLocation(location);
            var locationSolicitors = _solicitorParser.Parse(scrapedData).OrderByDescending(s => s.StarRating).ToList();
            
            report.LocationReports.Add(new LocationReport
            {
                Location = location,
                TopSolicitors = locationSolicitors.Take(10).ToList(),
                AverageStarRating = locationSolicitors.Where(s => s.StarRating.HasValue).Select(s => s.StarRating.Value).DefaultIfEmpty(0).Average()
            });

            allSolicitors.AddRange(locationSolicitors);
        }

        report.TopSolicitors = allSolicitors.OrderByDescending(s => s.StarRating).Take(10).ToList();
        report.LocationReports = report.LocationReports.OrderByDescending(x => x.AverageStarRating).ToList();
        return report;
    }
}