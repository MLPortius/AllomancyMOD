using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllomancyMOD.Content
{
    public class GlobalRecipes : ModSystem
    {
        public override void AddRecipes()
        {

            // MAIN RECIPES
            var re1 = ModContent.GetInstance<Items.Materials.Filled_Small_Flask>();
            re1.CreateRecipe()
                .AddIngredient(ModContent.GetInstance<Items.Materials.Empty_Small_Flask>(), 1)
                .AddCondition(Recipe.Condition.NearWater)
                .Register();

            var re2 = ModContent.GetInstance<Items.Consumables.Small_Pewter_Flask>();
            re2.CreateRecipe()
                .AddIngredient(ModContent.GetInstance<Items.Materials.Filled_Small_Flask>(), 1)
                .AddIngredient(ModContent.GetInstance<Items.Materials.Allomantic_Pewter_Dust>(), 10)
                .Register();

            var re9 = ModContent.GetInstance<Items.Materials.Allomantic_Pewter_Dust>();
            re9.CreateRecipe(100)
                .AddIngredient(ModContent.GetInstance<Items.Materials.Allomantic_Pewter_Bar>(), 1)
                .AddTile(ModContent.GetInstance<Tiles.MetalGrinder_Tile>())
                .Register();

            var re10 = ModContent.GetInstance<Items.Materials.Allomantic_Pewter_Bar>();
            re10.CreateRecipe()
                .AddIngredient(ModContent.GetInstance<Items.Materials.Allomantic_Pewter_Dust>(), 100)
                .AddTile(TileID.Furnaces) // TEMPORAL
                .Register();


            // TEMPORAL RECIPES
            var rt1 = ModContent.GetInstance<Items.Weapons.KolossSword>();
            rt1.CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddRecipeGroup(RecipeGroupID.IronBar, 50)
                .AddTile(TileID.Anvils)
                .Register();

            var rt2 = ModContent.GetInstance<Items.Materials.Empty_Small_Flask>();
            rt2.CreateRecipe()
                .AddIngredient(ItemID.Glass, 10)
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
