using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;

namespace HBB.DataService.Fake
{
    public class DoctorRegisterServiceFake:IDoctorRegisterService
    {
        public List<DoctorRegisterMainInformaton> GetDoctorRegisterMainInformaton(string time)
        {
            List<DoctorRegisterMainInformaton> list_model = new List<DoctorRegisterMainInformaton>();
            #region 测试数据
            string[] TimeSpan = {  "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19","20","21","22","23" ,"24"};
            int[] RegisteredDoctorQuanty = { 2, 82, 244, 290, 387, 439, 462, 577, 648, 703, 748, 762, 770, 777, 777, 777, 777, 777,777, 777};
            int hour = DateTime.Now.Hour;
            for (int i = 0; i < hour-5; i++)
            {
                DoctorRegisterMainInformaton modelTemp = new DoctorRegisterMainInformaton();
                modelTemp.TimeSpan = TimeSpan[i];
                modelTemp.RegisteredDoctorQuanty = RegisteredDoctorQuanty[i];
                list_model.Add(modelTemp);
            }


            return list_model;

            #endregion
        }

        public List<DoctorRegisterDetailInformaton> GetDoctorRegisterDetailInformaton(string timePoint)
        {
            List<DoctorRegisterDetailInformaton> list_model = new List<DoctorRegisterDetailInformaton>();
            int hour =Convert.ToInt32(timePoint);
            string DoctorName ="DoctorName";
            string UserID="UserID";
            string RegisterTime="RegisterTime";
            string Specialist="Specialist";


            #region 数据

            //6点
            string[] DoctorName6 = { "曾博", "周素梅"};
            string[] UserID6 = { "5749", "5481", "8954" };
            string[] RegisterTime6 = { "06:30:58", "06:38:36"};
            string[] Specialist6 = { "神经外科", "肿瘤科"};

           #region MyRegion
            //7点
		 string[] DoctorName7 = { "张 怀 勤", "卢中秋" ,"崔 丽 丽","黄 晓 颖","陈 民 新","吴 康 为","林 贤 凡","林 贤 凡","高 志 杰","黄 智 铭","林 春 景","陈 朝 生","黄 朝 兴","许 菲 菲","陈 天 新","陈 天 新","石大伟","闫 竞 一","闫 竞 一","韩 少 良","韩 少 良","姚 建 高","张    翔","谢 德 耀","张 方 毅","张 方 毅","蔡  健"};
            string[] UserID7 = { "5370", "1963", "7849" ,"7174", "5481", "5323" ,"5387", "9798", "9798" ,"5377" ,"5324", "9389", "5432" ,"5433" ,"5382", "5089", "5089" ,"99999992" ,"8236", "5545", "5545" ,"5539" ,"9515", "5555", "5548" ,"5548" ,"5510"};
           
            string[] RegisterTime7 = { "07:00:58", "07:01:11","07:01:23", "07:02:39", "07:05:00", "07:15:20", "07:15:21", "07:15:21", "07:17:24", "07:17:43", "07:18:43", "07:18:55", "07:20:22", "07:20:43", "07:22:58", "07:23:33", "07:26:26", "07:28:38", "07:31:22", "07:32:30", "07:35:45", "07:35:37", "07:43:47", "07:45:57", "07:47:58", "07:50:30", "07:50:47", "07:50:48", "07:52:13", "07:53:23" };
 
	#region
            /*
{"DoctorName":"王玲","UserID":"23800","RegisterTime":"07:26:21","Specialist":"核医学"},{"DoctorName":"王玲","UserID":"23800","RegisterTime":"07:26:34","Specialist":"核医学"},{"DoctorName":"曾  博","UserID":"5749","RegisterTime":"07:26:46","Specialist":"神经外科"},{"DoctorName":"王玲","UserID":"23800","RegisterTime":"07:26:52","Specialist":"核医学"},{"DoctorName":"王玲","UserID":"23800","RegisterTime":"07:27:20","Specialist":"核医学"},{"DoctorName":"吴 春 雷","UserID":"5425","RegisterTime":"07:27:58","Specialist":"伤骨科"},{"DoctorName":"吴 云 刚","UserID":"5498","RegisterTime":"07:28:32","Specialist":"伤骨科"},{"DoctorName":"吴 春 雷","UserID":"5425","RegisterTime":"07:28:41","Specialist":"伤骨科"},{"DoctorName":"陈 民 新","UserID":"5323","RegisterTime":"07:31:09","Specialist":"消化内一科"},{"DoctorName":"吴 春 雷","UserID":"5425","RegisterTime":"07:31:48","Specialist":"伤骨科"},{"DoctorName":"陈 民 新","UserID":"5323","RegisterTime":"07:31:51","Specialist":"消化内一科"},{"DoctorName":"张 怀 勤","UserID":"5370","RegisterTime":"07:34:01","Specialist":"心血管内科"},{"DoctorName":"叶 进 燕","UserID":"5108","RegisterTime":"07:34:13","Specialist":"呼吸内科"},{"DoctorName":"叶 进 燕","UserID":"5108","RegisterTime":"07:34:28","Specialist":"呼吸内科"},{"DoctorName":"陈 民 新","UserID":"5323","RegisterTime":"07:34:34","Specialist":"消化内一科"},{"DoctorName":"单 泽 松","UserID":"5346","RegisterTime":"07:34:48","Specialist":"中医科"},{"DoctorName":"单 泽 松","UserID":"5346","RegisterTime":"07:35:16","Specialist":"中医科"},{"DoctorName":"曾 林 钗","UserID":"8951","RegisterTime":"07:35:24","Specialist":"妇科"},{"DoctorName":"曾 林 钗","UserID":"8951","RegisterTime":"07:35:33","Specialist":"妇科"},{"DoctorName":"王 汉 旻","UserID":"2377","RegisterTime":"07:35:35","Specialist":"神经内科(二)"},{"DoctorName":"王 汉 旻","UserID":"2377","RegisterTime":"07:35:43","Specialist":"神经内科(二)"},{"DoctorName":"单 泽 松","UserID":"5346","RegisterTime":"07:35:44","Specialist":"中医科"},{"DoctorName":"谢 聪 颖","UserID":"6169","RegisterTime":"07:36:40","Specialist":"放化疗科"},{"DoctorName":"王 汉 旻","UserID":"2377","RegisterTime":"07:36:41","Specialist":"神经内科(二)"},{"DoctorName":"叶  人","UserID":"5342","RegisterTime":"07:36:46","Specialist":"中医科"},{"DoctorName":"蔡 剑 峰","UserID":"5298","RegisterTime":"07:37:23","Specialist":"皮肤科"},{"DoctorName":"单 泽 松","UserID":"5346","RegisterTime":"07:37:42","Specialist":"中医科"},{"DoctorName":"宋 华 羽","UserID":"5451","RegisterTime":"07:37:57","Specialist":"肛肠外科"},{"DoctorName":"宋 华 羽","UserID":"5451","RegisterTime":"07:38:10","Specialist":"肛肠外科"},{"DoctorName":"徐 建 国","UserID":"2076","RegisterTime":"07:38:13","Specialist":"眼科"},{"DoctorName":"单 泽 松","UserID":"5346","RegisterTime":"07:38:23","Specialist":"中医科"},{"DoctorName":"池 美 珠","UserID":"5993","RegisterTime":"07:38:23","Specialist":"儿科"},{"DoctorName":"徐 建 国","UserID":"2076","RegisterTime":"07:38:28","Specialist":"眼科"},{"DoctorName":"曾 林 钗","UserID":"8951","RegisterTime":"07:38:30","Specialist":"妇科"},{"DoctorName":"王 汉 旻","UserID":"2377","RegisterTime":"07:38:40","Specialist":"神经内科(二)"},{"DoctorName":"胡  滨","UserID":"5392","RegisterTime":"07:39:14","Specialist":"消化内二科"},{"DoctorName":"宋 华 羽","UserID":"5451","RegisterTime":"07:39:28","Specialist":"肛肠外科"},{"DoctorName":"单 泽 松","UserID":"5346","RegisterTime":"07:40:00","Specialist":"中医科"},{"DoctorName":"宋 华 羽","UserID":"5451","RegisterTime":"07:40:08","Specialist":"肛肠外科"},{"DoctorName":"徐 建 国","UserID":"2076","RegisterTime":"07:40:10","Specialist":"眼科"},{"DoctorName":"陈 天 新","UserID":"5089","RegisterTime":"07:40:51","Specialist":"肾内科"},{"DoctorName":"徐 建 国","UserID":"2076","RegisterTime":"07:40:57","Specialist":"眼科"},{"DoctorName":"宋 华 羽","UserID":"5451","RegisterTime":"07:41:29","Specialist":"肛肠外科"},{"DoctorName":"曾 林 钗","UserID":"8951","RegisterTime":"07:41:40","Specialist":"妇科"},{"DoctorName":"单 泽 松","UserID":"5346","RegisterTime":"07:41:51","Specialist":"中医科"},{"DoctorName":"谢 德 耀","UserID":"5555","RegisterTime":"07:41:55","Specialist":"胸外科"},{"DoctorName":"宋 华 羽","UserID":"5451","RegisterTime":"07:42:07","Specialist":"肛肠外科"},{"DoctorName":"方 渭 清","UserID":"5189","RegisterTime":"07:42:25","Specialist":"耳鼻喉科"},{"DoctorName":"方 渭 清","UserID":"5189","RegisterTime":"07:42:36","Specialist":"耳鼻喉科"},{"DoctorName":"韩    艳","UserID":"9314","RegisterTime":"07:43:04","Specialist":"伤骨科"},{"DoctorName":"单 泽 松","UserID":"5346","RegisterTime":"07:43:12","Specialist":"中医科"},{"DoctorName":"王 汉 旻","UserID":"2377","RegisterTime":"07:43:14","Specialist":"神经内科(二)"},{"DoctorName":"王 汉 旻","UserID":"2377","RegisterTime":"07:43:25","Specialist":"神经内科(二)"},{"DoctorName":"徐 建 国","UserID":"2076","RegisterTime":"07:43:30","Specialist":"眼科"},{"DoctorName":"施 红 旗","UserID":"5536","RegisterTime":"07:43:56","Specialist":"肝胆外科"},{"DoctorName":"韩    艳","UserID":"9314","RegisterTime":"07:44:38","Specialist":"伤骨科"},{"DoctorName":"方 渭 清","UserID":"5189","RegisterTime":"07:44:42","Specialist":"耳鼻喉科"},{"DoctorName":"王 汉 旻","UserID":"2377","RegisterTime":"07:44:45","Specialist":"神经内科(二)"},{"DoctorName":"韩    艳","UserID":"9314","RegisterTime":"07:44:52","Specialist":"伤骨科"},{"DoctorName":"方 克 娅","UserID":"5490","RegisterTime":"07:44:59","Specialist":"眼科"},{"DoctorName":"王 汉 旻","UserID":"2377","RegisterTime":"07:45:09","Specialist":"神经内科(二)"},{"DoctorName":"方 克 娅","UserID":"5490","RegisterTime":"07:45:11","Specialist":"眼科"},{"DoctorName":"韩    艳","UserID":"9314","RegisterTime":"07:45:15","Specialist":"伤骨科"},{"DoctorName":"韩    艳","UserID":"9314","RegisterTime":"07:45:29","Specialist":"伤骨科"},{"DoctorName":"徐 建 国","UserID":"2076","RegisterTime":"07:45:44","Specialist":"眼科"},{"DoctorName":"王 汉 旻","UserID":"2377","RegisterTime":"07:45:50","Specialist":"神经内科(二)"},{"DoctorName":"郎  玮","UserID":"5340","RegisterTime":"07:46:44","Specialist":"中医科"},{"DoctorName":"徐 建 国","UserID":"2076","RegisterTime":"07:46:47","Specialist":"眼科"},{"DoctorName":"方 克 娅","UserID":"5490","RegisterTime":"07:47:02","Specialist":"眼科"},{"DoctorName":"吴 金 明","UserID":"5608","RegisterTime":"07:47:03","Specialist":"消化内一科"},{"DoctorName":"韩    艳","UserID":"9314","RegisterTime":"07:47:25","Specialist":"伤骨科"},{"DoctorName":"方 渭 清","UserID":"5189","RegisterTime":"07:47:37","Specialist":"耳鼻喉科"},{"DoctorName":"郎  玮","UserID":"5340","RegisterTime":"07:47:44","Specialist":"中医科"},{"DoctorName":"方 渭 清","UserID":"5189","RegisterTime":"07:47:46","Specialist":"耳鼻喉科"},{"DoctorName":"韩    艳","UserID":"9314","RegisterTime":"07:48:03","Specialist":"伤骨科"},{"DoctorName":"郑  宇","UserID":"5682","RegisterTime":"07:48:14","Specialist":"感染科"},{"DoctorName":"方 渭 清","UserID":"5189","RegisterTime":"07:48:21","Specialist":"耳鼻喉科"},{"DoctorName":"单 泽 松","UserID":"5346","RegisterTime":"07:48:23","Specialist":"中医科"},{"DoctorName":"方 克 娅","UserID":"5490","RegisterTime":"07:48:29","Specialist":"眼科"},{"DoctorName":"单 泽 松","UserID":"5346","RegisterTime":"07:48:33","Specialist":"中医科"},{"DoctorName":"陈 民 新","UserID":"5323","RegisterTime":"07:48:42","Specialist":"消化内一科"},{"DoctorName":"张  旭","UserID":"5830","RegisterTime":"07:48:44","Specialist":"神经内科(二)"},{"DoctorName":"陈 建 福","UserID":"4769","RegisterTime":"07:48:50","Specialist":"耳鼻喉科"},{"DoctorName":"倪 小 芬","UserID":"7573","RegisterTime":"07:48:54","Specialist":"中医科"},{"DoctorName":"徐 建 国","UserID":"2076","RegisterTime":"07:49:00","Specialist":"眼科"},{"DoctorName":"韩    艳","UserID":"9314","RegisterTime":"07:49:00","Specialist":"伤骨科"},{"DoctorName":"方 渭 清","UserID":"5189","RegisterTime":"07:49:06","Specialist":"耳鼻喉科"},{"DoctorName":"陈 建 福","UserID":"4769","RegisterTime":"07:49:12","Specialist":"耳鼻喉科"},{"DoctorName":"卢中秋","UserID":"1963","RegisterTime":"07:49:21","Specialist":"心血管内科"},{"DoctorName":"王 邦 松","UserID":"5395","RegisterTime":"07:49:27","Specialist":"感染科"},{"DoctorName":"方 渭 清","UserID":"5189","RegisterTime":"07:49:32","Specialist":"耳鼻喉科"},{"DoctorName":"单 泽 松","UserID":"5346","RegisterTime":"07:49:49","Specialist":"中医科"},{"DoctorName":"徐 建 国","UserID":"2076","RegisterTime":"07:49:49","Specialist":"眼科"},{"DoctorName":"方 渭 清","UserID":"5189","RegisterTime":"07:49:54","Specialist":"耳鼻喉科"},{"DoctorName":"黄 督 平","UserID":"9546","RegisterTime":"07:49:55","Specialist":"肿瘤科"},{"DoctorName":"沈 飞 霞","UserID":"2025","RegisterTime":"07:49:55","Specialist":"内分泌科"},{"DoctorName":"单 泽 松","UserID":"5346","RegisterTime":"07:50:08","Specialist":"中医科"},{"DoctorName":"沈 飞 霞","UserID":"2025","RegisterTime":"07:50:10","Specialist":"内分泌科"},{"DoctorName":"郎  玮","UserID":"5340","RegisterTime":"07:50:11","Specialist":"中医科"},{"DoctorName":"张 学 奇","UserID":"6184","RegisterTime":"07:50:15","Specialist":"皮肤
             

             * */
#endregion
            //8点
            #region 232
            string[] DoctorName8 = { "吴 春 雷", "陈 少 贤", "陈 民 新", "张 劲 军", "王 汉 旻", "张    挺", "陈 哲 京", "林 贤 凡", "杜 晓 红", "叶 天 申", "林 春 景", "苏  刚", "林  芝", "邵 笑 红", "赵 军 招", "赵 军 招", "郭 晗 峰", "林源绍", "洪 承 吕", "郭 晗 峰", "刘毅", "陈 志 文", "李 秉 煦", "徐 云 升", "谢 泳 泳", "潘盛盛", "杜 晓 红" };
            string[] UserID8 = { "5370", "1963", "7849", "7174", "5481", "5323", "5387", "9798", "9798", "5377", "5324", "9389", "5432", "5433", "5382", "5089", "5089", "99999992", "8236", "5545", "5545", "5539", "9515", "5555", "5548", "5548", "5510" };

            string[] RegisterTime8 = { "08:00:58", "08:01:11", "08:01:23", "08:02:39", "08:05:00", "08:15:20", "08:15:21", "08:15:21", "08:17:24", "08:17:43", "08:18:43", "08:18:55", "08:20:22", "08:20:43", "08:22:58", "08:23:33", "08:26:26", "08:28:38", "08:31:22", "08:32:30", "08:35:45", "08:35:37", "08:43:47", "08:45:57", "08:47:58", "08:50:30", "08:50:47", "08:50:48", "08:52:13", "08:53:23" };
            //9点
            string[] DoctorName9 = { "赵 军 招", "吴 康 为", "王    贞", "谢 泳 泳", "赵 军 招", "王 汉 旻", "董 若 琳", "韩 少 良", "陈 建 福", "陈 少 贤", "王 维 千", "王    贞", "杜 晓 红", "林 贤 凡", "杜 晓 红" };
            string[] UserID9 = { "5370", "1963", "7849", "7174", "5481", "5323", "5387", "9798", "9798", "5377", "5324", "9389", "5432", "5433", "5382", "5089", "5089", "99999992", "8236", "5545", "5545", "5539", "9515", "5555", "5548", "5548", "5510" };
            string[] RegisterTime9 = { "09:00:58", "09:01:11", "09:01:23", "09:02:39", "09:05:00", "09:15:20", "09:15:21", "09:15:21", "09:17:24", "09:17:43", "09:18:43", "09:18:55", "09:20:22", "09:20:43", "09:22:58", "09:23:33", "09:26:26", "09:28:38", "09:31:22", "09:32:30", "09:35:45", "09:35:37", "09:43:47", "09:45:57", "09:47:58", "09:50:30", "09:50:47", "09:50:48", "09:52:13", "09:53:23" };
            //10点
            string[] DoctorName10 = { "王    贞", "杜 晓 红", "林 贤 凡", "赵 军 招", "王 汉 旻", "董 若 琳", "韩 少 良", "陈 建 福", "陈 少 贤", "王 维 千", "杜 晓 红", };
            string[] UserID10 = { "5370", "1963", "7849", "7174", "5481", "5323", "5387", "9798", "9798", "5377", "5324", "9389", "5432", "5433", "5382", "5089", "5089", "99999992", "8236", "5545", "5545", "5539", "9515", "5555", "5548", "5548", "5510" };
            string[] RegisterTime10 = { "10:00:58", "10:01:11", "10:01:23", "10:02:39", "10:05:00", "10:15:20", "10:15:21", "10:15:21", "10:17:24", "10:17:43", "10:18:43", "10:18:55", "10:20:22", "10:20:43", "10:22:58" };

            //11点
            string[] DoctorName11 = { "王 汉 旻", "张    挺", "陈 哲 京", "林 贤 凡", "杜 晓 红", "叶 天 申", "林 春 景", "苏  刚", "林  芝", "邵 笑 红", "赵 军 招", "赵 军 招", "郭 晗 峰", "林源绍", "洪 承 吕", "郭 晗 峰", "刘毅", "陈 志 文", "李 秉 煦" };
            string[] UserID11 = { "5370", "1963", "7849", "7174", "5481", "5323", "5387", "9798", "9798", "5377", "5324", "9389", "5432", "5433", "5382", "5089", "5089", "99999992", "8236", "5545", "5545", "5539", "9515", "5555", "5548", "5548", "5510", "5548", "5548", "5510" };
            string[] RegisterTime11 = { "11:00:58", "11:01:11", "11:01:23", "11:02:39", "11:05:00", "11:15:20", "11:15:21", "11:15:21", "11:17:24", "11:17:43", "11:18:43", "11:18:55", "11:20:22", "11:20:43", "11:22:58" ,"11:33:55", "11:34:22", "11:35:43", "11:36:58" };
            //12点
            string[] DoctorName12 = { "赵 军 招", "王 汉 旻", "董 若 琳", "韩 少 良", "陈 建 福", "陈 少 贤", "王 维 千", "杜 晓 红", };
            string[] UserID12 = { "5370", "1963", "7849", "7174", "5481", "5323", "5387", "9798", "9798", "5377", "5324", "9389", "5432", "5433", "5382", "5089", "5089", "99999992", "8236", "5545", "5545", "5539", "9515", "5555", "5548", "5548", "5510" };
            string[] RegisterTime12 = { "12:00:58", "12:01:11", "12:01:23", "12:02:39", "12:05:00", "12:15:20", "12:15:21", "12:15:21", "12:17:24", "12:17:43", "12:18:43", "12:18:55", "12:20:22", "12:20:43", "12:22:58" }; 
            #endregion
            //13点
            string[] DoctorName13 = {"张 劲 军","王 汉 旻","张    挺","陈 哲 京","林 贤 凡","杜 晓 红","叶 天 申","林 春 景","苏  刚","林  芝","邵 笑 红","赵 军 招","赵 军 招","郭 晗 峰","林源绍","洪 承 吕","郭 晗 峰","刘毅","陈 志 文" };
            string[] UserID13 = { "5370", "1963", "7849", "7174", "5481", "5323", "5387", "9798", "9798", "5377", "5324", "9389", "5432", "5433", "5382", "5089", "5089", "99999992", "8236", "5545", "5545", "5539", "9515", "5555", "5548", "5548", "5510", "5555", "5548", "5548", "5510" };
            string[] RegisterTime13 = { "13:00:58", "13:01:11", "13:01:23", "13:02:39", "13:05:00", "13:15:20", "13:15:21", "13:15:21", "13:17:24", "13:17:43", "13:18:43", "13:18:55", "13:20:22", "13:20:43", "13:22:58", "13:33:55", "13:36:22", "13:37:43", "13:38:58" };
            //14点
            string[] DoctorName14 = { "徐 建 国", "杜 晓 红", "林 贤 凡", "赵 军 招", "王 汉 旻", "董 若 琳", "韩 少 良", "陈 建 福", "陈 少 贤", "王 维 千", "杜 晓 红", };
            string[] UserID14 = { "5370", "1963", "7849", "7174", "5481", "5323", "5387", "9798", "9798", "5377", "5324", "9389", "5432", "5433", "5382", "5089", "5089", "99999992", "8236", "5545", "5545", "5539", "9515", "5555", "5548", "5548", "5510" };
            string[] RegisterTime14 = { "14:00:58", "14:01:11", "14:01:23", "14:02:39", "14:05:00", "14:15:20", "14:15:21", "14:15:21", "14:17:24", "14:17:43", "14:18:43", "14:18:55", "14:20:22", "14:20:43", "14:22:58" };
            //15点
            string[] DoctorName15 = { "张 金 华", "董 若 琳", "韩 少 良", "陈 建 福", "陈 少 贤", "张  悦", "林 贤 凡", "赵 军 招", "王 汉 旻", "王 维 千", "杜 晓 红", };
            string[] UserID15 = { "5370", "1963", "7849", "7174", "5481", "5323", "5387", "9798", "9798", "5377", "5324", "9389", "5432", "5433", "5382", "5089", "5089", "99999992", "8236", "5545", "5545", "5539", "9515", "5555", "5548", "5548", "5510" };
            string[] RegisterTime15 = { "15:00:58", "15:01:11", "15:01:23", "15:02:39", "15:05:00", "15:15:20", "15:15:21", "15:15:21", "15:17:24", "15:17:43", "15:18:43", "15:18:55", "15:20:22", "15:20:43", "15:22:58" };
            //16点
            string[] DoctorName16 = {"赵 军 招", "王 汉 旻", "董 若 琳", "韩 少 良", "陈 建 福", "陈 少 贤", "王 维 千", "杜 晓 红", };
            string[] UserID16 = { "5370", "1963", "7849", "7174", "5481", "5323", "5387", "9798", "9798", "5377", "5324", "9389", "5432", "5433", "5382", "5089", "5089", "99999992", "8236", "5545", "5545", "5539", "9515", "5555", "5548", "5548", "5510" };
            string[] RegisterTime16 = { "16:00:58", "16:01:11", "16:01:23", "16:02:39", "16:05:00", "16:15:20", "16:15:21", "16:15:21", "16:17:24", "16:17:43", "16:18:43", "16:18:55", "16:20:22", "16:20:43", "16:22:58" };
            //17点
            string[] DoctorName17 = { "林 贤 凡", "赵 军 招", "王 汉 旻", "董 若 琳", "韩 少 良", "王    贞", "杜 晓 红", "陈 建 福", "陈 少 贤", "王 维 千", "杜 晓 红", };
            string[] UserID17 = { "5370", "1963", "7849", "7174", "5481", "5323", "5387", "9798", "9798", "5377", "5324", "9389", "5432", "5433", "5382", "5089", "5089", "99999992", "8236", "5545", "5545", "5539", "9515", "5555", "5548", "5548", "5510" };
            string[] RegisterTime17 = { "17:00:58", "17:01:11", "17:01:23", "17:02:39", "17:05:00", "17:15:20", "17:15:21", "17:15:21", "17:17:24", "17:17:43", "17:18:43", "17:18:55", "17:20:22", "17:20:43", "17:22:58" };
            //18点
            string[] DoctorName18 = { "沈 飞 霞", "杜 晓 红", "林 贤 凡", "赵 军 招", "王 汉 旻", "董 若 琳", "韩 少 良", "陈 建 福", "陈 少 贤", "王 维 千", "杜 晓 红", };
            string[] UserID18 = { "5370", "1963", "7849", "7174", "5481", "5323", "5387", "9798", "9798", "5377", "5324", "9389", "5432", "5433", "5382", "5089", "5089", "99999992", "8236", "5545", "5545", "5539", "9515", "5555", "5548", "5548", "5510" };
            string[] RegisterTime18 = { "18:00:58", "18:01:11", "18:01:23", "18:02:39", "18:05:00", "18:15:20", "18:15:21", "18:15:21", "18:17:24", "18:17:43", "18:18:43", "18:18:55", "18:20:22", "18:20:43", "18:22:58" };
     
            #endregion
            string[] DoctorNameTemp = null;
            string[] UserIDTemp = null;
            string[] RegisterTimeTemp = null;
           // string[] SpecialistTemp = null;


            switch (hour)
            {
                case 6:
                    DoctorNameTemp = DoctorName6;
                    UserIDTemp = UserID6;
                    RegisterTimeTemp = RegisterTime6;
                    break;
                case 7:
                    DoctorNameTemp = DoctorName7;
                    UserIDTemp = UserID7;
                    RegisterTimeTemp = RegisterTime7;
                    break;
                case 8:
                    DoctorNameTemp = DoctorName8;
                    UserIDTemp = UserID8;
                    RegisterTimeTemp = RegisterTime8;
                    break;
                case 9:
                    DoctorNameTemp = DoctorName9;
                    UserIDTemp = UserID9;
                    RegisterTimeTemp = RegisterTime9;
                    break;
                case 10:
                    DoctorNameTemp = DoctorName10;
                    UserIDTemp = UserID10;
                    RegisterTimeTemp = RegisterTime10;
                    break;
                case 11:
                    DoctorNameTemp = DoctorName11;
                    UserIDTemp = UserID11;
                    RegisterTimeTemp = RegisterTime11;
                    break;
                case 12:
                    DoctorNameTemp = DoctorName12;
                    UserIDTemp = UserID12;
                    RegisterTimeTemp = RegisterTime12;
                    break;
                case 13:
                    DoctorNameTemp = DoctorName13;
                    UserIDTemp = UserID13;
                    RegisterTimeTemp = RegisterTime13;
                    break;
                case 14:
                    DoctorNameTemp = DoctorName14;
                    UserIDTemp = UserID14;
                    RegisterTimeTemp = RegisterTime14;
                    break;
                case 15:
                    DoctorNameTemp = DoctorName15;
                    UserIDTemp = UserID15;
                    RegisterTimeTemp = RegisterTime15;
                    break;
                case 16:
                    DoctorNameTemp = DoctorName16;
                    UserIDTemp = UserID16;
                    RegisterTimeTemp = RegisterTime16;
                    break;
                case 17:
                    DoctorNameTemp = DoctorName17;
                    UserIDTemp = UserID17;
                    RegisterTimeTemp = RegisterTime17;
                    break;
                case 18:
                    DoctorNameTemp = DoctorName18;
                    UserIDTemp = UserID18;
                    RegisterTimeTemp = RegisterTime18;
                    break;
                default:
                    DoctorNameTemp = DoctorName18;
                    UserIDTemp = UserID18;
                    RegisterTimeTemp = RegisterTime18;
                    break;
            }

            for (int i = 0; i < DoctorNameTemp.Count(); i++)
                {
                    DoctorRegisterDetailInformaton modelTemp = new DoctorRegisterDetailInformaton();
                    modelTemp.DoctorName = DoctorNameTemp[i];
                    modelTemp.UserID = UserIDTemp[i];
                    modelTemp.RegisterTime = RegisterTimeTemp[i];
                    list_model.Add(modelTemp);
                }
                return list_model;
                #region 测试数据2

                //string[] DoctorName = { "林建国", "张三丰", "马俊", "蒋璐婷", "郝海波", "琳琳" };
                //string[] UserID = { "1111", "1112", "1113", "1114", "1115", "1116" };
                //string[] RegisterTime = { "06:53:26", "06:55:20", "06:57:26", "07:00:26", "07:06:56", "07:57:25" };
                //string[] Specialist = { "消化内一科", "消化内一科", "内分泌科", "内分泌科", "内分泌科", "内分泌科" };
        

                #endregion
           }
        
