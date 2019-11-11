using System;

namespace HC.Core.DataTypes
{
	public class IntegerData : AbstractData<long?>
	{
		public IntegerData() : base() {}

		public IntegerData(long? value) : base(value) {}

		public static implicit operator IntegerData(long value) => new IntegerData(value);
		public static implicit operator IntegerData(long? value) => new IntegerData(value);

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
				return true;

			if (obj is int)
				return Equals(Value, (long?)Convert.ToInt64(obj));
				
			if (obj is double)
				return Equals(Value, (long?)Convert.ToInt64(obj));
			
			return false;
		}

		// suppress warning
		public override int GetHashCode() => base.GetHashCode();
	}
}