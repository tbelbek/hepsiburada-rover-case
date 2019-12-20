using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using hepsiburada_mars_rover;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T e) where T : IConvertible
    {
        if (!(e is Enum)) return null; // could also return string.Empty

        Type type = e.GetType();
        Array values = System.Enum.GetValues(type);

        foreach (int val in values)
        {
            if (val != e.ToInt32(CultureInfo.InvariantCulture)) continue;

            var memInfo = type.GetMember(type.GetEnumName(val));

            if (memInfo[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() is DescriptionAttribute descriptionAttribute)
            {
                return descriptionAttribute.Description;
            }
        }

        return null; // could also return string.Empty
    }


}