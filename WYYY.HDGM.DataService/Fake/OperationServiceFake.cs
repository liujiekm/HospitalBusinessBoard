using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WYYY.HDGM.DataService.Model;
using WYYY.HDGM.DataService.ServiceInterface;

namespace WYYY.HDGM.DataService.Fake
{
    public class OperationServiceFake:IOperationService
    {
        //手术信息
        public List<SurgeryDetailedInformation> GetSurgeryDetailedInformation(string oprationState, string searchType, string area, string operationType, string sDate, string eDate, string content)
        {
            string[] SurgeryCode = { "330301", "330303", "330401", "330526", "330401", "330506", "330701", "330625" };
            string[] OperatingRoomCode = { "01", "01", "01", "03", "03", "03", "05", "05" };
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

        public List<OperationSearchRate> GetOperationSearchRate(String SearchContent, String type)
        {
            List<OperationSearchRate> list_model = new List<OperationSearchRate>();

            return list_model;
        }
    
    }
}
