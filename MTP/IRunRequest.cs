namespace EasyDotnet.MTP;

public interface IRunRequest
{
  string TestExecutablePath { get; init; }
  string Filter { get; init; }
  string OutFile { get; init; }
}