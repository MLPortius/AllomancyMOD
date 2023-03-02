using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllomancyMOD.Content
{
    internal class GlobalRecipes : ModSystem
    {
        public override void AddRecipes()
        {
         
            var re1 = ModContent.GetInstance<Items.Materials.Filled_Small_Flask>();
            re1.CreateRecipe()
                .AddIngredient(ModContent.GetInstance<Items.Materials.Empty_Small_Flask>(), 1)
                .AddCondition(Recipe.Condition.NearWater)
                .Register();

            var re2 = ModContent.GetInstance<Items.Consumables.Small_Pewter_Flask>();
            re2.CreateRecipe()
                .AddIngredient(ModContent.GetInstance<Items.Materials.Filled_Small_Flask>(), 1)
                //.AddIngredient(ModContent.GetInstance<Items.Materials.Allomantic_Pewter_Dust>(), 10)
                .AddIngredient(ItemID.Acorn, 1)
                .Register();

        }
    }
}
