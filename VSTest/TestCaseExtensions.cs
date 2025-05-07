using EasyDotnet.Types;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace EasyDotnet.VSTest;

public static class TestCaseExtensions
{
  public static Test Map(this TestCase x) =>
     new()
     {
       Id = x.Id,
       Namespace = x.FullyQualifiedName,
       Name = x.DisplayName,
       //TODO: replace all \ with /
       FilePath = x.CodeFilePath.Replace("\\","/"),
       Linenumber = x.LineNumber
     };


}