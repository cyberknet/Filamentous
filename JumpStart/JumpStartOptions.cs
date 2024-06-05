using JumpStart.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStart;
public class JumpStartOptions
{
    public CultureInfo? DefaultCulture { get; set; } = null;
    public List<CultureInfo> Cultures { get; set; } = new ();

    public JumpStartOptions()
    {
    }
    public JumpStartOptions(CultureInfo[] cultures) : this()
    {
        Cultures.AddRange(cultures);
    }
    public JumpStartOptions(CultureInfo[] cultures, CultureInfo defaultCulture) : this(cultures)
    {
        if (!cultures.Contains(defaultCulture))
            Cultures.Add(defaultCulture);
        DefaultCulture = defaultCulture;
    }
}
