using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using tar.Bitvavo.Api.Extensions;

namespace tar.Bitvavo.Api.RestApi.Responses {
  public class Response<T> {
    public T Data { get; set; }
    public string Error { get; set; }
    public int? ErrorCode { get; set; }
    public bool? IsSuccessful { get; set; }
    public bool? IsSuccessStatusCode { get; set; }
    public string JsonContent { get; set; }
    public int? RateLimit { get; set; }
    public int? RateLimitRemaining { get; set; }
    public DateTime? RateLimitResetAt { get; set; }
    public RestRequest Request { get; set; }
    public Uri ResponseUri { get; set; }
    public string Server { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string StatusDescription { get; set; }
    public Version Version { get; set; }

    public static Response<T> GetResponse(RestResponse<T> restResponse) {
      T data = default;
      ErrorResponse error = null;

      if (restResponse.Content != null) {
        if (restResponse.IsSuccessStatusCode) {
          data = JsonSerializer.Deserialize<T>(restResponse.Content, BvRestClient.JsonOptions);
        } else {
          error = JsonSerializer.Deserialize<ErrorResponse>(restResponse.Content, BvRestClient.JsonOptions);
        }
      }

      _ = int.TryParse(
        restResponse.Headers?.FirstOrDefault(x => x.Name == "bitvavo-ratelimit-limit")?.Value,
        out int rateLimit
      );

      _ = int.TryParse(
        restResponse.Headers?.FirstOrDefault(x => x.Name == "bitvavo-ratelimit-remaining")?.Value,
        out int rateLimitRemaining
      );

      DateTime? rateLimitResetAt = null;

      if (
        long.TryParse(
          restResponse.Headers?.FirstOrDefault(x => x.Name == "bitvavo-ratelimit-resetat")?.Value,
          out long rateLimitResetAtLong
        )
      ){
        rateLimitResetAt = rateLimitResetAtLong.ToDateTimeFromUnixTimeMilliseconds();
      }

      Response<T> response = new Response<T>() {
        Data = data,
        Error = error?.Error,
        ErrorCode = error?.ErrorCode,
        IsSuccessful = restResponse.IsSuccessful,
        IsSuccessStatusCode = restResponse.IsSuccessStatusCode,
        JsonContent = restResponse.Content,
        Request = restResponse.Request,
        ResponseUri = restResponse.ResponseUri,
        RateLimit = rateLimit,
        RateLimitRemaining = rateLimitRemaining,
        RateLimitResetAt = rateLimitResetAt,
        Server = restResponse.Server,
        StatusCode = restResponse.StatusCode,
        StatusDescription = restResponse.StatusDescription,
        Version = restResponse.Version
      };

      return response;
    }
  }
}