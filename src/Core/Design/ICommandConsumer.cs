namespace HC.Core.Design
{
  public interface ICommandConsumer
  {
    void Consume(Command command);
  }
}
