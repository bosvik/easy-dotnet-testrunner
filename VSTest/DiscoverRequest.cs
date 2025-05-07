namespace EasyDotnet.VSTest;

public sealed record DiscoverRequest
{
  public string VsTestPath { get; init; }
  public string DllPath { get; init; }
  public string OutFile { get; init; }
}