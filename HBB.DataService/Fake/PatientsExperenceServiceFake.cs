using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;

namespace HBB.DataService.Fake
{
    public class PatientsExperenceServiceFake:IPatientsExperenceService
    {
        public List<AverageTreatmentTime> GetAverageTime(DateTime startTime, DateTime endTime, string type)
        {
            throw new NotImplementedException();
        }

        public List<AverageTreatmentTime> GetSpecialAverageTime(DateTime startTime, DateTime endTime, string type)
        {
            throw new NotImplementedException();
        }

        public List<KeyValuePair<string, int>> GetOperationCount(DateTime startTime, DateTime endTime, string type)
        {
            throw new NotImplementedException();
        }

        public string GetAvgAppointmentTime()
        {
            return "5.1";
        }

        public List<DeptAverageTreatmentTime> GetTreatmentAverageTime(DateTime sTime, DateTime eTime, params string[] districtType)
        {
            var  datts = new List<DeptAverageTreatmentTime>
            {
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                       Appointment = 2500,
                       AwaitingDiagnosis = 32,
                       Diagnosis = 25,
                       MedicineReceiving = 10,
                       PayFees = 5,
                       SpecialistName = "肾内科"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =15,
                       Appointment = 2700,
                       AwaitingDiagnosis = 38,
                       Diagnosis = 21,
                       MedicineReceiving = 9,
                       PayFees = 10,
                       SpecialistName = "血液内科"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =16,
                       Appointment = 2100,
                       AwaitingDiagnosis = 27,
                       Diagnosis = 20,
                       MedicineReceiving = 15,
                       PayFees = 8,
                       SpecialistName = "内分泌"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =17,
                       Appointment = 2100,
                       AwaitingDiagnosis = 35,
                       Diagnosis = 27,
                       MedicineReceiving = 12,
                       PayFees = 10,
                       SpecialistName = "感染科"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =18,
                       Appointment = 2100,
                       AwaitingDiagnosis = 27,
                       Diagnosis = 21,
                       MedicineReceiving = 8,
                       PayFees = 4,
                       SpecialistName = "肿瘤内科"
                },
                 new DeptAverageTreatmentTime()
                {
                       SpecialistId =19,
                       Appointment = 2100,
                       AwaitingDiagnosis = 27,
                       Diagnosis = 21,
                       MedicineReceiving = 8,
                       PayFees = 4,
                       SpecialistName = "AIDS"
                }
                
            };
            return datts;
        }


        public List<DeptAverageTreatmentTime> GetDeptTreatmentAverageTime(DateTime sTime, DateTime eTime, int[] depts, params string[] hospitalDistrict)
        {
            throw new NotImplementedException();
        }


        public List<SpecialInspection> GetSpecialInspections(DateTime startDateTime, DateTime endDateTime, params string[] hospitalDistrict)
        {
            Random random = new Random();
            List<SpecialInspection> lists = new List<SpecialInspection>() { 
                new SpecialInspection(){
                     InspectionType="MR",
                     AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="CT",
                     AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="BC",
                     AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="CR",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="CU",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 }         
            
            };
            return lists;
        }

        public List<SpecialInspection> GetSpecialInspectionsGroupByTime(DateTime startDateTime, DateTime endDateTime, string[] inspactTypes, params string[] hospitalDistrict)
        {
            Random random = new Random();
            List<SpecialInspection> lists = new List<SpecialInspection>() { 
                new SpecialInspection(){
                     InspectionType="MR",
                     TimeStamp="2014-05",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="MR",
                     TimeStamp="2014-06",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="MR",
                     TimeStamp="2014-07",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },

                 new SpecialInspection(){
                     InspectionType="CT",
                     TimeStamp="2014-05",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="CT",
                     TimeStamp="2014-06",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="CT",
                     TimeStamp="2014-07",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                  new SpecialInspection(){
                     InspectionType="CR",
                     TimeStamp="2014-05",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },

                 new SpecialInspection(){
                     InspectionType="CR",
                     TimeStamp="2014-06",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="CR",
                     TimeStamp="2014-07",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 }
            
            };
            return lists;
        }

        public List<List<SpecialInspection>> GetSpecialInspectionYearToYear(DateTime startDateTime, DateTime endDateTime, string inspetType, params string[] hospitalDistrict)
        {
            Random random = new Random();
            List<List<SpecialInspection>> lists = new List<List<SpecialInspection>>();
            lists.Add(new List<SpecialInspection>() { 
            
            new SpecialInspection(){
                     InspectionType="MR",
                     TimeStamp="2014-05",
                     AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="MR",
                     TimeStamp="2014-06",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="MR",
                     TimeStamp="2014-07",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 }
            });

            lists.Add(new List<SpecialInspection>()
            {

                new SpecialInspection(){
                     InspectionType="MR",
                     TimeStamp="2013-05",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="MR",
                     TimeStamp="2013-06",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="MR",
                     TimeStamp="2013-07",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 }
            });

            lists.Add(new List<SpecialInspection>()
            {
                new SpecialInspection(){
                     InspectionType="MR",
                     TimeStamp="2012-05",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="MR",
                     TimeStamp="2012-06",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 },
                 new SpecialInspection(){
                     InspectionType="MR",
                     TimeStamp="2012-07",
                      AppointmentDuration=random.Next(2000,2700),
                     ReportDuration=1+random.NextDouble(),
                     ActualInspectNum=random.Next(16,25),
                     BreakNum=random.Next(1,10)
                 }

            });

            return lists;

        }


        public List<List<DeptAverageTreatmentTime>> GetDeptTreatmentAverageTimeYearToYear(DateTime startDateTime, DateTime endDateTime, int deptId, params string[] hospitalDistrict)
        {
            List<List<DeptAverageTreatmentTime>> list = new List<List<DeptAverageTreatmentTime>>();
            Random random = new Random();
            list.Add(new List<DeptAverageTreatmentTime>()
            {
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                        StaticsTime="2014-05-01"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                       Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2014-05-02"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                       Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2014-05-03"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                       Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2014-05-04"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                       Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2014-05-05"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                      Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2014-05-06"
                }

            });




            list.Add(new List<DeptAverageTreatmentTime>()
            {
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                       Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                        StaticsTime="2013-05-01"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                      Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2013-05-02"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                      Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2013-05-03"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                       Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2013-05-04"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                      Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2013-05-05"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                      Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2013-05-06"
                }

            });




