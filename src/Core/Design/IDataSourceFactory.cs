namespace HC.Core.Design
{
    public interface IDataSourceFactory
    {
         IDataSource Create(string deviceId, string dataSourceId, IDataProvider dataProvider);
    }
}