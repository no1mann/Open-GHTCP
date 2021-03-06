using System;
using System.Security.Cryptography;

namespace ns14
{
	public class Class210 : Class209, IDisposable, ICryptoTransform
	{
		public int InputBlockSize
		{
			get
			{
				return 1;
			}
		}

		public int OutputBlockSize
		{
			get
			{
				return 1;
			}
		}

		public bool CanTransformMultipleBlocks
		{
			get
			{
				return true;
			}
		}

		public bool CanReuseTransform
		{
			get
			{
				return true;
			}
		}

		public Class210(byte[] byte_0)
		{
			base.method_1(byte_0);
		}

		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			byte[] array = new byte[inputCount];
			this.TransformBlock(inputBuffer, inputOffset, inputCount, array, 0);
			return array;
		}

		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			for (int i = inputOffset; i < inputOffset + inputCount; i++)
			{
				byte byte_ = inputBuffer[i];
                outputBuffer[outputOffset++] = (byte)(inputBuffer[i] ^ base.method_0());
				base.method_2(byte_);
			}
			return inputCount;
		}

		public void Dispose()
		{
			base.method_3();
		}
	}
}
