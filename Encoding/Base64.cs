using System;
using System.Collections.Generic;
using System.Text;

namespace Xevle.Data.Encoding
{
	public static class Base64
	{
		public static string EncodeString(string input)
		{
			byte[] data = System.Text.UnicodeEncoding.UTF8.GetBytes(input);
			Base64Encoder myEncoder = new Base64Encoder(data);

			StringBuilder sb = new StringBuilder();
			sb.Append(myEncoder.GetEncoded());
			return sb.ToString();
		}

		public static char[] Encode(string input)
		{
			byte[] data = System.Text.UnicodeEncoding.UTF8.GetBytes(input);
			Base64Encoder myEncoder = new Base64Encoder(data);
			return myEncoder.GetEncoded();
		}

		public static string Encode(byte[] input)
		{
			Base64Encoder myEncoder = new Base64Encoder(input);
			StringBuilder sb = new StringBuilder();
			sb.Append(myEncoder.GetEncoded());
			return sb.ToString();
		}

		public static string DecodeString(string input)
		{
			char[] data = input.ToCharArray();
			Base64Decoder myDecoder = new Base64Decoder(data);
			StringBuilder sb = new StringBuilder();

			byte[] temp = myDecoder.GetDecoded();
			sb.Append(System.Text.UTF8Encoding.UTF8.GetChars(temp));

			return sb.ToString();
		}

		public static byte[] Decode(string input)
		{
			char[] data = input.ToCharArray();
			Base64Decoder myDecoder = new Base64Decoder(data);
			byte[] temp = myDecoder.GetDecoded();
			return temp;
		}
	}
}
