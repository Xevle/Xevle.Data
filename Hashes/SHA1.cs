using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Xevle.Data.Hashes
{
	public static partial class Hash
	{
		public static class SHA1
		{
			public static string HashString(string HashString)
			{
				SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                    
				byte[] arrayData;
				byte[] arrayResult;
				string result = null;
				string temp = null;
                    
				arrayData = System.Text.Encoding.UTF8.GetBytes(HashString);
				arrayResult = sha1.ComputeHash(arrayData);

				for (int i = 0; i < arrayResult.Length; i++)
				{
					temp = Convert.ToString(arrayResult[i], 16);
					if (temp.Length == 1) temp = "0" + temp;
					result += temp;
				}

				return result;
			}

			public static string HashFile(string filename)
			{
				SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
               
				FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
				BinaryReader br = new BinaryReader(fs);

				byte[] textToHash = br.ReadBytes((int)fs.Length);
				br.Close();
				byte[] arrayResult = sha1.ComputeHash(textToHash);

				string result = null;
				string temp = null;

				for (int i = 0; i < arrayResult.Length; i++)
				{
					temp = Convert.ToString(arrayResult[i], 16);
					if (temp.Length == 1) temp = "0" + temp;
					result += temp;
				}

				return result;
			}
		}
	}
}
