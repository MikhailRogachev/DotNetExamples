using System.Text.Json;

namespace CustomTypeDesirialization.Services
{
    public class SettingsService
    {        
        private Dictionary<string, string> Settings
        {
            get
            {
                var settings = new Dictionary<string, string>()
                {
                    {"DbSettings", "[ \"MongoDb\", \"MSSQL\"]" },
                    {"EmailSettings", "Hotmail.com" },
                    {"ProviderSettings", "Mongo Provider" }
                };

                return settings;
            }
        }

        public T GetSetting<T>(string name)
        {
            if(!string.IsNullOrWhiteSpace(name) && Settings.ContainsKey(name))
                return JsonSerializer.Deserialize<T>(Settings[name]);

            return default(T);
        }

    }
}
