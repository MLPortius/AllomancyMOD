using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace AllomancyMOD.Content.Items.Consumables
{
    internal class Small_Pewter_Flask : ModItem
    {
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
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 16;

            Item.healMana = 100;

        }

    }
}