            #endregion
            
        public List<DoctorRegisterDetailInformaton> GetDoctorUnRegisterDetailInformaton(string timePoint)
        {
            string[] DoctorName = { "陈晓军", "赵作虎", "潘立人", "杨一凡", "曾博", "周素梅", "曾小", "周一凡", "陈晓军", "赵作虎", "潘立人", "杨一凡", "曾博", "周素梅", "曾小", "周一凡", "陈晓军", "赵作虎", "潘立人", "杨一凡", "曾博", "周素梅", "曾小", "周一凡" };
            string[] UserID = { "4564", "5623", "6598", "6598", "6532", "6423", "9532", "6473", "4564", "5623", "6598", "6598", "6532", "6423", "9532", "6473", "4564", "5623", "6598", "6598", "6532", "6423", "9532", "6473" };
            string[] RegisterTime = { "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00", "08:00" };
            string[] Specialist = { "骨科", "骨科", "内分泌科", "内分泌科", "内分泌科", "内分泌科", "内分泌科", "内分泌科", "骨科", "骨科", "内分泌科", "内分泌科", "内分泌科", "内分泌科", "内分泌科", "内分泌科", "骨科", "骨科", "内分泌科", "内分泌科", "内分泌科", "内分泌科", "内分泌科", "内分泌科" };
            List<DoctorRegisterDetailInformaton> list_model = new List<DoctorRegisterDetailInformaton>();
            for (int i = 0; i < 24; i++)
            {
                DoctorRegisterDetailInformaton model = new DoctorRegisterDetailInformaton();
                model.DoctorName = DoctorName[i];
                model.UserID = UserID[i];
                model.RegisterTime = RegisterTime[i];
                model.Specialist = Specialist[i];
                list_model.Add(model);
            }
            return list_model;
        }

