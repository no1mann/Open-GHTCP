using ns16;
using ns21;
using System;

namespace ns18
{
	public class AsciiRootNode : zzUnkNode260
	{
		public AsciiRootNode()
		{
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 0;
		}

		public string method_7()
		{
			if (base.Nodes.Count != 0)
			{
				return ((AsciiValueNode)base.FirstNode).string_0;
			}
			return null;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.ReadInt();
			this.int_1 = stream26_0.ReadInt();
			int num = stream26_0.ReadInt();
			stream26_0.ReadInt();
			if (num != 0)
			{
				base.Nodes.Add(new AsciiValueNode(stream26_0.ReadAsciiStringAt(num)));
				stream26_0.Position += (long)AbstractTreeNode1.smethod_0(stream26_0.Position);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
            array[1] = (this.vmethod_7() ? (byte)32 : (byte)4);
			array[2] = 3;
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteInt(this.int_0);
			stream26_0.WriteInt(this.int_1);
			if (base.Nodes.Count != 0)
			{
				stream26_0.WriteInt((int)stream26_0.Position + 8);
				stream26_0.WriteInt(0);
				stream26_0.WriteString(this.method_7());
				stream26_0.WriteByte2(0);
				stream26_0.WriteNBytes(0, AbstractTreeNode1.smethod_0(stream26_0.Position));
				return;
			}
			stream26_0.WriteNBytes(0, 8);
		}

		public override string GetNodeText()
		{
			return "Ascii Root";
		}

		public override void vmethod_2(ref int int_2)
		{
			int_2 += 20;
			if (base.Nodes.Count != 0)
			{
				((AsciiValueNode)base.Nodes[0]).vmethod_2(ref int_2);
				int_2++;
				int_2 += AbstractTreeNode1.smethod_0((long)int_2);
			}
		}
	}
}
