using System;

namespace ns13
{
	public class Class205 : ICloneable
	{
		private string string_0;

		private Class204 class204_0;

		private Class205()
		{
			this.class204_0 = new Class204();
		}

		public object Clone()
		{
			Class205 @class = new Class205();
			@class.string_0 = this.string_0;
			@class.class204_0 = (Class204)this.class204_0.Clone();
			@class.method_1(this.method_0());
			return @class;
		}

		public override bool Equals(object obj)
		{
			Class205 @class = obj as Class205;
			return @class != null && this.method_0().Equals(@class.method_0());
		}

		public override int GetHashCode()
		{
			return this.method_0().GetHashCode();
		}

		public string method_0()
		{
			return this.class204_0.method_0();
		}

		public void method_1(string string_1)
		{
			this.class204_0.method_1(string_1);
		}
	}
}
