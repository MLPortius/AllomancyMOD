using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using AllomancyMOD.Common.Players;
using AllomancyMOD.Content;

namespace AllomancyMOD.Content.Items.Consumables
{
    internal class Small_Pewter_Flask : ModItem
    {

        private int PewterHealing;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Small Pewter Flask");
            Tooltip.SetDefault("Contains 25 of pewter dust...");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 30;
            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Purple;
            Item.consumable = true;

            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 60;
            Item.useTime = 60;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 16;

            PewterHealing = 10;
        }

        public override bool CanUseItem(Player player)
        {
            var aPewterPlayer = player.GetModPlayer<AllomanticPewterPlayer>();

            if (aPewterPlayer.PewterCurrent < aPewterPlayer.NewPewterMax)
            {
                return true;
            }
            
            else
            {
                CombatText.NewText(location: player.Hitbox, text: "Already max pewter", color: Color.Gray);
                return false;
            }
        }

        
        public override bool? UseItem(Player player)
        {

            var aPewterPlayer = player.GetModPlayer<AllomanticPewterPlayer>();

            int dif = aPewterPlayer.NewPewterMax - aPewterPlayer.PewterCurrent;

            if (dif < PewterHealing)
            {
                CombatText.NewText(location: player.Hitbox, text: $"{dif} pewter", color: GlobalColors.Pewter);
                aPewterPlayer.PewterCurrent += dif;
                return true;
            }

            else
            {
                CombatText.NewText(location: player.Hitbox, text: $"{PewterHealing} pewter", color: GlobalColors.Pewter);
                aPewterPlayer.PewterCurrent += PewterHealing;
                return true;
            } 
        }
    }
}
