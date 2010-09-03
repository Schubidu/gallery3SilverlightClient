using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System.Windows;

namespace G3RestClient
{
    public static class Settings
    {
        public static TT Read<TT>(string name)
        {
            return Read<TT>(name, default(TT));
        }

        public static TT Read<TT>(string name, TT defaultValue)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            TT value;
            if (settings == null || !settings.TryGetValue<TT>(name, out value))
                return defaultValue;
            return value;
        }

        public static void Write<TT>(string name, TT value)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings == null)
                return;
            if (settings.Contains(name))
                settings[name] = value;
            else
                settings.Add(name, value);
            settings.Save();
        }

    }
}
