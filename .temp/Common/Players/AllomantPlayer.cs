//using Terraria;
//using Terraria.ModLoader;
//using Terraria.ModLoader.IO;
//using AllomancyMOD.Content.Buffs;

//namespace AllomancyMOD.Common.Players
//{
//    public class AllomantPlayer : ModPlayer
//    {

//        public bool Pewter;
//        public bool Copper;
//        public bool Tin;
//        public bool Iron;
//        public bool Steel;


//        public override void Initialize()
//        {
//            Pewter = false;
//            Copper = false;
//            Tin = false;
//            Iron = false;
//            Steel = false;
//        }

//        public override void SaveData(TagCompound tag)
//        {
//            tag.Set("Pewter", Pewter);
            
//            //if (Pewter == true)
//            //{
                
//            //}
            
//        }


//        public override void LoadData(TagCompound tag)
//        {
//            if (tag.ContainsKey("Pewter"))
//            {
//                Pewter = tag.GetBool("Pewter");
//            }
            
//        }

        
//        public override void PostUpdateBuffs()
//        {
//            if (Pewter == true)
//            {
//                if (!Player.HasBuff(ModContent.BuffType<PewterAllomancyBuff_Off>()))
//                {
//                    int timerSeconds = 60 /*seconds*/ * 60 /*minutes*/* 16 /*hours*/;
//                    Player.AddBuff(type: ModContent.BuffType<PewterAllomancyBuff_Off>(), timeToAdd: 60 * timerSeconds);
//                }
//            }
//        }
        //public override void PostUpdateBuffs()
        //{            

        //    if (Pewter == true)
        //    {
        //        bool hboff = Player.HasBuff(ModContent.BuffType<PewterAllomancyBuff_Off>());
        //        bool hbon = Player.HasBuff(ModContent.BuffType<PewterAllomancyBuff_Burn>());

        //        if (hbon == true)
        //        {
        //            if (hboff == true)
        //            {
        //                Player.ClearBuff(ModContent.BuffType<PewterAllomancyBuff_Off>());
        //            }    
        //        }

        //        else
        //        {
        //            if (hboff == false)
        //            {
        //                
        //            }
        //        }
        //    }
        //}
        
    }
}
