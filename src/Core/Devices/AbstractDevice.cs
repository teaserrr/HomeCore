namespace HC.Core.Devices
{
    public abstract class AbstractDevice
    {
		public string Id { get; private set; }
        
        protected AbstractDevice(string id) => Id = id;
    }
}