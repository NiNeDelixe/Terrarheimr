using BepInEx;
using EquipmentAndQuickSlotsAPI;
using HarmonyLib;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using Terrarheimr.Features.Effects;
using Terrarheimr.Features.Items;
using Terrarheimr.Features.Slots;

namespace Terrarheimr
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [BepInDependency("randyknapp.mods.equipmentandquickslots", BepInDependency.DependencyFlags.SoftDependency)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class Terrarheimr : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jotunn.jotunnmodstub";
        public const string PluginName = "Terrarheimr";
        public const string PluginVersion = "0.0.1";

        private Harmony _harmony;

        // Use this class to add your own localization to the game
        // https://valheim-modding.github.io/Jotunn/tutorials/localization.html
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

        private void Awake()
        {
            // Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
            Jotunn.Logger.LogInfo("ModStub has landed");

            PrefabManager.OnVanillaPrefabsAvailable += AddClonedItems;

            _harmony = new Harmony(PluginName);
            _harmony.PatchAll();

            // To learn more about Jotunn's features, go to
            // https://valheim-modding.github.io/Jotunn/tutorials/overview.html

            AllEffects.Init();

            if (!EAQS.IsLoaded()) return;

            AccessoriesSlots.Init();
        }
        private void AddClonedItems()
        {
            // Create and add a custom item based on SwordBlackmetal
            ItemConfig evilSwordConfig = new ItemConfig();
            evilSwordConfig.Name = "$item_evilsword";
            evilSwordConfig.Description = "$item_evilsword_desc";
            evilSwordConfig.CraftingStation = CraftingStations.None;
            evilSwordConfig.AddRequirement("Stone", 99, 1);
            evilSwordConfig.AddRequirement("Wood", 99, 2);

            CustomItem evilSword = new CustomItem("EvilSword", "SwordBlackmetal", evilSwordConfig);
            ItemManager.Instance.AddItem(evilSword);

            // Show a different KeyHint for the sword.
            //KeyHintsEvilSword();

            AllItems.Init();
            ItemManager.OnItemsRegistered += OnItemsRegistered;

            // You want that to run only once, Jotunn has the item cached for the game session
            PrefabManager.OnVanillaPrefabsAvailable -= AddClonedItems;
        }

        private void OnItemsRegistered()
        {
            Logger.LogInfo("Terrarheimr items registered");
        }
    }
}