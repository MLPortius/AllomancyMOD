using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;


namespace AllomancyMOD.Common.Players
{
    public class AllomanticPewterPlayer : ModPlayer
    {

        private static int DefaultCurrentPewter = 0;
        public int PewterCurrent;                   // Controls the current value of the resource - exampleResourceCurrent

        public static int DefaultPewterMax = 100;   // Defines the maximun value of the resource - DefaultExampleResourceMax
        public int CurrentPewterMax;                // Buffer variable to reset the maximum - exampleResourceMax

        private static float DefaultPewterRegenRate = 0.0f;
        public float CurrentPewterRegenRate;

        private int PewterRegenTimer = 0;           // Timer variable for regeneration - exampleResourceRegenTimer


        public override void Initialize()
        {
            CurrentPewterMax = DefaultPewterMax;
            CurrentPewterRegenRate = DefaultPewterRegenRate;
            PewterCurrent = DefaultCurrentPewter;
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
