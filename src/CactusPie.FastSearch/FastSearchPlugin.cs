using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using CactusPie.FastSearch;

[assembly: AssemblyDescription("CactusPie.FastSearch")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("CactusPie.FastSearch")]
[assembly: AssemblyCopyright("Copyright © 2025 cactuspie. All rights reserved.")]
[assembly: AssemblyTrademark("SPT 3.11.1, EFT 0.16.1.3.35392")]

[assembly: AssemblyVersion(FastSearchPlugin.Version)]
[assembly: AssemblyFileVersion(FastSearchPlugin.Version)]

namespace CactusPie.FastSearch;

[BepInPlugin("com.cactuspie.fastsearch", "CactusPie.FastSearch", Version)]
public class FastSearchPlugin : BaseUnityPlugin
{
    public const string Version = "1.3.0";

    internal static ConfigEntry<bool> InstantlyRevealEverything { get; private set; }
    internal static ManualLogSource SearchTimePluginLogger { get; private set; }

    internal void Start()
    {
        SearchTimePluginLogger = Logger;

        Logger.LogInfo("CactusPie.FastSearch");

        InstantlyRevealEverything = Config.Bind
        (
            "Fast Search Settings",
            "Instantly reveal everything",
            false,
            new ConfigDescription
            (
                "Instantly reveals everything, as if you have 100% Elite Search Luck"
            )
        );

        new InstantLuckySearch().Enable();
    }
}
