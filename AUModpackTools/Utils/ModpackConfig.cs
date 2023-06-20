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
        private readonly ConfigFile _config;

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
        public ConfigEntry<float> DiscordX { get; private set; }
        public ConfigEntry<float> DiscordY { get; private set; }

        // Twitch
        public ConfigEntry<bool> EnableTwitch { get; private set; }
        public ConfigEntry<string> TwitchLink { get; private set; }
        public ConfigEntry<float> TwitchX { get; private set; }
        public ConfigEntry<float> TwitchY { get; private set; }


        // Credits
        public ConfigEntry<bool> EnableCredits { get; private set; }
        public ConfigEntry<bool> CreditsAutoScroll { get; private set; }
        public ConfigEntry<string> CreditsButtonFileName { get; private set; } 
        public ConfigEntry<string> CreditsTextFileName { get; private set; }
        public ConfigEntry<float> CreditsX { get; private set; }
        public ConfigEntry<float> CreditsY { get; private set; }

        // Popup
        public ConfigEntry<bool> EnablePopup { get; private set; }
        public ConfigEntry<string> PopupText { get; private set; }

        // Other
        public ConfigEntry<bool> DisableAmongUsBanner { get; private set; }


        public ModpackConfig(ConfigFile configFile)
        {
            _config = configFile;

            EnableBanner = configFile.Bind("Banner", "Enable", false, "Enable a custom banner on the main menu");
            BannerFileName = configFile.Bind("Banner", "FileName", "banner.png", "The file name of the banner image located in the BepInEx/plugins folder");
            BannerScale = configFile.Bind("Banner", "Scale", 0.5f, "The scale of the banner image");
            BannerX = configFile.Bind("Banner", "X", 0f, "The X offset of the banner image");
            BannerY = configFile.Bind("Banner", "Y", 0f, "The Y offset of the banner image");

            OtherBannerX = configFile.Bind("Modded Banner", "X", 0f, "The X offset of another mod's banner image");
            OtherBannerY = configFile.Bind("Modded Banner", "Y", 0f, "The Y offset of another mod's banner image");
            OtherBannerScale = configFile.Bind("Modded Banner", "Scale", 1.0f, "The scale of another mod's banner image");

            EnableBannerText = configFile.Bind("Banner Text", "Enable", false, "Enable a custom banner text");
            BannerTextFileName = configFile.Bind("Banner Text", "FileName", "banner.txt", "The file name of the banner text located in the BepInEx/plugins folder");
            BannerTextX = configFile.Bind("Banner Text", "X", 0f, "The X offset of the banner text");
            BannerTextY = configFile.Bind("Banner Text", "Y", 0f, "The Y offset of the banner text");

            EnableDiscord = configFile.Bind("Discord", "Enable", false, "Enable a custom discord link");
            DiscordLink = configFile.Bind("Discord", "Link", "https://discord.gg/invite", "The discord link to open when clicking the discord button");
            DiscordX = configFile.Bind("Discord", "X", 4.25f, "The X offset of the discord button");
            DiscordY = configFile.Bind("Discord", "Y", 0f, "The Y offset of the discord button");

            EnableTwitch = configFile.Bind("Twitch", "Enable", false, "Enable a custom twitch link");
            TwitchLink = configFile.Bind("Twitch", "Link", "https://www.twitch.tv/channel_name", "The twitch link to open when clicking the twitch button");
            TwitchX = configFile.Bind("Twitch", "X", 4.25f, "The X offset of the twitch button");
            TwitchY = configFile.Bind("Twitch", "Y", 0.5f, "The Y offset of the twitch button");

            EnableCredits = configFile.Bind("Credits", "Enable", false, "Enable a custom credits button");
            CreditsAutoScroll = configFile.Bind("Credits", "AutoScroll", true, "Enable auto scrolling of the credits");
            CreditsButtonFileName = configFile.Bind("Credits", "ButtonFileName", "credits.png", "The file name of the credits button image located in the BepInEx/plugins folder");
            CreditsTextFileName = configFile.Bind("Credits", "TextFileName", "credits.txt", "The file name of the credits text located in the BepInEx/plugins folder");
            CreditsX = configFile.Bind("Credits", "X", 4.25f, "The X offset of the credits button");
            CreditsY = configFile.Bind("Credits", "Y", -0.5f, "The Y offset of the credits button");

            EnablePopup = configFile.Bind("Popup", "Enable", false, "Enable a custom popup message");
            PopupText = configFile.Bind("Popup", "Text", "This is a custom popup message", "The text to display in the popup");

            DisableAmongUsBanner = configFile.Bind("Other", "DisableAmongUsBanner", false, "Disable the default Among Us banner");

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
