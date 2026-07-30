using System.Text.RegularExpressions;
using Models;

public interface ISolicitorParser
{
    IEnumerable<Solicitor> Parse(string html);
}

public class SolicitorParser : ISolicitorParser
{
    public IEnumerable<Solicitor> Parse(string html)
    {
        var parsedEntries = new List<Solicitor>();

        foreach (var match in html.Split("<div class=\"result-item").Skip(1))
        {
            Console.WriteLine($"Match value: {match.Trim()}");
            var block = match.Trim();

            var solicitor = new Solicitor
            {
                Name = Extract(block, "<span class=\"h2\">(.*?)<div"),
                PhoneNumber = Extract(block, "href=\"tel:[^\"]+\">(.*?)</a>"),
                Address = Extract(block, "<address>(.*?)</address>")
            };

            PopulateAddressParts(solicitor);

            parsedEntries.Add(solicitor);
        }
        return parsedEntries;
    }

    private static string Extract(string html, string valueRegex)
    {
        var match = Regex.Match(
            html,
            valueRegex,
            RegexOptions.Singleline);

        return Clean(match.Groups[1].Value);
    }


    private static void PopulateAddressParts(Solicitor solicitor)
    {
        var parts = solicitor.Address
            .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length >= 2)
        {
            solicitor.City = parts[^2];
            solicitor.Postcode = parts[^1];
        }
    }

    private static string Clean(string value)
    {
        value = Regex.Replace(value, "<.*?>", string.Empty);
        var decoded = System.Net.WebUtility.HtmlDecode(value);
        return decoded.Replace('\u00A0', ' ').Trim();
    }
}