namespace EasyDotnet.VSTest
{
  public interface IRunRequest
  {
    string VSTestPath { get; init; }
    string Filter { get; init; }
    string OutFile { get; init; }
  }
}