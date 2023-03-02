using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using System.Timers;

namespace AllomancyMOD.Content.Items.Materials
{
    public class Tiny_Investiture_Spark : ModItem
    {

        private static int itemMaxLifeTime = 300; // 5 seconds
        private bool itemVanishing;
        private int itemCurrentLifeTime;
        // private float itemCurrentLifePercent;

        private int aframes = 6;
        
        private static float vanish_threshold = 0.5f;
        private static int alpha_max = 255;
        
        private float itemCurrentLight;
        private static float itemLightMax = 1.0f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tiny Investiture Spark");
            Tooltip.SetDefault("'A tiny splinter of the investiture inside all living beings...'");

            ItemID.Sets.ItemNoGravity[Item.type] = true; // Makes the item have no gravity
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 259;
          
        }

        private float ChangePercentFromCurrentLife(string Mode)
        {

            float th = vanish_threshold;
            float po = this.itemCurrentLifeTime*1f / itemMaxLifeTime*1f;
            float x = po / th;

            if  (x <= 1.0f)
            {
                if (Mode == "hard")
                {
                    float m = -1.0f;
                    float n = 1.0f;
                    float t = 0.0f;

                    float y = m * (x + t) + n;

                    return y;
                }

                else if (Mode == "soft")
                {
                    float a = 0.23f;
                    float b = 1.3f;
                    float c = 0.9977f;
                    float h = 0.0f;
                    float v = -0.3f;
                    float k = 1.0f;

                    float y = Convert.ToSingle(k * (b * Math.Pow(a,c*x+h) + v));

                    return y;
                }

                else
                {
                    return -1.0f;
                }
            }

            else
            {
                return 0.0f;
            }
        }
            
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 18;

            Item.maxStack = 1616;

            Item.value = Item.buyPrice(copper: 1);  // TEMPORAL
            Item.rare = ItemRarityID.Purple;        // TEMPORAL

            Item.material = true;
            // Item.consumable = true;

            itemVanishing = false;
            itemCurrentLifeTime = itemMaxLifeTime;
            // itemCurrentLifePercent = itemCurrentLifeTime*1f / itemMaxLifeTime*1f;

            Item.alpha = 0;

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(aframes, 4));
            // ItemID.Sets.ItemIconPulse[Item.type] = false; // The item pulses while in the player's inventory

            itemCurrentLight = itemLightMax;
        }

        public override void HoldItem(Player player)
        {
            Lighting.AddLight(Item.Center, Color.LightBlue.ToVector3() * this.itemCurrentLight /* *Main.essScale */);  // Makes this item glow when thrown out of inventory.                                                                                                 // Main.essScale makes the item to pulse glow
        
        }

        public override void PostUpdate() // En el mundo y no sostenido por el usuario
        {
            
            if (this.itemVanishing == false)
            {
                this.itemVanishing = true;
                this.itemCurrentLifeTime = itemMaxLifeTime;
                this.itemCurrentLight = itemLightMax;
            }

            else
            {

                if (this.itemCurrentLifeTime > 0)
                {
                    this.itemCurrentLifeTime -= 1;

                    float change = ChangePercentFromCurrentLife("soft");

                    this.Item.alpha = Convert.ToInt32(change * alpha_max);
                    this.itemCurrentLight = (1.0f - change) * itemLightMax;

                    Lighting.AddLight(Item.Center, Color.LightBlue.ToVector3() * this.itemCurrentLight);


                    if (this.itemCurrentLifeTime == 1) { this.Item.active = false;}
                }
                
                else { this.Item.TurnToAir(); }
            }

            if (ItemID.Sets.AnimatesAsSoul[Item.type] == false)
            {
                ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            }

        }

        public override void UpdateInventory(Player player) // En el inventario
        {

            if (this.itemVanishing == true)
            {
                this.itemVanishing = false;
                this.itemCurrentLifeTime = itemMaxLifeTime;
                this.Item.alpha = 0;
                this.itemCurrentLight = itemLightMax;
            }

            if (ItemID.Sets.AnimatesAsSoul[Item.type] == true)
            {
                ItemID.Sets.AnimatesAsSoul[Item.type] = false; // Makes the item have an animation while in world (not held.). Use in combination with RegisterItemAnimation
            }
        }      
    }
}
