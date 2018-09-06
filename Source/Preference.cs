using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;

namespace O2MusicList
{
    public class Preference
    {
        private const string PreferenceFilename = "settings.json";

        /// <summary>
        /// Gets the singleton instance of the <see cref="Preference"/> class.
        /// </summary>
        public static Preference Instance { get; } = new Preference();

        /// <summary>
        /// Automatically synchronize ojn files.
        /// </summary>
        public bool AutoSyncrhonize { get; set; } = true;

        /// <summary>
        /// Automatically correct keymode ojn files.
        /// </summary>
        public bool AutoCorrectKeyMode { get; set; } = true;

        /// <summary>
        /// Automatically remove duplicate ojn files.
        /// </summary>
        public bool AutoRemoveDuplicate { get; set; } = false;

        /// <summary>
        /// Gets or sets whether decoder should auto detect character encoding based on <see cref="FileFormat"/>.
        /// </summary>
        public bool AutoDetectEncoding { get; set; } = true;

        /// <summary>
        /// Gets or sets default encoding to load / save data.
        /// </summary>
        public string EncodingName { get; set; } = "big5";

        /// <summary>
        /// Gets or sets whether the value of <see cref="FileFormat"/> should follow the version of loaded data.
        /// </summary>
        public bool PreserveFormat { get; set; } = true;

        /// <summary>
        /// Get or sets the default client version to load / save data.
        /// </summary>
        public FileFormat FileFormat { get; set; } = FileFormat.Old;

        /// <summary>
        /// Gets or sets the default sorting field of data.
        /// </summary>
        public SortingField OrderBy { get; set; } = SortingField.Title;

        /// <summary>
        /// Gets or sets a value indicating whether the compact build should be used upon saving data.
        /// </summary>
        public bool IsCompactBuild { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether all headers should follow this Key Mode regardless the <see cref="OJN.KeyMode"/> value.
        /// Use 0 to not enforce any Key Mode
        /// </summary>
        public int KeyMode { get; set; } = 0;

        /// <summary>
        /// Gets or sets the default release date of data.
        /// </summary>
        public DateTime PublishDate { get; set; } = new DateTime(2011, 08, 06);

        /// <summary>
        /// Gets or sets the value indicating whether the settings has been modified.
        /// </summary>
        [JsonIgnore]
        public bool Dirty { get; set; } = false;

        /// <summary>
        /// Initializes a static instance of the <see cref="Preference"/> class.
        /// </summary>
        static Preference()
        {
            if (!File.Exists(PreferenceFilename))
            {
                Instance.Save();
            }
            else
            {
                try
                {
                    Instance = JsonConvert.DeserializeObject<Preference>(File.ReadAllText(PreferenceFilename));
                }
                catch (Exception)
                {
                    // Probably some sort another setting for another application, just instantiate normally
                    Instance = new Preference();
                }
            }
        }

        /// <summary>
        /// Save user preference into disk.
        /// </summary>
        public void Save()
        {
            File.WriteAllText(PreferenceFilename, JsonConvert.SerializeObject(Instance, Formatting.Indented));
        }

        /// <summary>
        /// Reset preference to default settings
        /// </summary>
        public void Reset()
        {
            AutoSyncrhonize = true;
            AutoCorrectKeyMode = true;
            AutoRemoveDuplicate = false;
            AutoDetectEncoding = true;
            EncodingName = "big5";
            PreserveFormat = true;
            FileFormat = FileFormat.Old;
            OrderBy = SortingField.Title;
            IsCompactBuild = true;
            KeyMode = 0;
            DateTime PublishDate = new DateTime(2011, 08, 06);
            Dirty = false;
        }

        /// <summary>
        /// Get encoding name of specified localization.
        /// </summary>
        /// <param name="localization">Localization to get the encoding name.</param>
        /// <returns>Encoding name that match with specified localization.</returns>
        public static string GetEncodingName(string localization)
        {
            if (localization.Equals("latin", StringComparison.InvariantCultureIgnoreCase))
            {
                return "utf-8";
            }
            else if (localization.Equals("unicode", StringComparison.InvariantCultureIgnoreCase))
            {
                return "utf-16";
            }
            else if (localization.Equals("korean", StringComparison.InvariantCultureIgnoreCase))
            {
                return "ks_c_5601-1987";
            }
            else if (localization.Equals("chinese", StringComparison.InvariantCultureIgnoreCase))
            {
                return "big5";
            }
            else if (localization.Equals("japanese", StringComparison.InvariantCultureIgnoreCase))
            {
                return "shift_jis";
            }

            return localization;
        }

        /// <summary>
        /// Get localization name of specified encoding.
        /// </summary>
        /// <param name="encodingName">Localization to get the encoding name.</param>
        /// <returns>Localization name that match with specified encoding name.</returns>
        public static string GetLocalizationName(string encodingName)
        {
            if (encodingName.Equals("utf-8", StringComparison.InvariantCultureIgnoreCase))
            {
                return "Latin";
            }
            else if (encodingName.Equals("utf-16", StringComparison.InvariantCultureIgnoreCase))
            {
                return "Unicode";
            }
            else if (encodingName.Equals("ks_c_5601-1987", StringComparison.InvariantCultureIgnoreCase))
            {
                return "Korean";
            }
            else if (encodingName.Equals("big5", StringComparison.InvariantCultureIgnoreCase))
            {
                return "Chinese";
            }
            else if (encodingName.Equals("shift_jis", StringComparison.InvariantCultureIgnoreCase))
            {
                return "Japanese";
            }

            return encodingName;
        }
    }
}
