using System;

namespace HC.Core.DataTypes
{
	public class StringData : AbstractData<string>
	{
		public StringData() : base() {}

		public StringData(string value) : base(value) {}

		public static implicit operator StringData(string value) => new StringData(value);

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
				return true;
			
			return false;
		}

		// suppress warning
		public override int GetHashCode() => base.GetHashCode();
	}
}