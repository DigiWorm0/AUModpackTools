using AUModpackTools.Utils;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AUModpackTools.Patches
{
    [HarmonyPriority(Priority.Last)]
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public static class BannerPatch
    {
        private static readonly string AU_BANNER_NAME = "MainMenuManager/MainUI/AspectScaler/LeftPanel/Sizer/LOGO-AU";
        private static readonly string[] MODDED_BANNER_NAMES = new string[]
        {
            "bannerLogo_TownOfUs", // Town of Us
            "bannerLogo_TOR", // The Other Roles, StellarRoles
            "bannerLogo_LasMonjas", // Las Monjas
            "bannerLogo_ATR" // All The Roles
        };

        private static Sprite? _bannerSprite = null;

        public static void Postfix()
        {
            if (!AUModpackTools.CustomConfig.EnableBanner.Value)
                return;

            // Load Banner
            if (_bannerSprite == null)
                _bannerSprite = SpriteLoader.LoadSpriteFromFile(AUModpackTools.CustomConfig.BannerFileName.Value);

            // Shift AU Banner
            var auBanner = GameObject.Find(AU_BANNER_NAME);
            if (auBanner != null)
            {
                auBanner.transform.localScale *= 0.6f;
                auBanner.transform.position += Vector3.up * 0.25f;

                if (AUModpackTools.CustomConfig.DisableAmongUsBanner.Value)
                    auBanner.SetActive(false);
            }

            // Shift Modded Banners
            var otherBannerOffset = new Vector3(AUModpackTools.CustomConfig.OtherBannerX.Value, AUModpackTools.CustomConfig.OtherBannerY.Value);
            foreach (var moddedBannerName in MODDED_BANNER_NAMES)
            {
                var oldBanner = GameObject.Find(moddedBannerName);
                if (oldBanner != null)
                {
                    oldBanner.transform.localScale *= AUModpackTools.CustomConfig.OtherBannerScale.Value;
                    oldBanner.transform.position += otherBannerOffset;
                }
            }

            // Add New Banner
            var bannerOffset = new Vector3(AUModpackTools.CustomConfig.BannerX.Value, AUModpackTools.CustomConfig.BannerY.Value);
            var banner = new GameObject("bannerLogo_AUModpackTools");
            banner.transform.position = bannerOffset + new Vector3(1.0f, 0, -1.5f);
            banner.transform.localScale *= AUModpackTools.CustomConfig.BannerScale.Value;
            var spriteRenderer = banner.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = _bannerSprite;
        }
    }
}
