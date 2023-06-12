using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace AUModpackTools.Utils
{
    /// <summary>
    /// Represents the config file in BepInEx/config
    /// </summary>
    public class ModpackConfig
    {
        private ConfigFile _config;

        // Among Us Banner
        public ConfigEntry<bool> EnableAmongUsBanner { get; private set; }

        // Banner
        public ConfigEntry<bool> EnableBanner { get; private set; }
        public ConfigEntry<string> BannerFileName { get; private set; }
        public ConfigEntry<float> BannerScale { get; private set; }
        public ConfigEntry<float> BannerX { get; private set; }
        public ConfigEntry<float> BannerY { get; private set; }

        // Other Banner
        public ConfigEntry<float> OtherBannerX { get; private set; }
        public ConfigEntry<float> OtherBannerY { get; private set; }
        public ConfigEntry<float> OtherBannerScale { get; private set; }

        // Banner Text
        public ConfigEntry<bool> EnableBannerText { get; private set; }
        public ConfigEntry<string> BannerTextFileName { get; private set; }
        public ConfigEntry<float> BannerTextX { get; private set; }
        public ConfigEntry<float> BannerTextY { get; private set; }

        // Discord
        public ConfigEntry<bool> EnableDiscord { get; private set; }
        public ConfigEntry<string> DiscordLink { get; private set; }

        // Twitch
        public ConfigEntry<bool> EnableTwitch { get; private set; }
        public ConfigEntry<string> TwitchLink { get; private set; }

        // Popup
        public ConfigEntry<bool> EnablePopup { get; private set; }
        public ConfigEntry<string> PopupText { get; private set; }

        public ModpackConfig(ConfigFile configFile)
        {
            _config = configFile;

            EnableAmongUsBanner = configFile.Bind("Among Us Banner", "Enable", true, "Enable/Disable the default Among Us banner on the main menu");

            EnableBanner = configFile.Bind("Banner", "Enable", false, "Enable a custom banner on the main menu");
            BannerFileName = configFile.Bind("Banner", "FileName", "banner.png", "The file name of the banner image located in the BepInEx/plugins folder");
            BannerScale = configFile.Bind("Banner", "Scale", 1f, "The scale of the banner image");
            BannerX = configFile.Bind("Banner", "X", 0f, "The X offset of the banner image");
            BannerY = configFile.Bind("Banner", "Y", 0f, "The Y offset of the banner image");

            OtherBannerX = configFile.Bind("Modded Banner", "X", 0f, "The X offset of another mod's banner image");
            OtherBannerY = configFile.Bind("Modded Banner", "Y", 0.8f, "The Y offset of another mod's banner image");
            OtherBannerScale = configFile.Bind("Modded Banner", "Scale", 0.4f, "The scale of another mod's banner image");

            EnableBannerText = configFile.Bind("Banner Text", "Enable", false, "Enable a custom banner text");
            BannerTextFileName = configFile.Bind("Banner Text", "FileName", "banner.txt", "The file name of the banner text located in the BepInEx/plugins folder");
            BannerTextX = configFile.Bind("Banner Text", "X", 0f, "The X offset of the banner text");
            BannerTextY = configFile.Bind("Banner Text", "Y", 0f, "The Y offset of the banner text");

            EnableDiscord = configFile.Bind("Discord", "Enable", false, "Enable a custom discord link");
            DiscordLink = configFile.Bind("Discord", "Link", "https://discord.gg/invite", "The discord link to open when clicking the discord button");

            EnableTwitch = configFile.Bind("Twitch", "Enable", false, "Enable a custom twitch link");
            TwitchLink = configFile.Bind("Twitch", "Link", "https://www.twitch.tv/channel_name", "The twitch link to open when clicking the twitch button");

            EnablePopup = configFile.Bind("Popup", "Enable", false, "Enable a custom popup message");
            PopupText = configFile.Bind("Popup", "Text", "This is a custom popup message", "The text to display in the popup");

            configFile.Save();
        }

        /// <summary>
        /// Reloads the config and reloads the scene
        /// </summary>
        public void Reload()
        {
            _config.Reload();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
