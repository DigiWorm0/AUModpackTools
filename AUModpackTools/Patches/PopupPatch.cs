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
    public static class PopupPatch
    {
        private static bool _hasShown = false;
        private static string? _popupText = null;
        private static GenericPopup? _popup = null;

        public static void Postfix()
        {
            if (!AUModpackTools.CustomConfig.EnablePopup.Value || _hasShown)
                return;

            // Get Text
            if (_popupText == null)
                _popupText = FileReader.ReadFileString(AUModpackTools.CustomConfig.PopupTextFileName.Value);

            // Create Popup
            if (_popup == null)
                _popup = ObjectBuilder.BuildPopup();
            _popup.Show(_popupText);

            // Only Show Once
            _hasShown = true;
        }
    }
}
