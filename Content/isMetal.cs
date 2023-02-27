using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace AllomancyMOD.Content
{
    internal class isMetal
    {

        private static short[] ids = { ItemID.IronBar, ItemID.IronAnvil };
        private static bool[] bools = { true, true };
        private static Type[] types;

        private static Array boolean;


        public static void AddItem(short id, bool ismetal)
        {
            int len = ids.Length;
            ids[len] = id;
            bools[len] = ismetal;
            types[len] = id.GetType();
        }
    }
}
