using BepInEx;
using EquipmentAndQuickSlotsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Terrarheimr.Features.Slots
{
    [BepInDependency("randyknapp.mods.equipmentandquickslots", BepInDependency.DependencyFlags.SoftDependency)]
    internal class AccessoriesSlots
    {
        public static readonly int SlotNumber = 5;

        public static void Init()
        {
            if (!EAQS.IsLoaded()) return;

            for (int i = 0; i < SlotNumber; i++)
            {
                bool added = EAQS.AddSlot
                    (
                        slotId: $"AccessoriesSlot_{i}",
                        ownerPluginGuid: Terrarheimr.PluginGUID,
                        nameToken: $"$accessories_slot_{i}",
                        //isValid: item => item.m_shared.m_name == "$item_mybackpacks_pack",
                        isValid: item => true,
                        isActive: () => true
                    );

                if (!added)
                    Jotunn.Logger.LogWarning($"EAQS had no free custom slot for the accessories {i}; it will live in the grid instead.");
            }
        }
    }
}
