using ns18;
using System;
using System.Text;

namespace ns21
{
	public class Class315 : Class310
	{
		public string string_0 = "";

		public Class315()
		{
			this.vmethod_0();
		}

		public Class315(string string_1)
		{
			this.string_0 = string_1;
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 31;
		}

		public override object vmethod_7()
		{
			return this.string_0;
		}

		public override byte[] vmethod_8()
		{
			return Encoding.ASCII.GetBytes(this.string_0);
		}

		public override void vmethod_9(byte[] byte_0)
		{
			this.string_0 = Encoding.ASCII.GetString(byte_0);
		}

		public override string vmethod_3()
		{
			return "\"" + this.string_0 + "\"";
		}

		public override string vmethod_5()
		{
			return "Ascii Value";
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += Encoding.ASCII.GetByteCount(this.string_0);
		}
	}
}
