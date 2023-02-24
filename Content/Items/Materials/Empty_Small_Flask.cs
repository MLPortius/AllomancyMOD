using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace AllomancyMOD.Content.Items.Materials
{
    internal class Empty_Small_Flask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Empty Small Flask");
            Tooltip.SetDefault("A usefull empty flask for an allomancer...");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 30;
            Item.value = Item.buyPrice(copper: 1);  // TEMPORAL
            Item.rare = ItemRarityID.Purple;        // TEMPORAL
            Item.maxStack = 1616;
            Item.material = true;
        }

        public override void AddRecipes()
        {
            var resultItem = ModContent.GetInstance<Items.Materials.Empty_Small_Flask>();
            resultItem.CreateRecipe()
                .AddIngredient(ItemID.Glass, 10)
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
