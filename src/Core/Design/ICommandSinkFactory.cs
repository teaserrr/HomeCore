namespace HC.Core.Design
{
  public interface ICommandSinkFactory
  {
    ICommandSink Create(string id, ILog logger, ICommandConsumer commandConsumer);
  }
}