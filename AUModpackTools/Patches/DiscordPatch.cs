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
    public static class DiscordPatch
    {
        private static readonly Color _discordColor = new Color(0.45f, 0.54f, 0.85f);
        private static readonly Vector3 _buttonPos = new Vector3(4.25f, 0.6f, -1.0f);

        private static Sprite? _discordSprite = null;

        public static void Postfix(MainMenuManager __instance)
        {
            if (!AUModpackTools.CustomConfig.EnableDiscord.Value)
                return;

            // Load Banner
            if (_discordSprite == null)
                _discordSprite = SpriteLoader.LoadSpriteFromResources("discord.png");

            ButtonBuilder.BuildMainMenuButton(
                _buttonPos,
                _discordSprite,
                _discordColor,
                LaunchDiscord
            );
        }

        private static void LaunchDiscord()
        {
            Application.OpenURL(AUModpackTools.CustomConfig.DiscordLink.Value);
        }
    }
}
