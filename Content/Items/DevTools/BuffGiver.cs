using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using AllomancyMOD.Content.Items.Weapons;
using AllomancyMOD.Common.Players;

namespace AllomancyMOD.Content.Items.DevTools
{
    public class BuffGiver : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Buff Giver Develping Tool");
            Tooltip.SetDefault("Gives pewter burning buff...");
        }

        public override void AddRecipes()
        {
            var recipe = ModContent.GetInstance<Items.DevTools.BuffGiver>();
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

            Item.color = new Color(0, 0, 255, 0.5f);
            Item.alpha = 128;
        }


        public override bool AltFunctionUse(Player player)
        {
            return true;
        }


        public override bool CanUseItem(Player player)
        {
            var aPewterPlayer = player.GetModPlayer<AllomanticPewterPlayer>();
            var allomantPlayer = player.GetModPlayer<AllomantPlayer>();

            if (player.altFunctionUse == 2) //Sets what happens on right click(special ability)
            {

                bool clearburn = aPewterPlayer.ClearBurn();
                return clearburn;
            }


            else //Sets what happens on left click(normal use)
            {
                bool startburn = aPewterPlayer.BurnPewter();
                return startburn;
            }
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            var allomantPlayer = player.GetModPlayer<AllomantPlayer>();
            if (allomantPlayer.Pewter == false)
            {
                allomantPlayer.Pewter = true;
            }

            else
            {
                allomantPlayer.Pewter = false;
            }
        }
    }
}