            list.Add(new List<DeptAverageTreatmentTime>()
            {
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                     Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                        StaticsTime="2012-05-01"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                       Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2012-05-02"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                      Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2012-05-03"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                          Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2012-05-04"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2012-05-05"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2012-05-06"
                }

            });

            return list;

        }


        public List<DeptAverageTreatmentTime> GetDeptTreatmentAverageTimeGroupByTime(DateTime sTime, DateTime eTime, int[] depts, params string[] hospitalDistrict)
        {
            Random random = new Random();
            var datts = new List<DeptAverageTreatmentTime>
            {
                 new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                       Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                        StaticsTime="2014-05-01"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2014-05-02"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                       Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2014-05-03"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2014-05-04"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2014-05-05"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =14,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "肾内科",
                       StaticsTime="2014-05-06"
                },


                   new DeptAverageTreatmentTime()
                {
                       SpecialistId =15,
                       Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "血液科",
                        StaticsTime="2014-05-01"
                },
                new DeptAverageTreatmentTime()
                {
                      SpecialistId =15,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "血液科",
                       StaticsTime="2014-05-02"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =15,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "血液科",
                       StaticsTime="2014-05-03"
                },
                new DeptAverageTreatmentTime()
                {
                      SpecialistId =15,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "血液科",
                       StaticsTime="2014-05-04"
                },
                new DeptAverageTreatmentTime()
                {
                        SpecialistId =15,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "血液科",
                       StaticsTime="2014-05-05"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =15,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "血液科",
                       StaticsTime="2014-05-06"
                },


                    new DeptAverageTreatmentTime()
                {
                       SpecialistId =16,
                       Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "内分泌",
                        StaticsTime="2014-05-01"
                },
                new DeptAverageTreatmentTime()
                {
                     SpecialistId =16,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "内分泌",
                       StaticsTime="2014-05-02"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =16,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "内分泌",
                       StaticsTime="2014-05-03"
                },
                new DeptAverageTreatmentTime()
                {
                      SpecialistId =16,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "内分泌",
                       StaticsTime="2014-05-04"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =16,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "内分泌",
                       StaticsTime="2014-05-05"
                },
                new DeptAverageTreatmentTime()
                {
                      SpecialistId =16,
                       Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "内分泌",
                       StaticsTime="2014-05-06"
                },




                         new DeptAverageTreatmentTime()
                {
                       SpecialistId =17,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "感染科",
                        StaticsTime="2014-05-01"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =17,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "感染科",
                       StaticsTime="2014-05-02"
                },
                new DeptAverageTreatmentTime()
                {
                        SpecialistId =17,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "感染科",
                       StaticsTime="2014-05-03"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =17,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "感染科",
                       StaticsTime="2014-05-04"
                },
                new DeptAverageTreatmentTime()
                {
                         SpecialistId =17,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "感染科",
                       StaticsTime="2014-05-05"
                },
                new DeptAverageTreatmentTime()
                {
                       SpecialistId =17,
                        Appointment=random.Next(2000,2700),
                       AwaitingDiagnosis = new Random().Next(25,35),
                       Diagnosis = new Random().Next(25,35),
                       MedicineReceiving = new Random().Next(0,10),
                       PayFees = new Random().Next(5,10),
                       SpecialistName = "感染科",
                       StaticsTime="2014-05-06"
                }
                
            };

            return datts;
        }


        public List<List<DeptAverageTreatmentTime>> GetDeptTreatmentAverageTimeGroupByDept(List<DeptAverageTreatmentTime> data)
        {
            List<List<DeptAverageTreatmentTime>> result = new List<List<DeptAverageTreatmentTime>>();
            var grouped = data.GroupBy(d => d.SpecialistId);
            foreach (var collection in grouped)
            {
                result.Add(collection.ToList());
            }

            return result;
        }


        public double[] GetOutPatientIndicatorLastMonth()
        {
            return new double[] {1620,7.5,5.1,2.9,9.3 };
        }

        public double[] GetSpecialInspectorIndicatorLastMonth()
        {
            return new double[] { 1620, 1620, 5100, 5000, 3500 };
        }


        public List<List<SpecialInspection>> GetSpecialInspectionsGroupByGroupByType(List<SpecialInspection> data)
        {
            List<List<SpecialInspection>> result = new List<List<SpecialInspection>>();
            var grouped = data.GroupBy(d => d.InspectionType);
            foreach (var collection in grouped)
            {
                result.Add(collection.ToList());
            }

            return result;
        }


    }
}
