using Mlie;
using UnityEngine;
using Verse;

namespace Quests;

[StaticConstructorOnStartup]
internal class QuestsMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static QuestsMod Instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public QuestsMod(ModContentPack content) : base(content)
    {
        Instance = this;
        Settings = GetSettings<QuestsSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal QuestsSettings Settings { get; }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Quest Progression Nerf";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.Label("QPN.Title".Translate());
        listingStandard.Gap();

        if (listingStandard.RadioButton("QPN.Default".Translate(), !Settings.UseHigh,
                tooltip: "QPN.Default.Tooltip".Translate()))
        {
            Settings.UseHigh = false;
        }

        if (listingStandard.RadioButton("QPN.High".Translate(), Settings.UseHigh,
                tooltip: "QPN.High.Tooltip".Translate()))
        {
            Settings.UseHigh = true;
        }

        listingStandard.Gap();
        listingStandard.Label(Settings.UseHigh ? "QPN.High.Formula".Translate() : "QPN.Default.Formula".Translate());

        listingStandard.Gap();
        listingStandard.CheckboxLabeled("QPN.VerboseLogging".Translate(), ref Settings.VerboseLogging);

        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("QPN.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }
}