using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

using AllomancyMOD.Common.ItemDropRules.DropConditions;
using AllomancyMOD.Content.Items.Materials;


namespace AllomancyMOD.Common.GlobalNPCs
{
    public class TinyInvestitureSparkGNPC : GlobalNPC
    {

        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
            // 1/10 chance = 10% - 1 item minimun - 1 item maximun
            globalLoot.Add(ItemDropRule.ByCondition(new TinyInvestitureSparkDrop() , ModContent.ItemType<Tiny_Investiture_Spark>(), 2, 1, 1)); 
        }
    }
}
