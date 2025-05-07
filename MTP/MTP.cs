using System.IO;
using System.Threading.Tasks;

namespace EasyDotnet.MTP;

public static class MTPHandler
{
  public static Task RunDiscoverAsync(IDiscoverRequest request)
  {
    if (!File.Exists(request.TestExecutablePath))
    {
      throw new FileNotFoundException("Test executable not found.", request.TestExecutablePath);
    }
    throw new System.NotImplementedException();
  }

  public static Task RunTestsAsync(IRunRequest request)
  {
    throw new System.NotImplementedException();
  }
}