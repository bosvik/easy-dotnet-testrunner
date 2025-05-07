namespace EasyDotnet.MTP;

public interface IDiscoverRequest
{
  string TestExecutablePath { get; init; }
  string OutFile { get; init; }
}