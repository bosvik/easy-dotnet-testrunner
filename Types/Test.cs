using System;

namespace EasyDotnet.Types;

public sealed record Test
{
  public Guid Id { get; set; }
  public string Namespace { get; set; }
  public string Name { get; set; }
  public string FilePath { get; set; }
  public int Linenumber { get; set; }
}