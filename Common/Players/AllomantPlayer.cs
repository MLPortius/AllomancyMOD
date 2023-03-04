using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using AllomancyMOD.Content.Buffs;

namespace AllomancyMOD.Common.Players
{
    public class AllomantPlayer : ModPlayer
    {

        public bool Pewter;
        private bool InitialPewter;

//        public bool Copper;
//        public bool Tin;
//        public bool Iron;
//        public bool Steel;


        public override void Initialize()
        {
            Pewter = false;
            InitialPewter = Pewter;
//            Copper = false;
//            Tin = false;
//            Iron = false;
//            Steel = false;
        }

        public override void SaveData(TagCompound tag)
        {
            if (Pewter != InitialPewter)
            {
                tag.Set("Pewter", Pewter);
            }
            
        }

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("Pewter"))
            {
                Pewter = tag.GetBool("Pewter");
                InitialPewter = Pewter;
            }
        }
    }
}
