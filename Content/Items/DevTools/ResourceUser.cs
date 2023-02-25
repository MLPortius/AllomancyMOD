using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using AllomancyMOD.Common.Players;

namespace AllomancyMOD.Content.Items.DevTools
{
    internal class ResourceUser : ModItem
    {

        private int AllomanticPewterCost;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Developing Tool");
            Tooltip.SetDefault("Pewter resource usage...");
        }

        public override void AddRecipes()
        {
            var recipe = ModContent.GetInstance<Items.DevTools.ResourceUser>();
            recipe.CreateRecipe()
                .AddIngredient(ItemID.Wood, 1)
                .Register();
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.autoReuse = false;
            Item.UseSound = SoundID.Research;

            Item.color = new Color(255, 255, 0, 0.5f);
            Item.alpha = 128;


            AllomanticPewterCost = 5;
        }

        // Make sure you can't use the item if you don't have enough resource
        public override bool CanUseItem(Player player)
        {
            var aPewterPlayer = player.GetModPlayer<AllomanticPewterPlayer>();

            if (player.altFunctionUse == 2) //Sets what happens on right click(special ability)
            {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemID.Gel, aPewterPlayer.PewterCurrent);
                Item.UseSound = SoundID.Item3;
                return true;
            }

            else //Sets what happens on left click(normal use)
            {
                if (aPewterPlayer.PewterCurrent >= AllomanticPewterCost)
                {
                    Item.UseSound = SoundID.Research;
                    aPewterPlayer.PewterCurrent -= AllomanticPewterCost;
                    return true;
                }
            }

            return false;
        }

        public override bool CanRightClick() {return true;}
        public override bool AltFunctionUse(Player player) {return true;}

        public override void RightClick(Player player)
        {
            ResourceUser ru = ModContent.GetInstance<Items.DevTools.ResourceUser>();
            player.QuickSpawnItem(player.GetSource_FromThis(), ru.Type, 1);
        }
    }
}
