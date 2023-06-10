using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUModpackTools
{
    public class ModpackConfig
    {
        // Banner
        public ConfigEntry<bool> EnableBanner { get; private set; }
        public ConfigEntry<string> BannerFileName { get; private set; }
        public ConfigEntry<float> BannerScale { get; private set; }
        public ConfigEntry<float> BannerX { get; private set; }
        public ConfigEntry<float> BannerY { get; private set; }

        public void Load(ConfigFile configFile)
        {
            EnableBanner = configFile.Bind("Banner", "Enable", false, "Enable a custom banner on the main menu");
            BannerFileName = configFile.Bind("Banner", "FileName", "banner.png", "The file name of the banner image located in the BepInEx/plugins folder");  
            BannerScale = configFile.Bind("Banner", "Scale", 1f, "The scale of the banner image");
            BannerX = configFile.Bind("Banner", "X", 0f, "The X offset of the banner image");
            BannerY = configFile.Bind("Banner", "Y", 0f, "The Y offset of the banner image");
        }
    }
}
