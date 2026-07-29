using Models;

public interface ISolicitorParser
{
    IEnumerable<Solicitor> Parse(string html);
}

public class SolicitorParser : ISolicitorParser
{
    public IEnumerable<Solicitor> Parse(string html)
    {
        var results = new List<Solicitor>();

        const string listingStart = "<div class=\"result-item\">";

        foreach (var entryHtml in html.Split(listingStart, StringSplitOptions.RemoveEmptyEntries))
        {

            results.Add(new Solicitor
            {
                Name = Extract(entryHtml, "<h2>", "</h2>"),
                PhoneNumber = Extract(entryHtml, "<span class=\"phone\">", "</span>")
            });

        }

        return results;
    }

    private static string Extract(string html, string startTag, string endTag)
    {
        int startIndex = html.IndexOf(startTag, StringComparison.OrdinalIgnoreCase);

        if (startIndex == -1)
            return string.Empty;

        startIndex += startTag.Length;

        int endIndex = html.IndexOf(endTag, startIndex, StringComparison.OrdinalIgnoreCase);

        if (endIndex == -1)
            return string.Empty;

        return html[startIndex..endIndex].Trim();
    }
}