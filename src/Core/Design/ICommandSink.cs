namespace HC.Core.Design
{
  public interface ICommandSink
  {
    string Id { get; }

    void ProcessCommand(IData commandData);
	}
}