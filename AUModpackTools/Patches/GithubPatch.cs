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
    public static class GithubPatch
    {
        private static readonly Color _githubcolor = new Color(64f, 120f, 192f);
        private static readonly Vector3 _buttonPos = new Vector3(4.25f, 0.6f, -1.0f);

        private static Sprite? _githubSprite = null;

        public static void Postfix(MainMenuManager __instance)
        {
            if (!AUModpackTools.CustomConfig.EnableGithub.Value)
                return;

            // Load Banner
            if (_githubSprite == null)
                _githubSprite = SpriteLoader.LoadSpriteFromResources("Github.png");

            ObjectBuilder.BuildButton(
                _buttonPos,
                _githubSprite,
                _githubcolor,
                LaunchGithub
            );
        }

        private static void LaunchGithub()
        {
            Application.OpenURL(AUModpackTools.CustomConfig.GithubLink.Value);
        }
    }
}
