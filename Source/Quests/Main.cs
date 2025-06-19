using System.Reflection;
using HarmonyLib;
using Verse;

namespace Quests;

[StaticConstructorOnStartup]
public static class Main
{
    static Main()
    {
        new Harmony("com.RimWorld.Quests").PatchAll(Assembly.GetExecutingAssembly());
    }
}