using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using Reactor;
using Reactor.Networking.Attributes;
using Reactor.Utilities;

namespace AUModpackTools
{
    [BepInAutoPlugin(ID, "AUModpackTools")]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInDependency("com.slushiegoose.townofus", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("me.eisbison.theotherroles", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInProcess("Among Us.exe")]
    [ReactorModFlags(Reactor.Networking.ModFlags.None)]
    public partial class AUModpackTools : BasePlugin
    {
        public const string ID = "com.DigiWorm.AUModpackTools";

        public HarmonyLib.Harmony Harmony { get; } = new(Id);

        public static ModpackConfig CustomConfig { get; } = new();

        public override void Load()
        {
            CustomConfig.Load(Config);
            Harmony.PatchAll();
        }
    }
}
