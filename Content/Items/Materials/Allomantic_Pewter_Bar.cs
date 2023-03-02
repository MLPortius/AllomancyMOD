using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using AllomancyMOD.Content;

namespace AllomancyMOD.Content.Items.Materials
{
    public class Allomantic_Pewter_Bar : ModItem
    {

        public bool isMetal = true;
        private float lightIntensity = 1.5f;

        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Allomantic Pewter Bar");
            Tooltip.SetDefault("'An invested metal bar, useful for allomancy and maybe more...'" +
                               "\nIt contains 100 units of pewter dust.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 259;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.material = true;
            Item.maxStack = 16;
           
            Item.value = Item.buyPrice(copper: 1);  // TEMPORAL
            Item.rare = ItemRarityID.Purple;        // TEMPORAL
        }


        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, GlobalColors.Pewter.ToVector3() * this.lightIntensity);
        }
    }
}
