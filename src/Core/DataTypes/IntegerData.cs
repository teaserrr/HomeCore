using System;

namespace HC.Core.DataTypes
{
	public class IntegerData : AbstractData
	{
		private Int64? data;
		
		public IntegerData(Int64 value) => data = value;

		public override string ToString() 
		{
			return data?.ToString() ?? "<NULL>";
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			
			if (!(obj is IntegerData))
				return false;

			return Equals(data, ((IntegerData)obj).data);
		}

		public override int GetHashCode() => data.GetHashCode();
	}
}