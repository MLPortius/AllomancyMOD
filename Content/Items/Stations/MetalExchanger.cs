using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using AllomancyMOD.Content.Tiles;

namespace AllomancyMOD.Content.Items.Stations
{
    public class MetalExchanger : ModItem
    {

        public static bool isMetal = true;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Metal Exchanger");
            Tooltip.SetDefault("Basic allomant tools for metal exchange...\n" +
                               "\nBurn iron for pre-harmode advanced metal exchange." +
                               "\nBurn iron and steel for hardmode basic metal exchange." +
                               "\nBurn iron, steel and tin for hardmode advanced metal exchange." +
                               "\nBurn iron, steel, tin and pewter for atium exchange.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<MetalExchanger_Tile>());

            Item.value = Item.buyPrice(copper: 1); // TEMPORAL
            Item.rare = ItemRarityID.Purple;       // TEMPORAL

            Item.maxStack = 1;
            Item.width = 48;
            Item.height = 32;

        }
    }
}
