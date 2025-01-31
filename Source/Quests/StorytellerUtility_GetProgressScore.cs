using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;

namespace Quests;

[HarmonyPatch(typeof(StorytellerUtility), nameof(StorytellerUtility.GetProgressScore))]
public static class StorytellerUtility_GetProgressScore
{
    public static void Postfix(ref float __result)
    {
        var factor = 0.75f;
        if (QuestsMod.instance.Settings.UseHigh)
        {
            factor = 0.5f;
        }

        var newResult = (1f - (factor / (1f + Mathf.Exp(-0.1f * __result)))) * __result;
        if (QuestsMod.instance.Settings.VerboseLogging)
        {
            Log.Message($"[QuestProgressionNerf]: Lowering progress score from {__result} to {newResult}");
        }

        __result = newResult;
    }
}