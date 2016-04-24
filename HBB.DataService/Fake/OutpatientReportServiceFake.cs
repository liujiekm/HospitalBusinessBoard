using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;

namespace HBB.DataService.Fake
{
    public class OutpatientReportServiceFake : IOutpatientReportService
    {
        public List<IncomeStatistics> GetOutpatientIncome(DateTime startDateTime, DateTime endDateTime, String sfyq)
        { 
            throw new NotImplementedException();
        }


        #region 首页信息
        #region 1首页左侧数据
		 //首页左侧数据
		 public HomeInformation GetHomeInformation() 
        {
            #region 直接给值
            HomeInformation homeInformation = new HomeInformation();
            homeInformation.DoctorTotalQuantyAm = 652;
            homeInformation.DoctorRegisteredQuantyAm = 588;
            homeInformation.RegistrationRateAm = (Single)Math.Round((Single)homeInformation.DoctorRegisteredQuantyAm / (Single)homeInformation.DoctorTotalQuantyAm, 2);
            homeInformation.DoctorTotalQuantyPm = 321;
            homeInformation.DoctorRegisteredQuantyPm = 200;
            homeInformation.RegistrationRatePm = (Single)Math.Round((Single)homeInformation.DoctorRegisteredQuantyPm / (Single)homeInformation.DoctorTotalQuantyPm, 2);
            homeInformation.WaitingQuantity = 520;
            homeInformation.CompletedTreatQuanty = 5314;
            homeInformation.SevereObservingQuanty = 88;
            homeInformation.FirstAidQuanty = 54;
            homeInformation.HospitalizedQuanty = 3866;
            homeInformation.YesterdayLeaveHospitalQuanty = 58;
            homeInformation.YesterdayAdminttedHospitalQuanty = 623;
            homeInformation.RatedEmptyBedQuanty = 622;
            homeInformation.ExtraBedQuanty = 100;
            homeInformation.VirtualBedQuanty = 321;
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
            for (int i = 1; i < 8; i++)
            {
                //Random random = new Random();
                DoctorRegistration registration = new DoctorRegistration();
                //registration.RegistrationRate = (float)random.Next(80,100)/(float)100;
                registration.RegistrationDate = DateTime.Now.Date.AddDays(-0.5 * i + 0.5).ToString();
                registration.DoctorTotal = random.Next(800, 1000);
                registration.DoctorRegistered = random.Next(500, 800);
                registration.RegistrationRate = (float)Math.Round((float)registration.DoctorRegistered / (float)registration.DoctorTotal, 2);
                if (i % 2 == 0) registration.RegistrationTime = "2";
                else { registration.RegistrationTime = "1"; }
                list_Registration.Add(registration);
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
                waitingQuanty.CompletedTreatQuanty = random.Next(500, 1000);
                waitingQuanty.WaitingQuanty = random.Next(200, 600);
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
            SurgeryInfor.WaitingQuanty = 35;
            return SurgeryInfor;
        }
        //获取额定空床数量
        public List<RateEmptyBed> GetRateEmptyBed()
        {
            List<RateEmptyBed> list_RateEmptyBed = new List<RateEmptyBed>();
            string[] Specialist = { "0","皮肤科", "五官科", "妇科", "骨科", "内分泌科"};
            Random random = new Random();
            for (int i = 1; i < 6; i++)
            {
                RateEmptyBed rateEmptyBed = new RateEmptyBed();
                rateEmptyBed.RateEmptyBedQuanty = random.Next(50, 100);
                rateEmptyBed.Specialist = Specialist[i];
                list_RateEmptyBed.Add(rateEmptyBed);
            }
            return list_RateEmptyBed;
        }  
	    #endregion
	    #endregion
        //手术信息
        public List<SurgeryDetailedInformation> GetSurgeryDetailedInformation(string type)
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


        //1.门诊收入汇总
        public List<IncomeByTime> GetIncomeAll(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            List<IncomeByTime> list_income = new List<IncomeByTime>();
            for (var i = 0; i < 7; i++)
            {
                IncomeByTime income = new IncomeByTime();
                //income.TotolMoney = 7635*(i+1);
                income.TimeStemp = endDateTime.AddDays(-i).ToShortDateString().ToString();
                list_income.Add(income);
            }


            list_income[0].TotolMoney = 5460000;
            list_income[1].TotolMoney = 6790000;
            list_income[2].TotolMoney = 1320000;
            list_income[3].TotolMoney = 1110000;
            list_income[4].TotolMoney = 5280000;
            list_income[5].TotolMoney = 6470000;
            list_income[6].TotolMoney = 5980000;

            list_income.Reverse();
            return list_income;
        }
        //2.挂号人次汇总
        public List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            List<RegisterVisitors> list_income = new List<RegisterVisitors>();
            for (var i = 0; i < 7; i++)
            {
                RegisterVisitors income = new RegisterVisitors();
                //income.Visitors = 2341 * (i + 1);
                income.TimeStemp = endDateTime.AddDays(-i).ToShortDateString().ToString();
                list_income.Add(income);
            }

            list_income[0].Visitors = 14325;
            list_income[1].Visitors = 13657;
            list_income[2].Visitors = 3452;
            list_income[3].Visitors = 2341;
            list_income[4].Visitors = 11345;
            list_income[5].Visitors = 14352;
            list_income[6].Visitors = 13221;
            list_income.Reverse();
            return list_income;



        }
        //3.实名制挂号人次汇总
        public List<RegisterVisitors> GetRealNameVisitors(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            List<RegisterVisitors> list_income = new List<RegisterVisitors>();
            for (var i = 0; i < 7; i++)
            {
                RegisterVisitors income = new RegisterVisitors();
                //income.Visitors = 1234 * (i);
                income.TimeStemp = endDateTime.AddDays(-i).ToShortDateString().ToString();
                list_income.Add(income);
            }
            double rate = 0.8;
            list_income[0].Visitors = Convert.ToInt32(14325* rate);
            list_income[1].Visitors = Convert.ToInt32(13657 * rate);
            list_income[2].Visitors = Convert.ToInt32(3452 * rate);
            list_income[3].Visitors = Convert.ToInt32(2341 * rate);
            list_income[4].Visitors = Convert.ToInt32(11345 * rate);
            list_income[5].Visitors = Convert.ToInt32(14352 * rate);
            list_income[6].Visitors = Convert.ToInt32(13221 * rate);
            list_income.Reverse();
            return list_income;
        }
        //4.预存挂号人次汇总
        public List<RegisterVisitors> GetIncomeVisitors(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            List<RegisterVisitors> list_income = new List<RegisterVisitors>();
            for (var i = 0; i < 7; i++)
            {
                RegisterVisitors income = new RegisterVisitors();
                //income.Visitors = 1452 * (i);
                income.TimeStemp = endDateTime.AddDays(-i).ToShortDateString().ToString();
                list_income.Add(income);
            }

            double rate = 0.94;
            list_income[0].Visitors = Convert.ToInt32(14325 * rate);
            list_income[1].Visitors = Convert.ToInt32(13657 * rate);
            list_income[2].Visitors = Convert.ToInt32(3452 * rate);
            list_income[3].Visitors = Convert.ToInt32(2341 * rate);
            list_income[4].Visitors = Convert.ToInt32(11345 * rate);
            list_income[5].Visitors = Convert.ToInt32(14352 * rate);
            list_income[6].Visitors = Convert.ToInt32(13221 * rate);

            list_income.Reverse();
            return list_income;
        }
        //5.预存金额汇总
        public List<IncomeByTime> GetIncomeFirst(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            List<IncomeByTime> list_income = new List<IncomeByTime>();
            for (var i = 0; i < 7; i++)
            {
                IncomeByTime income = new IncomeByTime();
                income.TotolMoney = 97546 * (i + 1);
                income.TimeStemp = endDateTime.AddDays(-i).ToShortDateString().ToString();
                list_income.Add(income);
            }
            return list_income;
        }
        //6.预约人次汇总
        public List<RegisterVisitors> GetFirstVisitors(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            List<RegisterVisitors> list_income = new List<RegisterVisitors>();
            for (var i = 0; i < 7; i++)
            {
                RegisterVisitors income = new RegisterVisitors();
                income.Visitors = 1456 * (i + 1);
                income.TimeStemp = endDateTime.AddDays(-i).ToShortDateString().ToString();
                list_income.Add(income);
            }

            //double rate = 0.74;
            list_income[0].Visitors = Convert.ToInt32(14325 * 0.84);
            list_income[1].Visitors = Convert.ToInt32(13657 * 0.76);
            list_income[2].Visitors = Convert.ToInt32(3452 * 0.92);
            list_income[3].Visitors = Convert.ToInt32(2341 * 0.81);
            list_income[4].Visitors = Convert.ToInt32(11345 * 0.79);
            list_income[5].Visitors = Convert.ToInt32(14352 * 0.69);
            list_income[6].Visitors = Convert.ToInt32(13221 * 0.91);
            list_income.Reverse();
            return list_income;
        }
    }
}
