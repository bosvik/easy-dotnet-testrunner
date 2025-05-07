using System.Text.Json;

namespace EasyDotnet.RPC;

public class RpcRequest
{
  public long Id { get; set; }
  public string Method { get; set; } = "";
  public JsonElement Params { get; set; }
}

public class RpcRequest<T>
{
  public long Id { get; set; }
  public string Method { get; set; } = "";
  public T Params { get; set; } = default!;
}