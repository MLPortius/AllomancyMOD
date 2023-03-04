using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using AllomancyMOD.Content.Items.Weapons;
using System;
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

                if (player.HasBuff(type: ModContent.BuffType<Content.Buffs.PewterAllomancyBuff_Burn>()))
                {
                    Item.UseSound = SoundID.LiquidsWaterLava;
                    aPewterPlayer.Player.ClearBuff(type: ModContent.BuffType<Content.Buffs.PewterAllomancyBuff_Burn>());

                    int timerSeconds = 60 /*seconds*/ * 60 /*minutes*/* 16 /*hours*/;
                    aPewterPlayer.Player.AddBuff(type: ModContent.BuffType<Content.Buffs.PewterAllomancyBuff_Off>(), timeToAdd: 60 /*frames*/ * timerSeconds);

                    return true;
                }

                else { return false; }
            }


            else //Sets what happens on left click(normal use)
            {

                if (allomantPlayer.Pewter == true)
                {
                    if (player.HasBuff(ModContent.BuffType<Content.Buffs.PewterAllomancyBuff_Off>()))
                    {
                        player.ClearBuff(ModContent.BuffType<Content.Buffs.PewterAllomancyBuff_Off>());
                        Item.UseSound = SoundID.Item20;

                        int timerSeconds = 60 /*seconds*/ * 60 /*minutes*/* 16 /*hours*/;
                        aPewterPlayer.Player.AddBuff(type: ModContent.BuffType<Content.Buffs.PewterAllomancyBuff_Burn>(), timeToAdd: 60 /*frames*/ * timerSeconds);

                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }
                return false;
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
