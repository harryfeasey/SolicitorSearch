using Models;

public interface ISolicitorService
{
    Task<List<Solicitor>> GetSolicitorsByLocation(string location);
}

public class SolicitorService : ISolicitorService
{
    private readonly ISolicitorScraper _solicitorScraper;

    public SolicitorService(ISolicitorScraper solicitorScraper)
    {
        _solicitorScraper = solicitorScraper;
    }

    public async Task<List<Solicitor>> GetSolicitorsByLocation(string location)
    {
        var scrapedData = await _solicitorScraper.ScrapeSolicitorsByLocation(location);
        // Parse scrapedData using solicitor parser and create List<Solicitor>
        throw new NotImplementedException();
    }
}