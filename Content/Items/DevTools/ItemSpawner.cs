using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using AllomancyMOD.Content.Items.Weapons;
using System;

namespace AllomancyMOD.Content.Items.DevTools
{
    internal class ItemSpawner : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Developing Tool");
            Tooltip.SetDefault("isMetal bool...");
        }

        public override void AddRecipes()
        {
            var recipe = ModContent.GetInstance<Items.DevTools.ItemSpawner>();
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

            Item.color = new Color(250, 0, 0, 0.5f);
            Item.alpha = 128;
        }


        public override void UseAnimation(Player player)
        {

            // VANILLA ITEM
            // player.QuickSpawnItem(player.GetSource_FromThis(), ItemID.Gel, 1);

            // MOD ITEM

            KolossSword ks = ModContent.GetInstance<Items.Weapons.KolossSword>();
            // player.QuickSpawnItem(player.GetSource_FromThis(), ks.Type, 1);

            bool im = ks.IsMetal();

            if (im == true)
            {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemID.Gel, 1);
            }

            else
            {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemID.Wood, 1);
            }
        }

    }
}
