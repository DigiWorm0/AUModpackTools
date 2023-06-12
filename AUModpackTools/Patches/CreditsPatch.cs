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
using Assets.InnerNet;
using AmongUs.Data;

namespace AUModpackTools.Patches
{
    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public static class CreditsPatch
    {
        private static readonly Color _creditsColor = new(0.5f, 0.5f, 0.5f);
        private static readonly Vector3 _buttonPos = new(4.25f, 0, -1.0f);

        private static Sprite? _creditsSprite = null;
        private static string? _creditsText = null;
        private static CreditsScreenPopUp? _creditsPopup = null;

        public static void Postfix()
        {
            if (!AUModpackTools.CustomConfig.EnableCredits.Value)
                return;

            // Load Banner
            if (_creditsSprite == null)
                _creditsSprite = SpriteLoader.LoadSpriteFromResources("credits.png");

            ObjectBuilder.BuildButton(
                _buttonPos,
                _creditsSprite,
                _creditsColor,
                LaunchCredits
            );
        }

        private static void LaunchCredits()
        {
            // Get Text
            if (_creditsText == null)
                _creditsText = FileReader.ReadFileString(AUModpackTools.CustomConfig.CreditsFileName.Value);

            // Create Popup
            if (_creditsPopup == null)
                _creditsPopup = ObjectBuilder.BuildCredits(_creditsText);

            // Show Popup
            _creditsPopup.gameObject.SetActive(true);
        }
    }
}
