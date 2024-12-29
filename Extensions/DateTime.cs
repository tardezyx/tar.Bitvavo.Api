using System;

namespace tar.Bitvavo.Api.Extensions {
  public static class DateTimeExtensions {
    public static string ToIso8601(this DateTime source) {
      return source.ToString("yyyy-MM-dd HH:mm:ss.fff");
    }

    public static long ToUnixTimeMilliseconds(this DateTime source) {
      return ((DateTimeOffset)source).ToUnixTimeMilliseconds();
    }
  }
}