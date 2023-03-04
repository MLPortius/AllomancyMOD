using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using AllomancyMOD.Content.Tiles;

namespace AllomancyMOD.Content.Items.Stations
{
    public class MetallurgyTable : ModItem
    {

        public static bool isMetal = true;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Metallurgy Table");
            Tooltip.SetDefault("Unleash the power of invested metals...");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<MetallurgyTable_Tile>());

            Item.value = Item.buyPrice(copper: 1); // TEMPORAL
            Item.rare = ItemRarityID.Purple;       // TEMPORAL

            Item.maxStack = 1;
            Item.width = 64;
            Item.height = 48;

        }
    }
}
