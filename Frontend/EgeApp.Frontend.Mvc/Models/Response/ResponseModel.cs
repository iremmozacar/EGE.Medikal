using System;
using System.Text.Json.Serialization;

namespace EgeApp.Frontend.Mvc.Models.Response;

public class ResponseModel<T>
{
    [JsonPropertyName("data")]
    public T Data { get; set; }

    [JsonPropertyName("error")]
    public string Error { get; set; }

    [JsonPropertyName("isSucceeded")]
    public bool IsSucceeded { get; set; }
}
