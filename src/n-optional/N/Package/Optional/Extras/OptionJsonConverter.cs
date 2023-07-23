using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.VisualScripting;

namespace N.Package.Optional.Extras
{
  /// Use it like this:
  /// 
  ///     [JsonConverter(typeof(OptionJsonConverter<Bar>))]
  ///     public Option<Bar> Value { get; set; }
  ///
  /// If you don't have the JSON.Net namespace, delete this or reference it in the package manager.
  /// see: https://github.com/jilleJr/Newtonsoft.Json-for-Unity/wiki/Install-official-via-UPM#installing-the-package-via-upm-window
  public  class OptionJsonConverter<T> : JsonConverter<Option<T>>
  {
    public override void WriteJson(JsonWriter writer, Option<T> value, JsonSerializer serializer)
    {
      if (value.None)
      {
        writer.WriteNull();
      }
      else
      {
        serializer.Serialize(writer, value.Unwrap());
      }
    }

    public override Option<T> ReadJson(JsonReader reader, Type objectType, Option<T> existingValue, bool hasExistingValue,
      JsonSerializer serializer)
    {
      var value = serializer.Deserialize<T>(reader);
      return value == null ? Option.None<T>() : Option.Some(value);
    }
  }
}