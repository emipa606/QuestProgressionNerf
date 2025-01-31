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
    public static QuestsMod instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public QuestsMod(ModContentPack content) : base(content)
    {
        instance = this;
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
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Label("QPN.Title".Translate());
        listing_Standard.Gap();

        if (listing_Standard.RadioButton("QPN.Default".Translate(), !Settings.UseHigh,
                tooltip: "QPN.Default.Tooltip".Translate()))
        {
            Settings.UseHigh = false;
        }

        if (listing_Standard.RadioButton("QPN.High".Translate(), Settings.UseHigh,
                tooltip: "QPN.High.Tooltip".Translate()))
        {
            Settings.UseHigh = true;
        }

        listing_Standard.Gap();
        listing_Standard.Label(Settings.UseHigh ? "QPN.High.Formula".Translate() : "QPN.Default.Formula".Translate());

        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("QPN.VerboseLogging".Translate(), ref Settings.VerboseLogging);

        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("QPN.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }
}