using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace JumpStart.Localization;
public class LocalizationConfiguration
{
    public static List<CultureInfo> Cultures { get; private set; } = new ();
    public static CultureInfo? DefaultCulture { get; private set; } = null;

    internal static void SetAvailableLanguages(IList<CultureInfo> cultures, CultureInfo? defaultCulture)
    {
        if (defaultCulture != null && !cultures.Contains(defaultCulture))
            cultures.Add(defaultCulture);
        if (defaultCulture == null && cultures.Count > 0)
            defaultCulture = cultures[0];
        DefaultCulture = defaultCulture;
        Cultures.AddRange(cultures);
    }
}
