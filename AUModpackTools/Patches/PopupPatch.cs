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
        public static void Postfix(MainMenuManager __instance)
        {
            if (!AUModpackTools.CustomConfig.EnablePopup.Value)
                return;

            ObjectBuilder.BuildPopup(
                AUModpackTools.CustomConfig.PopupText.Value
            );
        }
    }
}
