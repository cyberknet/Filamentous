using JumpStart;
using JumpStart.Localization;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder;
public static class WebApplicationExtensions
{
    public static void UseJumpstart(this WebApplication app, Action<JumpStartOptions> options)
    {
        app.MapControllers();

        JumpStartOptions opt = new JumpStartOptions();
        options.Invoke(opt);
        
        LocalizationConfiguration.SetAvailableLanguages(opt.Cultures, opt.DefaultCulture);

        if (opt.DefaultCulture != null)
        { 
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(opt.DefaultCulture),
                SupportedCultures = opt.Cultures,
                SupportedUICultures = opt.Cultures,
                RequestCultureProviders = [new QueryStringRequestCultureProvider(), new CookieRequestCultureProvider()]
            });
        }
    }
    
}
