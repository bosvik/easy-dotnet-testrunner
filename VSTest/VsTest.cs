using System.Threading.Tasks;

namespace EasyDotnet.VSTest;

public static class VsTestHandler
{
  public static void RunDiscover(DiscoverRequest request)
  {
    var tests = DiscoverHandler.Discover(request.VsTestPath, request.DllPath);
    TestWriter.WriteDiscoveredTests(tests, request.OutFile);
  }

  public static Task RunTestsAsync(IRunRequest request)
  {
    throw new System.NotImplementedException();
  }

}