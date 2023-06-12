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

        private static Sprite? _creditsSprite = null;
        private static string? _creditsText = null;
        private static CreditsScreenPopUp? _creditsPopup = null;

        public static void Postfix()
        {
            if (!AUModpackTools.CustomConfig.EnableCredits.Value)
                return;

            // Load Button
            if (_creditsSprite == null)
                _creditsSprite = SpriteLoader.LoadSpriteFromFile(AUModpackTools.CustomConfig.CreditsButtonFileName.Value);

            ObjectBuilder.BuildButton(
                new Vector3(AUModpackTools.CustomConfig.CreditsX.Value, AUModpackTools.CustomConfig.CreditsY.Value, -1.0f),
                _creditsSprite,
                _creditsColor,
                LaunchCredits
            );
        }

        private static void LaunchCredits()
        {
            // Get Text
            if (_creditsText == null)
                _creditsText = FileReader.ReadFileString(AUModpackTools.CustomConfig.CreditsTextFileName.Value);

            // Create Popup
            if (_creditsPopup == null)
                _creditsPopup = ObjectBuilder.BuildCredits(_creditsText);

            // Show Popup
            _creditsPopup.gameObject.SetActive(true);
        }
    }
}
