using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYYY.HDGM.DataService.Model
{
    public class MedicalService:IComparable
    {
        private Int32 _doctorID;
        /// <summary>
        /// 医生id
        /// </summary>
        public int DoctorID
        {
            get { return _doctorID; }
            set { _doctorID = value; }
        }
        private string _doctorName;
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string DoctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; }
        }
        private int _specialistID;
        /// <summary>
        /// 专科id
        /// </summary>
        public int SpecialistID
        {
            get { return _specialistID; }
            set { _specialistID = value; }
        }
        private string _specialistName;
        /// <summary>
        /// 专科名称
        /// </summary>
        public string SpecialistName
        {
            get { return _specialistName; }
            set { _specialistName = value; }
        }
        private int _hZnums;
        /// <summary>
        /// 候诊人次
        /// </summary>
        public int HZnums
        {
            get { return _hZnums; }
            set { _hZnums = value; }
        }
        private int _jZnums;
        /// <summary>
        /// 就诊人次
        /// </summary>
        public int JZnums
        {
            get { return _jZnums; }
            set { _jZnums = value; }
        }
        
            public int CompareTo(object obj)
            {
                int result;
                try
                {
                    MedicalService info = obj as MedicalService;
                    if (this.HZnums > info.HZnums)
                    {
                        result = -1;
                    }
                    else
                        result = 1;
                    return result;
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
        
    }
}
