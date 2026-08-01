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

        //Simulate a browser request to avoid being blocked by the website.
        _httpClient.DefaultRequestHeaders.Add(
            "User-Agent",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/150.0.0.0 Safari/537.36");
        
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