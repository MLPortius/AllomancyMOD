using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace AllomancyMOD.Common.Players
{
    internal class AllomanticPewterPlayer : ModPlayer
    {

        public int PewterCurrent;                   // Controls the current value of the resource - exampleResourceCurrent
        public const int DefaultPewterMax = 100;    // Defines the maximun value of the resource - DefaultExampleResourceMax
        public int PewterMax;                       // Buffer variable to reset the maximum - exampleResourceMax
        public int NewPewterMax;                    // Used to update the maximun value - exampleResourceMax2
        public float PewterRegenRate;               // Resource regeneration rate - exampleResourceRegenRate
        internal int PewterRegenTimer = 0;          // Timer variable for regeneration - exampleResourceRegenTimer
        public static readonly Color HealPewter = new(216, 200, 180); // Restoration color when restore resource - HealExampleResource

        public override void Initialize()
        {
            PewterMax = DefaultPewterMax;
        }

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            bool B = false;

            if (B == true)
            {
                ResetVariables();
            }
            
        }

        private void ResetVariables()
        {
            PewterRegenRate = 0f;
            NewPewterMax = PewterMax;
        }

        public override void PostUpdateMiscEffects()
        {
            UpdateResource();
        }

        // Function that controls the resource utilization
        private void UpdateResource()
        {
            // For our resource lets make it regen slowly over time to keep it simple, let's use exampleResourceRegenTimer to count up to whatever value we want, then increase currentResource.
            // PewterRegenTimer++; // Increase it by 60 per second, or 1 per tick.

            // A simple timer that goes up to 3 seconds, increases the exampleResourceCurrent by 1 and then resets back to 0.
            // if (PewterRegenTimer > 180 / PewterRegenRate)
            // {
                // PewterCurrent += 1;
                // PewterRegenTimer = 0;
            // }

            // Limit exampleResourceCurrent from going over the limit imposed by exampleResourceMax.
            PewterCurrent = Utils.Clamp(PewterCurrent, 0, NewPewterMax);
        }

    }

   
}
