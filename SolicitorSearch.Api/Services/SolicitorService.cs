using Models;

public interface ISolicitorService
{
    Task<List<Solicitor>> GetSolicitorsByLocation(string location);
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
        var solicitors = _solicitorParser.Parse(scrapedData).ToList();
        return solicitors;
    }
}