using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HBB.Common
{
    public class MD5Hashing
    {
        public static String CreateMD5(Encoding encode, String content)
        {
            byte[] source = MD5.Create().ComputeHash(encode.GetBytes(content));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                stringBuilder.Append(source[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
