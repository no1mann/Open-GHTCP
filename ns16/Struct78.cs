using System;

namespace ns16
{
	public struct Struct78 : IComparable, ICloneable
	{
		public float float_0;

		public float float_1;

		public Struct78(Struct78 struct78_0)
		{
			this.float_0 = struct78_0.float_0;
			this.float_1 = struct78_0.float_1;
		}

		object ICloneable.Clone()
		{
			return new Struct78(this);
		}

		public float method_0()
		{
			float num = this.float_0;
			float num2 = this.float_1;
			return (float)Math.Sqrt((double)(num * num + num2 * num2));
		}

		public static bool smethod_0(Struct78 struct78_0, Struct78 struct78_1)
		{
			return struct78_0.float_0 == struct78_1.float_0 && struct78_0.float_1 == struct78_1.float_1;
		}

		public override int GetHashCode()
		{
			return this.float_0.GetHashCode() ^ this.float_1.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Struct78)
			{
				Struct78 struct78_ = (Struct78)obj;
				return Struct78.smethod_0(this, struct78_);
			}
			return false;
		}

		public int CompareTo(object target)
		{
			if (target == null)
			{
				return 1;
			}
			if (target is Struct78)
			{
				return this.method_0().CompareTo(((Struct78)target).method_0());
			}
			if (target is float)
			{
				return this.method_0().CompareTo((float)target);
			}
			if (target is Struct79)
			{
				return this.method_0().CompareTo(((Struct79)target).method_0());
			}
			if (!(target is double))
			{
				throw new ArgumentException();
			}
			return this.method_0().CompareTo((double)target);
		}

		public override string ToString()
		{
			return string.Format("( {0}, {1}i )", this.float_0, this.float_1);
		}
	}
}
