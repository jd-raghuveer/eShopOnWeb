using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.eShopWeb.Web;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value == null) { return null; }
        string? str = value.ToString();
        if (string.IsNullOrEmpty(str)) { return null; }

        // Slugify value
        var pattern = "([a-z])([A-Z])";
        var replacement = "$1-$2";
        var timeout = TimeSpan.FromSeconds(1); // Set appropriate timeout

        string result = Regex.Replace(str, pattern, replacement, RegexOptions.None, timeout).ToLower();

    }
}
