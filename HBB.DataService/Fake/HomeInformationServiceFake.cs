using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;

namespace HBB.DataService.Fake
{
    public class HomeInformationServiceFake : IHomeInformation
    {
        #region 首页信息
        #region 1首页左侧数据
        //首页左侧数据
        public HomeInformation GetHomeInformation()
        {
            #region 直接给值

            int hour = DateTime.Now.Hour;
            int[] DoctorRegisteredQuantyAm = {  0,0,0,0,0,0,5, 20, 121, 176, 180, 203,203,203};
            int[] DoctorRegisteredQuantyPm = {  97, 135, 148, 166, 166,166};
           
            HomeInformation homeInformation = new HomeInformation();
            if (hour < 13)//超过12点 ,13点开始
            {
                homeInformation.DoctorTotalQuantyAm = 211;
                homeInformation.DoctorRegisteredQuantyAm = DoctorRegisteredQuantyAm[hour];
                homeInformation.RegistrationRateAm = (Single)Math.Round((double)homeInformation.DoctorRegisteredQuantyAm / (double)homeInformation.DoctorTotalQuantyAm, 2);//96%

                homeInformation.DoctorTotalQuantyPm = 172;
                homeInformation.DoctorRegisteredQuantyPm = 0;
                homeInformation.RegistrationRatePm = (float)0;


            }
            else if (hour >= 13 && hour < 18)
            {
                homeInformation.DoctorTotalQuantyAm = 211;
                homeInformation.DoctorRegisteredQuantyAm = 203;
                homeInformation.RegistrationRateAm = (Single)Math.Round((double)homeInformation.DoctorRegisteredQuantyAm / (double)homeInformation.DoctorTotalQuantyAm, 2);//96%

                homeInformation.DoctorTotalQuantyPm = 172;
                homeInformation.DoctorRegisteredQuantyPm = DoctorRegisteredQuantyPm[hour-13];
                homeInformation.RegistrationRatePm = (Single)Math.Round((double)homeInformation.DoctorRegisteredQuantyPm / (double)homeInformation.DoctorTotalQuantyPm, 2);//66%
            }
            else
            {
                homeInformation.DoctorTotalQuantyAm = 211;
                homeInformation.DoctorRegisteredQuantyAm = 203;
                homeInformation.RegistrationRateAm = (Single)Math.Round((double)homeInformation.DoctorRegisteredQuantyAm / (double)homeInformation.DoctorTotalQuantyAm, 2);//96%

                homeInformation.DoctorTotalQuantyPm = 172;
                homeInformation.DoctorRegisteredQuantyPm = 166;
                homeInformation.RegistrationRatePm = (Single)Math.Round((double)homeInformation.DoctorRegisteredQuantyPm / (double)homeInformation.DoctorTotalQuantyPm, 2);//66%
            }


            homeInformation.WaitingQuantity = 1781;
            homeInformation.CompletedTreatQuanty = 6606;
            homeInformation.SevereObservingQuanty = 46;
            homeInformation.FirstAidQuanty = 24;
            homeInformation.HospitalizedQuanty = 3892;
            homeInformation.YesterdayLeaveHospitalQuanty = 811;
            homeInformation.YesterdayAdminttedHospitalQuanty = 765;
            homeInformation.RatedEmptyBedQuanty = 482;
            homeInformation.ExtraBedQuanty = 498;
            homeInformation.VirtualBedQuanty = 681;
            return homeInformation;
            #endregion
        }
        #endregion
        #region 2首页右侧数据
        //医生签到率
        public List<DoctorRegistration> GetDoctorRegistration()
        {
            List<DoctorRegistration> list_Registration = new List<DoctorRegistration>();
            Random random = new Random();
            for (int i = 7; i >0; i--)
            {
                DoctorRegistration registration = new DoctorRegistration();
                if (i == 1  )
                {
                    registration.RegistrationDate = DateTime.Now.Date.AddDays(-0.5 * i + 0.5).ToString("MM-dd");
                    registration.RegistrationRate = (float)0.96;
                    if (i % 2 == 0) registration.RegistrationTime = "下午";
                    else { registration.RegistrationTime = "上午"; }
                    list_Registration.Add(registration);
                }
                else
                {
                    registration.RegistrationDate = DateTime.Now.Date.AddDays(-0.5 * i + 0.5).ToString("MM-dd");
                    registration.DoctorTotal = random.Next(950, 1000);
                    registration.DoctorRegistered = random.Next(900, 950)-20*i+50;
                    if (i % 2 == 0) registration.RegistrationTime = "下午";
                    else { registration.RegistrationTime = "上午"; }
                    registration.RegistrationRate = (float)Math.Round((float)registration.DoctorRegistered / (float)registration.DoctorTotal, 2);
                    list_Registration.Add(registration);
                }
                
            }

            return list_Registration;
        }
        //获取候诊人数
        public List<WaitingPatientQuanty> GetWaitingQuanty()
        {
            List<WaitingPatientQuanty> list_WaitingQuanty = new List<WaitingPatientQuanty>();
            string[] Specialist = { "0", "肿瘤科", "内分泌科", "妇科", "骨科", "放射科" };
            Random random = new Random();
            for (int i = 1; i < 6; i++)
            {
                WaitingPatientQuanty waitingQuanty = new WaitingPatientQuanty();
                waitingQuanty.CompletedTreatQuanty = random.Next(300, 400) - 30 * i; 
                waitingQuanty.WaitingQuanty = random.Next(600, 700) - 50 * i;
                waitingQuanty.Specialist = Specialist[i];
                list_WaitingQuanty.Add(waitingQuanty);
            }
            return list_WaitingQuanty;
        }
        //手术信息
        public SurgeryInformation GetSurgeryInformation()
        {
            SurgeryInformation SurgeryInfor = new SurgeryInformation();
            SurgeryInfor.CompletedQuanty = 52;
            SurgeryInfor.DoingQuanty = 23;
            SurgeryInfor.WaitingQuanty = 12;
            return SurgeryInfor;
        }
        //获取额定空床数量
        public List<RateEmptyBed> GetRateEmptyBed()
        {
            List<RateEmptyBed> list_RateEmptyBed = new List<RateEmptyBed>();
            string[] Specialist = { "0", "皮肤科", "五官科", "妇科", "骨科", "内分泌科" };
            Random random = new Random();
            for (int i = 1; i < 6; i++)
            {
                RateEmptyBed rateEmptyBed = new RateEmptyBed();
                rateEmptyBed.RateEmptyBedQuanty = random.Next(70, 90)-10*i;
                rateEmptyBed.Specialist = Specialist[i];
                list_RateEmptyBed.Add(rateEmptyBed);
            }
            return list_RateEmptyBed;
        }
        #endregion
        #endregion

