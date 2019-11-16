﻿using HC.Core.Design;
using Xunit.Abstractions;

namespace HC.Core.Test
{
  public class TestLogger : ILog
  {
    private readonly ITestOutputHelper _testOutputHelper;

    public TestLogger(ITestOutputHelper testOutputHelper)
    {
      _testOutputHelper = testOutputHelper;
    }

    private void Log(string severity, string message)
    {
      _testOutputHelper.WriteLine($"[{severity}] {message}");
    }

    public void Critical(string message) => Log("CRITICAL", message);

    public void Debug(string message) => Log("DEBUG", message);

    public void Error(string message) => Log("ERROR", message);

    public void Fatal(string message) => Log("FATAL", message);

    public void Info(string message) => Log("INFO", message);

    public void Notice(string message) => Log("NOTICE", message);

    public void Verbose(string message) => Log("VERBOSE", message);

    public void Warning(string message) => Log("WARNING", message);
  }
}
