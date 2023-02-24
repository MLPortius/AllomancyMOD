using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace AllomancyMOD.Content.Items.Weapons
{
    internal class KolossSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Koloss Sword");
            Tooltip.SetDefault("\nA huge forged sword designed for Koloss creatures" +
                               "\n\n" +
                               "\nEven the smallest being could use it with a bit of allomantic pewter...");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {

            // TEXTURE
            Item.width = 80; // The item texture's width.
            Item.height = 92; // The item texture's height.

            // USING ANIMATION
            Item.useStyle = ItemUseStyleID.Swing; // The useStyle of the Item.
            Item.useAnimation = 45; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
            Item.useTime = 45; // Swing Cooldown, the time span of using the weapon. Remember in terraria, 60 frames is a second.
            Item.autoReuse = false; // Whether the weapon can be used more than once automatically by holding the use button.
            
            // DAMAGE PROPERTIES
            Item.DamageType = DamageClass.Melee; // Whether your item is part of the melee class.
            Item.damage = 200; // The damage your item deals.
            Item.knockBack = 10; // The force of knockback of the weapon. Maximum is 20
            Item.crit = 6; // The critical strike chance the weapon has. The player, by default, has a 4% critical strike chance.

            // MISC
            Item.value = Item.buyPrice(gold: 1); // The value of the weapon in copper coins.
            Item.rare = ItemRarityID.Purple; // Give this item our custom rarity.
            Item.UseSound = SoundID.Item1; // The sound when the weapon is being used.

            bool isMetal = true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                // Emit dusts when the sword is swung

                // TERRARIA DUST
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Wraith);
                
                // CUSTOM DUST
                // Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Dusts.Sparkle>());
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            // Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
            // 60 frames = 1 second
            target.AddBuff(BuffID.BrokenArmor, 1800);
        }

        public override void AddRecipes() {

            // Temporal
            Recipe recipe3 = Recipe.Create(ModContent.ItemType<Items.Weapons.KolossSword>(), 1);
            recipe3.AddIngredient(ItemID.Wood, 10);
            recipe3.Register();


            var resultItem = ModContent.GetInstance<Items.Weapons.KolossSword>();
            // Start a new Recipe.
            resultItem.CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddRecipeGroup(RecipeGroupID.IronBar, 50)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }
}
    