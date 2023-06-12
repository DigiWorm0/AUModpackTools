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
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public static class TwitchPatch
    {
        private static readonly Color _twitchColor = new(0.39f, 0.25f, 0.65f);

        private static Sprite? _twitchSprite = null;

        public static void Postfix()
        {
            if (!AUModpackTools.CustomConfig.EnableTwitch.Value)
                return;

            // Load Banner
            if (_twitchSprite == null)
                _twitchSprite = SpriteLoader.LoadSpriteFromResources("twitch.png");

            ObjectBuilder.BuildButton(
                new Vector3(AUModpackTools.CustomConfig.TwitchX.Value, AUModpackTools.CustomConfig.TwitchY.Value, -1.0f),
                _twitchSprite,
                _twitchColor,
                LaunchTwitch
            );
        }

        private static void LaunchTwitch()
        {
            Application.OpenURL(AUModpackTools.CustomConfig.TwitchLink.Value);
        }
    }
}
