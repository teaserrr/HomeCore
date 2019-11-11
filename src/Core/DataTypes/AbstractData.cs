using HC.Core.Design;

namespace HC.Core.DataTypes
{
	public abstract class AbstractData<TData> : IData
	{
		public TData Value { get; private set; }

		public AbstractData() {}

		public AbstractData(TData value) => Value = value;

		public bool IsValid() => Value != null;

		public static implicit operator TData(AbstractData<TData> value) => value.Value;
		
		public override string ToString() 
		{
			return Value?.ToString() ?? "<UNKNOWN>";
		}
		
		public override bool Equals(object obj)
		{
			if (obj == null)
				return Value == null;
			
			if (obj is AbstractData<TData>)
				return Equals(Value, ((AbstractData<TData>)obj).Value);

			if (obj is TData)
				return Equals(Value, obj);

			return base.Equals(obj);
		}

		public override int GetHashCode() => Value.GetHashCode();
	}
}