using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllomancyMOD.Content.Items.Tools
{
    internal class TestingItem : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Developing Tool");
            Tooltip.SetDefault("isMetal bool...");
        }

        public override void AddRecipes()
        {
            var recipe = ModContent.GetInstance<Items.Tools.TestingItem>();
            recipe.CreateRecipe()
                .AddIngredient(ItemID.Wood, 1)
                .Register();
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.autoReuse = false;
        }

        public override void UseAnimation(Player player)
        {
            ModContent.GetInstance<Items.Weapons.KolossSword>();

            Instance
        }
    }
}
