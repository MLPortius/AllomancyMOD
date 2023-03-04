using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace AllomancyMOD.Content.Items.Materials
{
    public class Filled_Small_Flask : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Filled Small Flask");
            Tooltip.SetDefault("A usefull water flask for an allomancer...");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 30;
            Item.value = Item.buyPrice(copper: 1);  // TEMPORAL
            Item.rare = ItemRarityID.Purple;        // TEMPORAL
            Item.maxStack = 16;
            Item.material = true;
        }
    }
}
