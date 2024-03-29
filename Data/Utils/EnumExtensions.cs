﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{
    public static class EnumExtensions
    {
        public static Dictionary<int, string> ToDictionary(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            return Enum.GetValues(enumType)
                .Cast<Enum>()
                .ToDictionary(t => (int)(object)t, t => t.ToString());
        }
    }
}
