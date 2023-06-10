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
        private static readonly Color _twitchColor = new Color(0.39f, 0.25f, 0.65f);
        private static readonly Vector3 _buttonPos = new Vector3(4.25f, 1.2f, -1.0f);

        private static Sprite? _twitchSprite = null;

        public static void Postfix(MainMenuManager __instance)
        {
            if (!AUModpackTools.CustomConfig.EnableTwitch.Value)
                return;

            // Load Banner
            if (_twitchSprite == null)
                _twitchSprite = SpriteLoader.LoadSpriteFromResources("twitch.png");

            ButtonBuilder.BuildMainMenuButton(
                _buttonPos,
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
