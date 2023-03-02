using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using System;
// using AllomancyMOD.Content.Biomes;

namespace AllomancyMOD.Common.ItemDropRules.DropConditions
{
    public class TinyInvestitureSparkDrop : IItemDropRuleCondition
    {

        public bool CanDrop(DropAttemptInfo info)
        {
            if (!info.IsInSimulation)
            {
                // Can drop if it's not hardmode, and not a critter or an irrelevant enemy, and player is in the ExampleUndergroundBiome
                // Disclaimer: This is adapted from Conditions.SoulOfWhateverConditionCanDrop(info) to remove the cavern layer restriction, because ExampleUndergroundBiome also extends into the dirt layer

                NPC npc = info.npc;
                if (npc.boss || NPCID.Sets.CannotDropSouls[npc.type])
                {
                    return false;
                }

                if (/*!Main.hardMode ||*/ npc.lifeMax <= 1 || npc.friendly /*|| npc.position.Y <= Main.rockLayer * 16.0*/ || npc.value < 1f)
                {
                    return false;
                }

                    // return info.player.InModBiome<ExampleUndergroundBiome>(); # Use if you want to spawn it in a specific biome
                return true;
                    
            }

            return false;
        }
    
        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return "Drops in every biome and by every npc except from minnor foes";
        }
    }
}