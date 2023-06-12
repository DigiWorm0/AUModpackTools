using AUModpackTools.Utils;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using Reactor;
using Reactor.Networking.Attributes;

namespace AUModpackTools
{
    [BepInAutoPlugin(ID, "AUModpackTools")]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInDependency("com.slushiegoose.townofus", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("me.eisbison.theotherroles", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("me.fluff.stellarroles", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("AllTheRoles", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInProcess("Among Us.exe")]
    [ReactorModFlags(Reactor.Networking.ModFlags.None)]
    public partial class AUModpackTools : BasePlugin
    {
        public const string ID = "com.DigiWorm.AUModpackTools";

        public HarmonyLib.Harmony Harmony { get; } = new(Id);

        public static ModpackConfig CustomConfig { get; private set; }

        public override void Load()
        {
            AULogger.Init();
            CustomConfig = new(Config);
            Harmony.PatchAll();
        }
    }
}