        //手术信息
        public List<SurgeryDetailedInformation> GetSurgeryDetailedInformation(string oprationState, string searchType, string area, string operationType, string sDate, string eDate, string content)

        {
            string[] SurgeryCode = { "330301", "330303", "330401", "330526", "330401", "330506", "330701", "330625" };
            string[] OperatingRoomCode = { "01", "01", "01", "04", "05", "03", "03", "01" };
            string[] PateintName = { "林小莲", "吴冰冰", "李国光", "杨光", "金耀秋", "刘小媚", "林碎花", "李丽" };
            string[] SurgeryName = { "剖宫产手术", "肠切除术", "皮肤清创术", "膀胱造瘘管置换术 ", "附睾囊肿切除术", "小清创缝合术", "皮脂囊肿切除术", "纤维瘤切除术" };
            string[] SurgeryType = { "1", "1", "1", "1", "2", "2", "2", "2" };
            string[] SurgeonDoctor = { "陈肖俊", "陈肖俊", "陈肖俊", "张宇", "张宇", "张宇", "张宇", "张宇" };
            string[] Anesthesiologist = { "金建国", "金建国", "金建国", "金建国", "金建国", "陈思思", "陈思思", "陈思思" };
            List<SurgeryDetailedInformation> list_model = new List<SurgeryDetailedInformation>();
            Random random = new Random();
            for (int i = 1; i < 8; i++)
            {
                SurgeryDetailedInformation model = new SurgeryDetailedInformation();
                model.SurgeryCode = SurgeryCode[i];
                model.OperatingRoomCode = OperatingRoomCode[i];
                model.PateintName = PateintName[i];
                model.SurgeryName = SurgeryName[i];
                model.SurgeryType = SurgeryType[i];
                model.SurgeonDoctor = SurgeonDoctor[i];
                model.Anesthesiologist = Anesthesiologist[i];
                model.SurgeryStartTime = DateTime.Now.AddHours(-i);
                list_model.Add(model);
            }

            return list_model;
        }

        public DataSet GetOperationQuanty()
        {
            DataSet ds = new DataSet();

            DataTable table = ds.Tables.Add("Table");
            table.Columns.Add("TOTAL", typeof(string));
            table.Columns.Add("ONETYPEOPERATION", typeof(int));
            table.Columns.Add("TWOTYPEOPERATION", typeof(int));
            table.Columns.Add("THREETYPEOPERATION", typeof(int));
            table.Columns.Add("FOURTYPEOPERATION", typeof(int));
            table.Columns.Add("FIVETYPEOPERATION", typeof(int));
            object[] aValues = { 7259, 562, 1493, 2700, 2251, 253 };

            ds.Tables["Table"].LoadDataRow(aValues, false);
            return ds;
        }
    
    }
}
