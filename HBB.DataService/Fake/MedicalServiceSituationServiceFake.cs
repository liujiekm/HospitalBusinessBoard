using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBB.DataService.Model;
using HBB.DataService.ServiceInterface;

namespace HBB.DataService.Fake
{
    public class MedicalServiceSituationServiceFake:IMedicalServiceSituation
    {
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
                temp.SpecialistName = "科室"+i;
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
                temp.DoctorName = "医生" + i;
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
                temp.DoctorName = "医生" + i;
                res.Add(temp);
            }
            res.Sort();
            return res;
        }
    }
}
