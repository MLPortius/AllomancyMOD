using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace AllomancyMOD.Content.Items.Accesories
{
    // Heredo la clase desde la libreria Terraria.ModLoader
    internal class Misthood : ModItem
    {

        // Item's information as DisplayName and Tooltip
        public override void SetStaticDefaults()
        {

            // INFORMATION
            DisplayName.SetDefault("Misthood");
            Tooltip.SetDefault("\nIncreases maximun jump by 100" +
                                   "\nIncreases damage by 50%" +
                                   "\nDecreases allomancy burning by 50%");

            // JOURNEYS MODE RESEARCH
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
        //  Item's properties, such as width, damage, shootSpeed, defense, etc.

            // width and height are int from the bottom center of the texture
            Item.width = 22; 
            Item.height = 22;
            Item.value = Item.buyPrice(gold: 1);
            Item.accessory = true;
            Item.rare = ItemRarityID.Purple;           
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Since we're using DamageClass.Generic, these bonuses apply to ALL damage the player deals.
            player.GetDamage(DamageClass.Generic) += 0.50f;

            player.jump += 5;
            //player.jumpSpeedBoost *= 10;
        }
    }
}
