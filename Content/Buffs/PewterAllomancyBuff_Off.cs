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
    public class PewterAllomancyBuff_Off : ModBuff
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pewter Allomancy");
            Description.SetDefault("You are a Pewter Arm.");

            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            Main.buffNoSave[Type] = true;
            
        }

        public override bool RightClick(int buffIndex)
        {
            return true;
        }

    }
}
