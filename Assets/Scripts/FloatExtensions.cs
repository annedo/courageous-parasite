using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class FloatExtensions
    {
        public static bool IsBasicallyEqual(this float float1, float float2, float difference = 0.3f)
            => Math.Abs(float1 - float2) < difference ? true : false;
    }
}
