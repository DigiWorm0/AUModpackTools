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

        public static void Postfix(MainMenuManager __instance)
        {
            if (!AUModpackTools.CustomConfig.EnablePopup.Value || _hasShown)
                return;

            ObjectBuilder.BuildPopup(
                AUModpackTools.CustomConfig.PopupText.Value
            );
            _hasShown = true;
        }
    }
}
