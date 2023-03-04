using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ID;
using Terraria.Audio;

using AllomancyMOD.Common.Players;
using AllomancyMOD.Content.Buffs;
using Microsoft.Xna.Framework.Audio;
using System.Security.Cryptography.X509Certificates;

namespace AllomancyMOD.Common.Players
{
    public class AllomanticPewterPlayer : ModPlayer
    {

        private static float DefaultCurrentPewter = 0f;
        public float PewterCurrent;                   // Controls the current value of the resource - exampleResourceCurrent

        public static int DefaultPewterMax = 100;   // Defines the maximun value of the resource - DefaultExampleResourceMax
        public int CurrentPewterMax;                // Buffer variable to reset the maximum - exampleResourceMax

        private static float DefaultPewterBurningRate = 1.0f;
        private float CurrentPewterBurningRateFrames = DefaultPewterBurningRate / 60f;
        public float CurrentPewterBurningRate;


        private static float DefaultPewterRegenRate = 0.0f;
        private float CurrentPewterRegenRateFrames = DefaultPewterRegenRate/60f;
        public float CurrentPewterRegenRate;
        
        private bool isRegenerating; 

        public override void Initialize()
        {
            PewterCurrent = DefaultCurrentPewter;
            CurrentPewterMax = DefaultPewterMax;
            CurrentPewterBurningRate = DefaultPewterBurningRate;
            CurrentPewterRegenRate = DefaultPewterRegenRate;            
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Set("CurrentPewter", PewterCurrent, true);
            
            if (CurrentPewterMax != DefaultPewterMax)
            {
                tag.Set("CurrentPewterMax", CurrentPewterMax, true);
            }

            if (CurrentPewterBurningRate != DefaultPewterBurningRate)
            {
                tag.Set("CurrentPewterBurningRate", CurrentPewterBurningRate, true);
            }

            if (CurrentPewterRegenRate != DefaultPewterRegenRate)
            {
                tag.Set("CurrentPewterRegenRate", CurrentPewterRegenRate, true);
            }
        }

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("CurrentPewter"))
            {
                PewterCurrent = tag.GetFloat("CurrentPewter");
            }

            if (tag.ContainsKey("CurrentPewterMax"))
            {
                PewterCurrent = tag.GetInt("CurrentPewterMax");
            }

            if (tag.ContainsKey("CurrentPewterBurningRate"))
            {
                CurrentPewterBurningRate = tag.GetFloat("CurrentPewterBurningRate");
            }

            if (tag.ContainsKey("CurrentPewterRegenRate"))
            {
                CurrentPewterRegenRate = tag.GetFloat("CurrentPewterRegenRate");
            }
        }

        public override void PreUpdate()
        {
            float Brate = CurrentPewterBurningRate / 60f;

            if (Brate != CurrentPewterBurningRateFrames)
            {
                CurrentPewterBurningRateFrames = Brate;
            }

            float Rrate = CurrentPewterBurningRate / 60f;

            if (Rrate != CurrentPewterRegenRateFrames)
            {
                CurrentPewterRegenRateFrames  = Rrate;
            }

            var allomantPlayer = Player.GetModPlayer<AllomantPlayer>();
            if (allomantPlayer.Pewter == false)
            {
                PewterCurrent = 0f;
            }
        }

        public override void PostUpdateBuffs()
        {

            var allomantPlayer = Player.GetModPlayer<AllomantPlayer>();

            
            // Si el player es alomante de peltre
            if (allomantPlayer.Pewter == true)
            {

                if (isRegenerating == true)
                {
                    if (CurrentPewterRegenRate > 0)
                    {
                        PewterCurrent += CurrentPewterRegenRateFrames;
                    }
                }

                // Y no tiene el buff basico
                if (!Player.HasBuff(ModContent.BuffType<PewterAllomancyBuff_Off>()))
                {
                    // Y no esta quemando peltre
                    if (!Player.HasBuff(ModContent.BuffType<PewterAllomancyBuff_Burn>()))
                    {
                        // Agregar el buff basico
                        int timerSeconds = 60 /*seconds*/ * 60 /*minutes*/* 16 /*hours*/;
                        Player.AddBuff(type: ModContent.BuffType<PewterAllomancyBuff_Off>(), timeToAdd: 60 * timerSeconds);
                    }

                    // Y esta quemando peltre
                    else
                    {

                        if (isRegenerating == true)
                        {
                            isRegenerating = false;
                        }

                        if (PewterCurrent > 0)
                        {
                            float diff = PewterCurrent - CurrentPewterBurningRateFrames;
                            
                            if (diff >= 0)
                            {
                                PewterCurrent -= CurrentPewterBurningRateFrames;
                            }

                            else
                            {
                                PewterCurrent -= PewterCurrent;
                            }
                        }

                        else
                        {
                            bool buffcleared = ClearBurn();
                        }
                    }
                }
            }

            // Si no es alomante de peltre
            else
            {
               // Y tiene el buff basico
               if (Player.HasBuff(ModContent.BuffType<PewterAllomancyBuff_Off>()))
                {
                    // Quitar el buff basico
                    Player.ClearBuff(ModContent.BuffType<PewterAllomancyBuff_Off>());
                }

                // Si esta quemando peltre, dejar de quemar
                bool burncleared = ClearBurn();
            }
        }

        public bool BurnPewter()
        {
            // Si el usuario puede quemar peltre
            var allomantPlayer = Player.GetModPlayer<AllomantPlayer>();
            if (allomantPlayer.Pewter == true)
            {
                // Si no esta quemando peltre
                if (!Player.HasBuff(ModContent.BuffType<PewterAllomancyBuff_Burn>()))
                {
                    // Y el player tiene peltre
                    if (PewterCurrent > 0)
                    {
                        // Si tiene el buff basico
                        if (Player.HasBuff(ModContent.BuffType<PewterAllomancyBuff_Off>()))
                        {
                            // Apago el buff basico
                            Player.ClearBuff(ModContent.BuffType<PewterAllomancyBuff_Off>());
                        }

                        SoundEngine.PlaySound(SoundID.Item20, Player.position);
                        int timerSeconds = 60 /*seconds*/ * 60 /*minutes*/* 16 /*hours*/;
                        Player.AddBuff(type: ModContent.BuffType<PewterAllomancyBuff_Burn>(), timeToAdd: 60 * timerSeconds);

                        return true;
                    }
                }
            }
            return false;
        }
        
        public bool ClearBurn()
        {

            if (Player.HasBuff(ModContent.BuffType<PewterAllomancyBuff_Burn>()))
            {
                if (isRegenerating == false)
                {
                    isRegenerating = true;
                }
                SoundEngine.PlaySound(SoundID.LiquidsWaterLava, Player.position);
                Player.ClearBuff(ModContent.BuffType<PewterAllomancyBuff_Burn>());
                return true;
            }
            return false;
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
