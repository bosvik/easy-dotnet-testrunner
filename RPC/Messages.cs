using System.Text.Json;

namespace EasyDotnet.RPC;

public static class Messages
{
  public static readonly JsonSerializerOptions SerializerOptions = new()
  {
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = false
  };

  public static string InvalidRequest(long? id)
  {
    var response = new
    {
      id = id,
      error = new
      {
        code = -32600,
        message = "Invalid Request"
      },
    };
    return JsonSerializer.Serialize(response, SerializerOptions);
  }
  public static string InvalidJson()
  {
    var response = new
    {
      id = (long?)null,
      error = new
      {
        code = -32700,
        message = "Parse error"
      },
    };
    return JsonSerializer.Serialize(response, SerializerOptions);
  }

  public static string MethodNotFound(long id)
  {
    var response = new
    {
      id = id,
      error = new
      {
        code = -32601,
        message = "Method not found"
      },
    };
    return JsonSerializer.Serialize(response, SerializerOptions);
  }

  public static string Success(long id, object result)
  {
    var response = new
    {
      id = id,
      result = result
    };

    return JsonSerializer.Serialize(response, SerializerOptions);
  }
}