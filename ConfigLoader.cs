using System;
using System.IO;
using System.Text.Json;

public static class ConfigLoader
{
    public static string DefaultConfigPath
    {
        get
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "Content", "configs", "DefaultConfig.json");
        }
    }

    public static T LoadConfigJSON<T>(string configPath=null)
    {
        if (configPath == null)
            configPath = DefaultConfigPath;

        try
        {
            string text = File.ReadAllText(configPath);
            return JsonSerializer.Deserialize<T>(text);
        }
        catch(DirectoryNotFoundException)
        {
            throw new Exception($"Could not find config on path: {configPath}");
        }
    }

    public static void SavePropertyToVariable<T>(JsonElement property, out T variable)
    {
        var variableType = typeof(T);

        if (variableType == typeof(int))
        {
            if (property.ValueKind != JsonValueKind.Number)
                throw new Exception("Impossible cast property to int");

            variable = (T)(object)property.GetInt32();
        }
        else if (variableType == typeof(float))
        {
            if (property.ValueKind != JsonValueKind.Number)
                throw new Exception("Impossible cast property to float");

            variable = (T)(object)property.GetSingle();
        }
        else if (variableType == typeof(string))
        {
            if (property.ValueKind != JsonValueKind.String)
                throw new Exception("Impossible cast property to string");

            variable = (T)(object)property.GetString();
        }
        else if (variableType == typeof(bool))
        {
            if (property.ValueKind != JsonValueKind.True && property.ValueKind != JsonValueKind.False)
                throw new Exception("Impossible cast property to bool");

            variable = (T)(object)property.GetBoolean();
        }
        else
        {
            throw new Exception($"Unsupported type {variableType.Name}");
        }
    }
}
