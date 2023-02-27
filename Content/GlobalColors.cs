using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace AllomancyMOD.Content
{
    public class GlobalColors 
    {

        private static int GetAlpha(double value)
        {
            double alpha = value * 255;
            return Convert.ToInt32(alpha);
        }

        public static readonly Color Pewter = new Color(119, 104, 52, GetAlpha(0.60));
        public static readonly Color Copper = new Color(230, 122, 55, GetAlpha(0.76));
    }
}
