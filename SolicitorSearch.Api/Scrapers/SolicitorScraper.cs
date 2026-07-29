public interface ISolicitorScraper
{
    Task<string> ScrapeSolicitorsByLocation(string location);
}

class SolicitorScraper : ISolicitorScraper
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public SolicitorScraper(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<string> ScrapeSolicitorsByLocation(string location)
    {
        var url = $"{_config["SolicitorsCom:BaseUrl"]}/{location}-solicitors.html";
        throw new NotImplementedException();
    }
}