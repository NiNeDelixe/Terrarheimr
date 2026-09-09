using EquipmentAndQuickSlotsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrarheimr.Features.Items.Accessories.Movement;

namespace Terrarheimr.Features.Effects
{
    public static class AgletEffect
    {
        public const float SpeedMultiplier = 1.05f;
        public static bool IsEquipped { get; set; }

        public static void Init()
        {
            if (!EAQS.IsLoaded()) return;

            EAQS.AddSlotItemChangedListener((slotId, oldItem, newItem) =>
            {
                IsEquipped = false;

                if (newItem.m_shared.m_name == Aglet.ValheimName)
                {
                    IsEquipped = true;
                }
            });
        }
    }
}
