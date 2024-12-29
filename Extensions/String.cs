using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace tar.Bitvavo.Extensions {
  internal static partial class Extensions {
    public static bool HasText(this string source) {
      return !source.IsNullOrEmpty();
    }

    public static bool IsNullOrEmpty(this string source) {
      return string.IsNullOrEmpty(source);
    }

    public static decimal ToDecimal(this string source) {
      return decimal.Parse(source, NumberStyles.Any, CultureInfo.InvariantCulture);
    }

    public static decimal? ToDecimalOrNull(this string source) {
      if (decimal.TryParse(source, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result)) {
        return result;
      }

      return null;
    }

    public static T ToEnumByDescription<T>(this string source) where T : Enum {
      foreach (MemberInfo member in typeof(T).GetMembers()) {
        if (
          member
            .GetCustomAttributes<DescriptionAttribute>()
            .FirstOrDefault()?
            .Description == source
        ) {
          return (T)Enum.Parse(typeof(T), member.Name);
        }
      }

      throw new ArgumentException("A value with the given description was not found.", nameof(source));
    }
  }
}