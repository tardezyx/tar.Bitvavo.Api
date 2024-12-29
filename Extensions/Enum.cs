using System;
using System.ComponentModel;
using System.Reflection;

namespace tar.Bitvavo.Extensions {
  internal static partial class Extensions {
    public static string GetDescription(this Enum source) {
      FieldInfo fieldInfo = source
        .GetType()
        .GetField(source.ToString());

      if (fieldInfo != null) {
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo
          .GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0
          ? attributes[0].Description
          : string.Empty;
      }

      return string.Empty;
    }
  }
}