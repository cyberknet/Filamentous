using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder;
public static class WebApplicationExtensions
{
    public static void UseJumpstart(this WebApplication app)
    {
        app.MapControllers();
    }
    
}
