using Verse;

namespace Quests;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class QuestsSettings : ModSettings
{
    public bool UseHigh;
    public bool VerboseLogging;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref UseHigh, "UseHigh");
        Scribe_Values.Look(ref VerboseLogging, "VerboseLogging");
    }
}