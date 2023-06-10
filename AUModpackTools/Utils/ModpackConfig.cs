using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUModpackTools.Utils
{
    public class ModpackConfig
    {
        // Banner
        public ConfigEntry<bool> EnableBanner { get; private set; }
        public ConfigEntry<string> BannerFileName { get; private set; }
        public ConfigEntry<float> BannerScale { get; private set; }
        public ConfigEntry<float> BannerX { get; private set; }
        public ConfigEntry<float> BannerY { get; private set; }

        // Credits
        public ConfigEntry<bool> EnableCredits { get; private set; }
        public ConfigEntry<string> CreditsFileName { get; private set; }

        // Discord
        public ConfigEntry<bool> EnableDiscord { get; private set; }
        public ConfigEntry<string> DiscordLink { get; private set; }

        // Twitch
        public ConfigEntry<bool> EnableTwitch { get; private set; }
        public ConfigEntry<string> TwitchLink { get; private set; }

        // Popup
        public ConfigEntry<bool> EnablePopup { get; private set; }
        public ConfigEntry<string> PopupText { get; private set; }

        public void Load(ConfigFile configFile)
        {
            EnableBanner = configFile.Bind("Banner", "Enable", false, "Enable a custom banner on the main menu");
            BannerFileName = configFile.Bind("Banner", "FileName", "banner.png", "The file name of the banner image located in the BepInEx/plugins folder");
            BannerScale = configFile.Bind("Banner", "Scale", 1f, "The scale of the banner image");
            BannerX = configFile.Bind("Banner", "X", 0f, "The X offset of the banner image");
            BannerY = configFile.Bind("Banner", "Y", 0f, "The Y offset of the banner image");

            EnableCredits = configFile.Bind("Credits", "Enable", false, "Enable a custom credits screen");
            CreditsFileName = configFile.Bind("Credits", "FileName", "credits.txt", "The file name of the credits text located in the BepInEx/plugins folder");

            EnableDiscord = configFile.Bind("Discord", "Enable", false, "Enable a custom discord link");
            DiscordLink = configFile.Bind("Discord", "Link", "https://discord.gg/invite", "The discord link to open when clicking the discord button");

            EnableTwitch = configFile.Bind("Twitch", "Enable", false, "Enable a custom twitch link");
            TwitchLink = configFile.Bind("Twitch", "Link", "https://www.twitch.tv/channel_name", "The twitch link to open when clicking the twitch button");

            EnablePopup = configFile.Bind("Popup", "Enable", false, "Enable a custom popup message");
            PopupText = configFile.Bind("Popup", "Text", "This is a custom popup message", "The text to display in the popup");

            configFile.Save();
        }
    }
}
