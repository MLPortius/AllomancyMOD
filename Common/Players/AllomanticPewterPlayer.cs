using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;
using Terraria.Audio;

namespace AllomancyMOD.Common.Players
{
    public class AllomanticPewterPlayer : ModPlayer
    {

        private static float DefaultCurrentPewter = 0f;
        public float PewterCurrent;                   // Controls the current value of the resource - exampleResourceCurrent

        public static int DefaultPewterMax = 100;   // Defines the maximun value of the resource - DefaultExampleResourceMax
        public int CurrentPewterMax;                // Buffer variable to reset the maximum - exampleResourceMax

        private static float DefaultPewterRegenRate = 0.0f;
        public float CurrentPewterRegenRate;

        private int PewterRegenTimer = 0;           // Timer variable for regeneration - exampleResourceRegenTimer

        private static float DefaultPewterBurningRate = 1.0f / 60f;
        public float CurrentPewterBurningRate;

        public override void Initialize()
        {
            CurrentPewterMax = DefaultPewterMax;
            CurrentPewterRegenRate = DefaultPewterRegenRate;
            PewterCurrent = DefaultCurrentPewter;
            CurrentPewterBurningRate = DefaultPewterBurningRate;
        }

        public override void SaveData(TagCompound tag)
        {
            if (PewterCurrent != DefaultCurrentPewter)
            {
                tag.Add("PewterCurrent", PewterCurrent);
            }
            
            if (CurrentPewterMax != DefaultPewterMax) 
            {
                tag.Add("CurrentPewterMax", CurrentPewterMax);
            }

            if (CurrentPewterRegenRate != DefaultPewterRegenRate)
            {
                tag.Add("CurrentPewterRegenRate", CurrentPewterRegenRate);
            }
        }

        public override void LoadData(TagCompound tag)
        { 
            if (tag.ContainsKey("PewterCurrent"))
            {
                PewterCurrent = tag.GetInt("PewterCurrent");
            }

            if (tag.ContainsKey("CurrentPewterMax"))
            {
                CurrentPewterMax = tag.GetInt("CurrentPewterMax");
            }

            if (tag.ContainsKey("CurrentPewterRegenRate"))
            {
                CurrentPewterRegenRate = tag.GetInt("CurrentPewterRegenRate");
            }

        }

        public override void PostUpdateBuffs()
        {
            if (Player.HasBuff(ModContent.BuffType<Content.Buffs.PewterAllomancyBuff_Burn>()))
            {
                if (CurrentPewterRegenRate != DefaultPewterRegenRate)
                {
                    CurrentPewterRegenRate = DefaultPewterRegenRate;
                }
                
                if (PewterCurrent > 0)
                {

                    if (PewterCurrent >= CurrentPewterBurningRate)
                    {
                        PewterCurrent -= CurrentPewterBurningRate;
                    }

                    else
                    {
                        PewterCurrent -= PewterCurrent;
                    }
                }

                else
                {
                    SoundEngine.PlaySound(style: SoundID.LiquidsWaterLava, position: Player.position);
                    Player.ClearBuff(ModContent.BuffType<Content.Buffs.PewterAllomancyBuff_Burn>());

                    int timerSeconds = 60 /*seconds*/ * 60 /*minutes*/* 16 /*hours*/;
                    Player.AddBuff(ModContent.BuffType<Content.Buffs.PewterAllomancyBuff_Off>(), timerSeconds*60);
                }
            }
        }

        private void ResetVariables()
        {
            PewterCurrent = DefaultCurrentPewter;
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }
    }
}
