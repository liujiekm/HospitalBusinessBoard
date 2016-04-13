//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： zhaoheqi
// 创建时间：2015-5-18
// 描述：
//    住院相关的报表数据获取
//===============================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using HBB.ServiceInterface;

namespace HBB.DataService.Fake {
    class BeInHospitalServiceFake : IBeInHospitalService {

        public Hashtable GetEmergencyTreatmentInfo()
        {

            Hashtable hs = new Hashtable();

            // 抢救区病人信息
            hs.Add("qjqxx", new ArrayList() { 
                new Hashtable(){ {"XM","梁美坤"},{"XB","男"},{"NL","79"},{"LGTS","扩张性心肌病，心功能不全；"},{"LCZD","235"},{"YCYE",812.91} },
                new Hashtable(){ {"XM","郭洪浩"},{"XB","男"},{"NL","50"},{"LGTS","头皮肿物；小脑梗塞；"},{"LCZD","235"},{"YCYE",2271.17} },
                new Hashtable(){ {"XM","朱林叶"},{"XB","女"},{"NL","72"},{"LGTS","多发性损伤；"},{"LCZD","235"},{"YCYE",3491.58} },
                new Hashtable(){ {"XM","叶兴顺"},{"XB","男"},{"NL","75"},{"LGTS","脑血管意外；"},{"LCZD","236"},{"YCYE",9526.46} },
                new Hashtable(){ {"XM","朱克金"},{"XB","男"},{"NL","75"},{"LGTS","发热，糖尿病，褥仓"},{"LCZD","234"},{"YCYE",674.61} },
                new Hashtable(){ {"XM","王爱莲"},{"XB","女"},{"NL","63"},{"LGTS","硬膜下出血；"},{"LCZD","235"},{"YCYE",1605} },
                new Hashtable(){ {"XM","翁猷良"},{"XB","男"},{"NL","77"},{"LGTS","复合性溃疡伴出血，慢性肾功能不全，急性冠脉综合症"},{"LCZD","234"},{"YCYE",106.75} },
                new Hashtable(){ {"XM","任黎明"},{"XB","男"},{"NL","43"},{"LGTS","扩张性心肌病；急性冠脉综合症，晕厥"},{"LCZD","234"},{"YCYE",1192.2}},
                new Hashtable(){ {"XM","黄学贞"},{"XB","男"},{"NL","58"},{"LGTS","慢性阻塞性肺病伴急性下呼吸道感染；呼吸衰竭"},{"LCZD","235"},{"YCYE",104.35} },
                new Hashtable(){ {"XM","朱美英"},{"XB","女"},{"NL","63"},{"LGTS","发热待查，糖尿病，肾功能不全，高血压病；"},{"LCZD","234"},{"YCYE",1117.05} },
                new Hashtable(){ {"XM","汝贺"},{"XB","男"},{"NL","44"},{"LGTS","急性冠脉综合征；晕厥；"},{"LCZD","234"},{"YCYE",1826.47} },
                new Hashtable(){ {"XM","章阿钗"},{"XB","女"},{"NL","78"},{"LGTS","心脏起搏器植入术后电池耗竭；心力衰竭；"},{"LCZD","234"},{"YCYE",198.02} },
                new Hashtable(){ {"XM","彭廷宪"},{"XB","男"},{"NL","30"},{"LGTS","车祸伤；"},{"LCZD","235"},{"YCYE",8515.25} },
                new Hashtable(){ {"XM","王国珍"},{"XB","男"},{"NL","40"},{"LGTS","多发性损伤"},{"LCZD","235"},{"YCYE",1803.09} },
                new Hashtable(){ {"XM","李法云"},{"XB","男"},{"NL","53"},{"LGTS","车祸伤；"},{"LCZD","235"},{"YCYE",1281.17} },
                new Hashtable(){ {"XM","夏欣欣"},{"XB","女"},{"NL","88"},{"LGTS","尿毒症"},{"LCZD","234"},{"YCYE",1275.79} },
                new Hashtable(){ {"XM","陈伯夫"},{"XB","男"},{"NL","79"},{"LGTS","贫血；消化道出血；"},{"LCZD","235"},{"YCYE",1650.31} },
            });
            // 留院观察区病人信息
            hs.Add("lgqxx", new ArrayList() { 
                new Hashtable(){ {"XM","蒋妹"},{"XB","女"},{"NL","27"},{"LGTS","多发性损伤；"},{"LCZD","249"},{"YCYE",1876.17} },
                new Hashtable(){ {"XM","谭容梅"},{"XB","女"},{"NL","32"},{"LGTS","开放性胸部损伤；开放性胸部损伤；"},{"LCZD","246"},{"YCYE",287.72} },
                new Hashtable(){ {"XM","方秀兰"},{"XB","女"},{"NL","60"},{"LGTS","急性肾功能不全；下消化道出血；胃K术后伴全身淋巴结肿大压迫右肾；右肾积水；待造瘘血透"},{"LCZD","246"},{"YCYE",8054.37} },
                new Hashtable(){ {"XM","张钢华"},{"XB","男"},{"NL","51"},{"LGTS","多发性损伤；"},{"LCZD","241"},{"YCYE",6529.62}},
                new Hashtable(){ {"XM","倪月娥"},{"XB","女"},{"NL","68"},{"LGTS","下腹痛；心力衰竭；"},{"LCZD","239"},{"YCYE",1501.85} },
                new Hashtable(){ {"XM","王珠平"},{"XB","男"},{"NL","34"},{"LGTS","头皮裂伤；头部外伤；"},{"LCZD","239"},{"YCYE",5088.87} },
                new Hashtable(){ {"XM","王爱妹"},{"XB","女"},{"NL","52"},{"LGTS","肺部感染；肺部肿瘤伴转移；"},{"LCZD","239"},{"YCYE",379.46} },
                new Hashtable(){ {"XM","薛西西"},{"XB","女"},{"NL","34"},{"LGTS","症状性癫痫；"},{"LCZD","238"},{"YCYE",1507.12} },
                new Hashtable(){ {"XM","郑月媚"},{"XB","女"},{"NL","61"},{"LGTS","心功能不全"},{"LCZD","238"},{"YCYE",2331.56} },
                new Hashtable(){ {"XM","潘成光"},{"XB","男"},{"NL","59"},{"LGTS","肝硬化；脑梗死；"},{"LCZD","238"},{"YCYE",169.47} },
                new Hashtable(){ {"XM","王成标"},{"XB","男"},{"NL","44"},{"LGTS","胸椎骨折；车祸伤；"},{"LCZD","238"},{"YCYE",1291.07}},
                new Hashtable(){ {"XM","蓝式妹"},{"XB","女"},{"NL","52"},{"LGTS","慢性肾功能不全；关节炎；"},{"LCZD","238"},{"YCYE",1098.67} },
                new Hashtable(){ {"XM","周月志"},{"XB","男"},{"NL","81"},{"LGTS","冠状动脉粥样硬化性心脏病；"},{"LCZD","238"},{"YCYE",640.96} },
                new Hashtable(){ {"XM","郭月林"},{"XB","男"},{"NL","76"},{"LGTS","喉恶性肿瘤伴转移 粒细胞缺乏"},{"LCZD","238"},{"YCYE",1539.25} },
                new Hashtable(){ {"XM","吴爱萍"},{"XB","女"},{"NL","46"},{"LGTS","加害性损伤后接受检查和观察；"},{"LCZD","238"},{"YCYE",1372.64} }
            });

            return hs;
        }

