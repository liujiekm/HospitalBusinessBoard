using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;

namespace HBB.DataService.Fake
{
    public class MedicalServiceSituationServiceFake:IMedicalServiceSituation
    {
        private string[] depts = new string[] { "内科","外科","皮肤科","骨科","泌尿科","儿科","内分泌科","眼科","耳鼻喉科","胸外科"};
        private string[] doctors = new string[] { "周蒙滔", "施红旗", "钱岩法", "余正平", "宋其同", "廖毅", "单云峰", "杨文军", "陈宗静", "唐银河" };
        //假数据获取server
        //按专科获取就诊/候诊人次列表
        public List<MedicalService> GetSpecialistMedicalService() {
            List<MedicalService> res = new List<MedicalService>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                MedicalService temp = new MedicalService();
                temp.HZnums = rand.Next(100,500);
                temp.JZnums = rand.Next(50, 100);
                temp.SpecialistID = i;
                temp.SpecialistName = depts[i];
                res.Add(temp);
            }
            res.Sort();
                return res;
        }

        //获取专科下医生就诊/候诊人次列表
        public List<MedicalService> GetDoctorSpecialistMedicalService(string zkid) {
            List<MedicalService> res = new List<MedicalService>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                MedicalService temp = new MedicalService();
                temp.HZnums = rand.Next(100, 500);
                temp.JZnums = rand.Next(50, 100);
                temp.DoctorID = i;
                temp.DoctorName = doctors[i];
                res.Add(temp);
            }
            res.Sort();
            return res;
        }

        //获取全院医生就诊/候诊人次列表
        public List<MedicalService> GetDoctorMedicalService() {
            List<MedicalService> res = new List<MedicalService>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                MedicalService temp = new MedicalService();
                temp.HZnums = rand.Next(100, 500);
                temp.JZnums = rand.Next(50, 100);
                temp.DoctorID = i;
                temp.DoctorName = depts[i];
                res.Add(temp);
            }
            res.Sort();
            return res;
        }
    }
}
