﻿//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// MD5帮助类
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================

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
