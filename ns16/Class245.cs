using System;

namespace ns16
{
	public abstract class Class245 : IEquatable<Class245>
	{
		public bool method_0()
		{
			bool result;
			try
			{
				this.vmethod_0();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				result = false;
			}
			return result;
		}

		public abstract void vmethod_0();

		public abstract override string ToString();

		public abstract bool Equals(Class245 other);
	}
}
