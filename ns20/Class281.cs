using ns18;
using ns21;
using System;
using System.Collections.Generic;

namespace ns20
{
	public class Class281 : Class278<Class316>
	{
		public int this[int int_0]
		{
			get
			{
				return ((Class316)base.Nodes[int_0]).int_0;
			}
			set
			{
				((Class316)base.Nodes[int_0]).int_0 = value;
			}
		}

		public Class281()
		{
			this.vmethod_0();
		}

		public Class281(IEnumerable<int> ienumerable_0)
		{
			this.method_11(ienumerable_0);
		}

		public override int vmethod_1()
		{
			return 14;
		}

		public void method_11(IEnumerable<int> ienumerable_0)
		{
			foreach (int current in ienumerable_0)
			{
				base.Nodes.Add(new Class316(current));
			}
			this.vmethod_0();
		}

		public void method_12(IEnumerable<int> ienumerable_0)
		{
			base.Nodes.Clear();
			this.method_11(ienumerable_0);
		}

		public override byte vmethod_15()
		{
			return 13;
		}

		public override string vmethod_5()
		{
			return "Tag Array";
		}
	}
}