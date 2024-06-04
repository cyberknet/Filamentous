using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JumpStart.Data.Converters;
public class UriConverter : JsonConverter<Uri?>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.Equals(typeof(Uri));
    }

    public override Uri? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string? value = reader.GetString();
            if (value != null)
                return new Uri(value);
            return null;
        }
        
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        throw new InvalidOperationException("Unhandled json type for UriConverter. Check to see if this converter has been applied to the wrong serialization type.");
    }

    public override void Write(Utf8JsonWriter writer, Uri? value, JsonSerializerOptions options)
    {
        if (value == null)
        { 
            //writer.WriteStringValue()
            return;
        }
        throw new NotImplementedException();
    }
}
