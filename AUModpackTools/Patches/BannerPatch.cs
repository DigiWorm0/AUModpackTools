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
        private static string[] _oldBannerList = new string[]
        {
            "MainUI/bannerLogo_AmongUs",
            "bannerLogo_TownOfUs", // Town of Us
            "bannerLogo_TOR" // The Other Roles
        };

        private static Sprite? _bannerSprite = null;

        public static void Postfix(MainMenuManager __instance)
        {
            if (!AUModpackTools.CustomConfig.EnableBanner.Value)
                return;

            // Load Banner
            if (_bannerSprite == null)
            {
                string gameDir = Assembly.GetAssembly(typeof(AUModpackTools))?.Location ?? "/";
                string bannerPath = Path.Combine(Path.GetDirectoryName(gameDir) ?? "/", AUModpackTools.CustomConfig.BannerFileName.Value);
                if (!File.Exists(bannerPath))
                    throw new Exception($"Failed to find banner image at {bannerPath}");
                byte[] bannerData = File.ReadAllBytes(bannerPath);
                Texture2D bannerTexture = new(1, 1, TextureFormat.RGBA32, false)
                {
                    wrapMode = TextureWrapMode.Clamp,
                    filterMode = FilterMode.Bilinear,
                    hideFlags = HideFlags.HideAndDontSave,
                    requestedMipmapLevel = 0
                };
                ImageConversion.LoadImage(bannerTexture, bannerData);

                _bannerSprite = Sprite.Create(
                    bannerTexture,
                    new Rect(0, 0, bannerTexture.width, bannerTexture.height),
                    new Vector2(0.5f, 0.5f),
                    100f,
                    0,
                    SpriteMeshType.FullRect
                );
            }

            // Shift Old Banners
            foreach (var oldBannerName in _oldBannerList)
            {
                bool isAmongUs = oldBannerName.EndsWith("AmongUs");
                var oldBanner = GameObject.Find(oldBannerName);

                if (oldBanner != null)
                {
                    oldBanner.transform.localScale *= (isAmongUs ? 0.6f : 0.4f);
                    oldBanner.transform.position += Vector3.up * (isAmongUs ? 0.25f : 0.8f);
                }
                else
                {
                    Debug.Log("Could not find " + oldBannerName + " to shift");
                }
            }

            // AUModpackTools Banner
            var bannerOffset = new Vector3(AUModpackTools.CustomConfig.BannerX.Value, AUModpackTools.CustomConfig.BannerY.Value);
            var banner = new GameObject("bannerLogo_AUModpackTools");
            banner.transform.position = Vector3.up * 0.9f + bannerOffset;
            banner.transform.localScale *= AUModpackTools.CustomConfig.BannerScale.Value;
            var spriteRenderer = banner.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = _bannerSprite;
        }
    }
}
