using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using AllomancyMOD.Content.Tiles;

namespace AllomancyMOD.Content.Items.Stations
{
    public class MetalGrinder : ModItem
    {

        public static bool isMetal = true;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Metal Grinder");
            Tooltip.SetDefault("You can use it to do dusty things...");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<MetalGrinder_Tile>());

            Item.value = Item.buyPrice(copper: 1); // TEMPORAL
            Item.rare = ItemRarityID.Purple;       // TEMPORAL

            Item.maxStack = 99;
            Item.width = 34;
            Item.height = 34;

        }
    }
}
