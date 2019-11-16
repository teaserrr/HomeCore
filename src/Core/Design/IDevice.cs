using System.Collections.Generic;

namespace HC.Core.Design
{
  public interface IDevice
  {
    IEnumerable<ICommandSink> CommandSinks { get; }
    IEnumerable<IDataSource> DataSources { get; }
    string Id { get; }

    ICommandSink GetCommandSink(string commandId);
    IDataSource GetDataSource(string dataId);
  }
}