using ns16;
using ns18;
using ns20;
using ns22;
using System;
using System.Collections;

namespace ns21
{
	public abstract class Class268 : zzUnkNode260
	{
		public abstract byte vmethod_16();

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.ReadInt();
			this.int_1 = stream26_0.ReadInt();
			if (this is FloatRootNode)
			{
				base.Nodes.Add(new FloatValueNode(stream26_0.ReadFloat()));
			}
			else if (this is IntegerRootNode)
			{
				base.Nodes.Add(new IntegerValueNode(stream26_0.ReadInt()));
			}
			else if (this is TagRootNode || this is FileTagRootNode)
			{
				base.Nodes.Add(new TagValueNode(stream26_0.ReadInt()));
			}
			stream26_0.ReadInt();
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
            array[1] = (this.vmethod_7() ? (byte)32 : (byte)4);
			array[2] = this.vmethod_16();
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteInt(this.int_0);
			stream26_0.WriteInt(this.int_1);
			if (base.Nodes.Count != 0)
			{
				IEnumerator enumerator = base.Nodes.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						AbstractTreeNode2 @class = (AbstractTreeNode2)enumerator.Current;
						stream26_0.WriteByteArray(@class.vmethod_8());
					}
					goto IL_97;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			stream26_0.WriteInt(0);
			IL_97:
			stream26_0.WriteInt(0);
		}

		public override void vmethod_2(ref int int_2)
		{
			int_2 += 20;
		}
	}
}
