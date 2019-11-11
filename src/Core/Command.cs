using HC.Core.Design;

namespace HC.Core
{
	public class Command
	{
		public string Id { get; private set; }

		public IData Data { get; private set; }

		public Command(string id, IData data) 
		{
			Id = id;
			Data = data;
		}

		public override string ToString()
		{
			return $"Command Id={Id} Data={Data}";
		}
	}
}