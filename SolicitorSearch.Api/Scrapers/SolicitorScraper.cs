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
        var url = GetUrlForLocation(location);
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Failed to scrape solicitors for location {location}. Status code: {response.StatusCode}");

        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    private string GetUrlForLocation(string location)
    {
        return $"{_config["SolicitorsCom:BaseUrl"]}/{location}-solicitors.html";
    }
}