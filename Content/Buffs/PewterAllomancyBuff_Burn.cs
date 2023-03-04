using System;

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ReLogic.Content;
using System.Threading;

namespace AllomancyMOD.Content.Buffs
{
    public class PewterAllomancyBuff_Burn : ModBuff
    {

        public const int FrameCount = 6; // Amount of frames we have on our animation spritesheet.
        public const int AnimationSpeed = 20; // In ticks.
        public const string AnimationSheetPath = "AllomancyMOD/Content/Buffs/PewterAllomancyBuff_Burn_Animation";

        private Asset<Texture2D> animatedTexture;

         
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pewter Allomancy");
            Description.SetDefault("Grants +8 defense," +
                                   "\nGrants 5% melee damage." +
                                   "\nGrants 16% melee speed." +
                                   "\tDoubles jump height." +
                                   "\nDoubles fall resist." +
                                   "\nGrants 20% run acceleraion." +
                                   "\nGrants 20% max run speed." +
                                   "\nDecrease 16% run slowdown." +
                                   "\nGrants 8% pick speed");

            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            Main.buffNoSave[Type] = true;
            
            if (Main.netMode != NetmodeID.Server)
            {
                // Do NOT load textures on the server!
                animatedTexture = ModContent.Request<Texture2D>(AnimationSheetPath);
            }
        }

        public override void Unload()
        {
            animatedTexture = null;
        }

        public override bool RightClick(int buffIndex)
        {
            return true;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, int buffIndex, ref BuffDrawParams drawParams)
        {
            // Use our animation spritesheet.
            Texture2D ourTexture = animatedTexture.Value;

            // Choose the frame to display, here based on constants and the game's tick count.
            Rectangle ourSourceRectangle = ourTexture.Frame(verticalFrames: FrameCount, frameY: (int)Main.GameUpdateCount / AnimationSpeed % FrameCount);

            // OPTION 1 - Let the game draw it for us. Therefore we have to assign our variables to drawParams:
            drawParams.Texture = ourTexture;
            drawParams.SourceRectangle = ourSourceRectangle;

            // Return true to let the game draw the buff icon.
            return true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 4;

            player.GetDamage<MeleeDamageClass>() *= 1f + 0.050f;
            player.GetAttackSpeed<MeleeNoSpeedDamageClass>() *= 1f + 0.10f;

            int Init_extrafall = player.extraFall;
            player.extraFall *= Convert.ToInt32(Init_extrafall * 3f);
            player.jumpSpeedBoost += 1f;
            player.jumpBoost = true;
            
            player.runAcceleration *= 1.16f;
            player.maxRunSpeed *= 1.16f;
            player.runSlowdown *= 1.08f;

            player.pickSpeed *= 1.08f;

        }  

    }
}
