using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace TwitchAdditions; 

public class Parser {
    /// <summary>
    /// Serialize an object to a yaml string.
    /// </summary>
    /// <param name="objectToSerialize">The object to serialize</param>
    public static string Serialize(object objectToSerialize) {
        var serializer = new SerializerBuilder()
            .WithNamingConvention(PascalCaseNamingConvention.Instance)
            .Build();
        return serializer.Serialize(objectToSerialize);
    }
}