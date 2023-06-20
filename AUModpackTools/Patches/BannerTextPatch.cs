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
using TMPro;

namespace AUModpackTools.Patches
{
    [HarmonyPriority(Priority.Last)]
    [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
    public static class BannerTextPatch
    {
        private static string? _creditsText = null;

        public static void Postfix(VersionShower __instance)
        {
            if (!AUModpackTools.CustomConfig.EnableBannerText.Value)
                return;

            // Load Banner
            if (_creditsText == null)
                _creditsText = FileReader.ReadFileString(AUModpackTools.CustomConfig.BannerTextFileName.Value);
            var textOffset = new Vector3(
                AUModpackTools.CustomConfig.BannerTextX.Value,
                AUModpackTools.CustomConfig.BannerTextY.Value,
                0
            );

            // Add New Text
            var textPrefab = __instance.text.gameObject;
            var textObj = UnityEngine.Object.Instantiate(textPrefab, textPrefab.transform.parent);
            textObj.transform.position = textOffset + new Vector3(1.0f, -0.5f, -1.5f);

            // Set Text
            var textComponent = textObj.GetComponent<TMP_Text>();
            textComponent.text = _creditsText;
            textComponent.alignment = TextAlignmentOptions.Center;
        }
    }
}
