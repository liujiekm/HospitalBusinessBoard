//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 操作XML文件的工具类
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/20 10:46:28
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HBB.Common
{
    public static class XMLOperation<T> where T :class
    {
        /// <summary>
        /// 写入XML文件
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="fileUrl">文件地址</param>
        public static void WriteToXML(T obj,String fileUrl)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            //using (FileStream file = File.OpenWrite(fileUrl))
            //{
            //    writer.Serialize(file, obj);
            //}


            using (StringWriter sww = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(sww))
            {
                xmlSerializer.Serialize(writer, obj);
                var xml = sww.ToString();

                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(xml);
                xdoc.Save(fileUrl);
            }
        }



        public static T ReadFromXML(String fileUrl)
        {
            XmlSerializer reader = new XmlSerializer(typeof(T));
            using (FileStream input = File.OpenRead(fileUrl))
            {
                return reader.Deserialize(input) as T;
            }

        }
    }
}
