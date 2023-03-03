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

            // METALLURGY TABLE RECIPES

            var re11 = ModContent.GetInstance<Items.Materials.Allomantic_Pewter_Bar>();
            re11.CreateRecipe()
                .AddIngredient(ItemID.CopperBar, 4)
                .AddIngredient(ItemID.TinBar, 12)
                .AddIngredient(ModContent.GetInstance<Items.Materials.Tiny_Investiture_Spark>(), 16)
                .AddTile(ModContent.GetInstance<Tiles.MetalGrinder_Tile>())
                .Register();



            // METAL EXCHANGER RECIPES

            Recipe re12 = Recipe.Create(ItemID.CopperBar, 1);
            re12.AddIngredient(ItemID.TinBar, 2);
            re12.AddIngredient(ModContent.GetInstance<Items.Materials.Tiny_Investiture_Spark>(), 4);
            re12.AddTile(ModContent.GetInstance<Tiles.MetalExchanger_Tile>());
            re12.Register();

            Recipe re13 = Recipe.Create(ItemID.TinBar, 1);
            re13.AddIngredient(ItemID.CopperBar, 2);
            re13.AddIngredient(ModContent.GetInstance<Items.Materials.Tiny_Investiture_Spark>(), 4);
            re13.AddTile(ModContent.GetInstance<Tiles.MetalExchanger_Tile>());
            re13.Register();


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
