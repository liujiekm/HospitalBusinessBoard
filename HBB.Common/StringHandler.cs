using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.Common
{
    public class StringHandler
    {
        /// <summary>
        /// 根据double字符串获取设定精度的double 直接截取 不四舍五入
        /// </summary>
        /// <returns></returns>
        public static double GetDoubleByString(String content, Int32 accuracy=0)
        {
            if(content.Contains("."))
            {

                var num = content.Substring(0, content.IndexOf('.') + accuracy+1);
                return Double.Parse(num);

            }
            else
            {
                return Double.Parse(content);
            }
            
        }
    }
}
