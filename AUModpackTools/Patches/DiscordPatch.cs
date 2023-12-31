﻿using AUModpackTools.Utils;
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
        private static readonly Color _discordColor = new(0.45f, 0.54f, 0.85f);

        private static Sprite? _discordSprite = null;

        public static void Postfix()
        {
            if (!AUModpackTools.CustomConfig.EnableDiscord.Value)
                return;

            // Load Banner
            if (_discordSprite == null)
                _discordSprite = SpriteLoader.LoadSpriteFromResources("discord.png");

            ObjectBuilder.BuildButton(
                new Vector3(AUModpackTools.CustomConfig.DiscordX.Value, AUModpackTools.CustomConfig.DiscordY.Value, -1.0f),
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