        public List<DoctorRegisterDetailInformatonForPast> GetDoctorRegisterDetailInformatonForPast(string timeType, string userID)
        {
            List<DoctorRegisterDetailInformatonForPast> list_model = new List<DoctorRegisterDetailInformatonForPast>();
            #region 测试数据1
            DateTime today = DateTime.Now.Date;
            today=today.AddHours(8);
           // string todayStr = today.ToString("yyyy-MM-dd hh:mm:ss");

            int number = int.Parse(userID);
            if (number % 2 == 1)
            {
                for (int i = 6; i > -1; i--)
                {
                    DoctorRegisterDetailInformatonForPast modelTemp = new DoctorRegisterDetailInformatonForPast();
                    if (i % 2 == 1) 
                    { 
                        modelTemp.TimeType = modelTemp.TimeType = "1";
                        modelTemp.ArrangeWorkTime = today.AddDays(-i);
                        modelTemp.RegisterTime = today.AddDays(-i).AddMinutes(-30*i+50);
                    }
                    else if (i % 2 == 0) 
                    { 
                        modelTemp.TimeType = modelTemp.TimeType = "2";
                        modelTemp.ArrangeWorkTime = today.AddDays(-i).AddHours(5).AddMinutes(30);
                        modelTemp.RegisterTime = today.AddDays(-i).AddHours(5).AddMinutes(30).AddMinutes(-10 * i);
                    }
                    else
                    {
                        modelTemp.TimeType = modelTemp.TimeType = "1";
                        modelTemp.ArrangeWorkTime = today.AddDays(-i);
                        modelTemp.RegisterTime = today.AddDays(-i).AddMinutes(-10 * i);
                    }
                    list_model.Add(modelTemp);
                }
                return list_model;
            }
            #endregion

            #region 测试数据2
            else
            {
                for (int i = 7; i > 0; i--)
                {
                    DoctorRegisterDetailInformatonForPast modelTemp = new DoctorRegisterDetailInformatonForPast();
                    if (i % 2 == 1) 
                    { 
                        modelTemp.TimeType = modelTemp.TimeType = "1";
                        modelTemp.ArrangeWorkTime = today.AddDays(-i+1);
                        modelTemp.RegisterTime = today.AddDays(-i+1).AddMinutes(-20+5*i);
                    }
                    else if (i % 2 == 0) 
                    { 
                        modelTemp.TimeType = modelTemp.TimeType = "2";
                        modelTemp.ArrangeWorkTime = today.AddDays(-i+1).AddHours(5).AddMinutes(30);
                        modelTemp.RegisterTime = today.AddDays(-i+1).AddHours(5).AddMinutes(30).AddMinutes(-30-5*i);
                    }
                    else
                    {
                        modelTemp.TimeType = modelTemp.TimeType = "1";
                        modelTemp.ArrangeWorkTime = today.AddDays(-i+1);
                        modelTemp.RegisterTime = today.AddDays(-i+1).AddMinutes(-10 * i);
                    }
                    list_model.Add(modelTemp);
                }
                return list_model;
            }
            #endregion
        }



    }
}
