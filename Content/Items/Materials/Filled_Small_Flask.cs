using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace AllomancyMOD.Content.Items.Materials
{
    internal class Filled_Small_Flask : ModItem
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

        public override void AddRecipes()
        {
            var resultItem = ModContent.GetInstance<Items.Materials.Filled_Small_Flask>();
            resultItem.CreateRecipe()
                .AddIngredient(ModContent.GetInstance<Items.Materials.Empty_Small_Flask>(), 1)
                .AddCondition(Recipe.Condition.NearWater)
                .Register();
        }
    }
}
