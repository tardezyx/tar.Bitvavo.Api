using System;

namespace tar.Bitvavo.Api.Extensions {
  public static class LongExtensions {
    public static DateTime ToDateTimeFromUnixTimeMilliseconds(this long source) {
      return DateTimeOffset.FromUnixTimeMilliseconds(source).UtcDateTime;
    }
  }
}