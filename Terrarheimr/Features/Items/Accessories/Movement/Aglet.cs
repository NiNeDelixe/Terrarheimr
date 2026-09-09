using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mono.Security.X509.X520;

namespace Terrarheimr.Features.Items.Accessories.Movement
{
    internal class Aglet : Accessory
    {
        public static String ValheimName = "$aglet";

        public static void Register()
        {
            var config = new ItemConfig
            {
                Name = ValheimName,
                Description = "Increases movement speed by 5%.",
                CraftingStation = "forge",
                MinStationLevel = 1
            };

            config.AddRequirement(new RequirementConfig
            {
                Item = "Iron",
                Amount = 10
            });

            var prefab = PrefabManager.Instance.CreateClonedPrefab(
                ValheimName,
                "TrinketIronHealth"
            );

            var item = new CustomItem(prefab, true, config);

            ItemManager.Instance.AddItem(item);
        }


        private void Update()
        {

        }
    }
}
