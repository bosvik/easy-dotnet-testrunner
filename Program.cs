using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using EasyDotnet.RPC;
class Program
{
  private const string PipeName = "EasyDotnetPipe";

  public static async Task<int> Main(string[] args)
  {
    Console.WriteLine($"Named pipe server started: {PipeName}");
    var cancellationTokenSource = new CancellationTokenSource();

    Console.CancelKeyPress += (s, e) =>
    {
      Console.WriteLine("Shutting down server...");
      cancellationTokenSource.Cancel();
    };

    _ = Task.Run(() => AcceptClientsLoop(cancellationTokenSource.Token));

    await Task.Delay(Timeout.Infinite, cancellationTokenSource.Token);
    return 0;
  }

  private static async Task AcceptClientsLoop(CancellationToken token)
  {
    while (!token.IsCancellationRequested)
    {
      var serverStream = new NamedPipeServerStream(PipeName, PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

      await serverStream.WaitForConnectionAsync(token);
      _ = Task.Run(() => HandleClientAsync(serverStream), token);
    }
  }

  private static async Task HandleClientAsync(NamedPipeServerStream pipe)
  {
    var clientId = Guid.NewGuid().ToString()[..8];
    Console.WriteLine($"Client connected: {clientId}");

    using var reader = new StreamReader(pipe, Encoding.UTF8);
    using var writer = new StreamWriter(pipe, new UTF8Encoding(false)) { AutoFlush = true };
    try
    {
      while (pipe.IsConnected)
      {
        var line = await reader.ReadLineAsync();
        if (line == null)
          break;

        Console.WriteLine($"[{clientId}] Received: {line}");

        var response = await MessageProcesser.ProcessMessage(line);
        Console.WriteLine($"[{clientId}] Sent: {response}");
        await writer.WriteLineAsync(response);
      }
    }
    catch (IOException)
    {
      // Handle disconnection
    }

    Console.WriteLine($"Client disconnected: {clientId}");
    pipe.Dispose();
  }
}