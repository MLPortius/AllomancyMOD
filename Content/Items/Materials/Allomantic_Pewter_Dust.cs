using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AllomancyMOD.Content;
using Terraria.GameContent.Creative;

namespace AllomancyMOD.Content.Items.Materials
{
    public class Allomantic_Pewter_Dust : ModItem
    {
        public static bool isMetal = true;
        private float lightIntensity = 1.2f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Allomantic Pewter Dust");
            Tooltip.SetDefault("'An invested metal dust, useful for allomancy and maybe more...'");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1616;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 14;
            Item.material = true;
            Item.maxStack = 1616;

            Item.value = Item.buyPrice(copper: 1);  // TEMPORAL
            Item.rare = ItemRarityID.Purple;        // TEMPORAL
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, GlobalColors.Pewter.ToVector3() * this.lightIntensity);
        }
    }
}
