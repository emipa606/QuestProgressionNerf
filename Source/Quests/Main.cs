using System.Reflection;
using HarmonyLib;
using Verse;

namespace Quests;

[StaticConstructorOnStartup]
public static class Main
{
    public enum SystemToUseEnum
    {
        High = 1,
        Default = 0
    }

    static Main()
    {
        new Harmony("com.RimWorld.Quests").PatchAll(Assembly.GetExecutingAssembly());
    }
}