        public Hashtable GetAdmissionDischargeInfo()  
        {
            Hashtable hs = new Hashtable();


            //出入院
            hs.Add("cry", new Hashtable() {{"zrzy",2800},{"jrcy",503},{"jrry",623}});
            hs.Add("gzkcryqk", new ArrayList() { 
                new Hashtable(){{"ZKMC","肝胆外科"},{"RS",31},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","感染科"},{"RS",1},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","内分泌科"},{"RS",65},{"INNUM",1},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","神经外科"},{"RS",143},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","消化内二科"},{"RS",115},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","心血管内科	"},{"RS",99},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","医疗保健中心"},{"RS",135},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","整形科"},{"RS",45},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","急诊医学科	"},{"RS",24},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","精神卫生科"},{"RS",242},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","康复科"},{"RS",45},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","神经内科(一)"},{"RS",87},{"INNUM",0},{"OUTNUM",5}},
                new Hashtable(){{"ZKMC","眼科"},{"RS",1},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","肿瘤科"},{"RS",4},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","产科"},{"RS",100},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","儿科"},{"RS",42},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","老年病"},{"RS",299},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","皮肤科"},{"RS",24},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","生殖中心"},{"RS",7},{"INNUM",10},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","胃肠外科"},{"RS",85},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","胸外科"},{"RS",24},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","血透"},{"RS",78},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","针推理疗科	"},{"RS",12},{"INNUM",0},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","EICU"},{"RS",3},{"INNUM",10},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","肛肠外科"},{"RS",75},{"INNUM",1},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","呼吸内科"},{"RS",27},{"INNUM",1},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","介入治疗"},{"RS",17},{"INNUM",2},{"OUTNUM",0}},
                new Hashtable(){{"ZKMC","泌尿外科"},{"RS",38},{"INNUM",0},{"OUTNUM",0}},
            });

            // 床位
            hs.Add("edkcw",356);
            hs.Add("jckcw",320);
            hs.Add("xnkcw",719);
            hs.Add("gzkkcqk", new ArrayList() { 
                new Hashtable(){{"ZKMC","ICU"},{"EDKCW",19},{"JCKCW",0},{"XNKCW",3}},
                new Hashtable(){{"ZKMC","PICU"},{"EDKCW",4},{"JCKCW",0},{"XNKCW",0}},
                new Hashtable(){{"ZKMC","耳鼻喉科"},{"EDKCW",0},{"JCKCW",0},{"XNKCW",34}},
                new Hashtable(){{"ZKMC","肝胆外科"},{"EDKCW",0},{"JCKCW",0},{"XNKCW",19}},
                new Hashtable(){{"ZKMC","感染科"},{"EDKCW",0},{"JCKCW",0},{"XNKCW",9}},
                new Hashtable(){{"ZKMC","内分泌科"},{"EDKCW",18},{"JCKCW",0},{"XNKCW",8}},
                new Hashtable(){{"ZKMC","神经外科"},{"EDKCW",0},{"JCKCW",0},{"XNKCW",2}},
                new Hashtable(){{"ZKMC","消化内二科"},{"EDKCW",21},{"JCKCW",0},{"XNKCW",0}},
                new Hashtable(){{"ZKMC","小儿外科"},{"EDKCW",0},{"JCKCW",0},{"XNKCW",9}},
                new Hashtable(){{"ZKMC","心血管内科"},{"EDKCW",7},{"JCKCW",1},{"XNKCW",0}},
                new Hashtable(){{"ZKMC","神经外科"},{"EDKCW",36},{"JCKCW",14},{"XNKCW",0}},
                new Hashtable(){{"ZKMC","医疗保健中心"},{"EDKCW",0},{"JCKCW",0},{"XNKCW",3}},
                new Hashtable(){{"ZKMC","综合留观"},{"EDKCW",2},{"JCKCW",1},{"XNKCW",1}},
                new Hashtable(){{"ZKMC","急诊医学科"},{"EDKCW",0},{"JCKCW",1},{"XNKCW",3}},
                new Hashtable(){{"ZKMC","精神卫生科"},{"EDKCW",0},{"JCKCW",0},{"XNKCW",4}},
                new Hashtable(){{"ZKMC","康复科"},{"EDKCW",10},{"JCKCW",0},{"XNKCW",5}},
                new Hashtable(){{"ZKMC","神经内科(一)"},{"EDKCW",1*-/

        public Hashtable GetHospitalizationInfo()
        {
            Hashtable hs = new Hashtable();

            // 出入院
            hs.Add("cry", new Hashtable() { { "jrcyrs", 37 }, { "zrryrs", 482 } });    //出入院
            hs.Add("crytj", new Hashtable() {   // 出入院统计
                {"ryrs",new int[]{460,455,463,152,90,678,482}},
                {"cyrs",new int[]{216,145,108,27,6,33,6}}
            });
            // 住院收入
            hs.Add("zysr", new Hashtable() { 
                {"zrzysr", 699.12}, 
                {"jrzysr", 612} }
            );
            hs.Add("zysrje",
                new double[] { 301.12, 465.87, 642.76, 812.12, 762.12, 542.02, 699.12 }
            );
            // 病床使用率
            hs.Add("bc", new Hashtable() { { "zcws", 3200 }, { "dqzy", 2842 } });    //床位
            hs.Add("bcsyl", new double[] { 87.12, 84.56, 86.34, 90.04, 92.17, 85.22, 88.89 });
            // 住院人均
            hs.Add("zyrj", new Hashtable() { { "zrrjfy", 1024 }, { "syrjfy", 652 }, { "qnrjfy", 864 } });    //住院人均
            hs.Add("rjjetj", new int[] { 545, 1944, 810, 697, 1604, 976, 1024 });


            return hs;
        }
    }
}
