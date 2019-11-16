namespace HC.Core.Design
{
  public interface ILog
  {
    void Verbose(string message);
    void Debug(string message);
    void Info(string message);
    void Notice(string message);
    void Warning(string message);
    void Error(string message);
    void Critical(string message);
    void Fatal(string message);
  }
}
