using AutoMapper;
using HospitalMS.BLL.DTOs;
using HospitalMS.DAL;
using HospitalMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMS.BLL.Services
{
    public class OPDBillDetailService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public OPDBillDetailService(ApplicationDbContext db)
        {
            _dataAccessFactory = new DataAccessFactory(db);
        }
        public  OPDBillAllDetailsDTO GetAllInfo(int odpBilId)
        {
            var opdBill = _dataAccessFactory.OPDBillData().Get(opd => opd.Id == odpBilId);
            var data = _dataAccessFactory.OPDBillDetailsData().Get();
            var billDetails = (from d in data where d.OPDBillId == odpBilId select d).ToList();
            if (billDetails != null)
            {
                var result = new OPDBillAllDetailsDTO
                {
                    OPDBillId = odpBilId,
                    PatientName = opdBill.Patient.Name,
                    TotalAmount = opdBill.BillAmount,
                    PaidAmount = opdBill.PaidAmount,
                    DoctorName = billDetails[0].Doctor.Name,
                    BillDate = opdBill.BillDate.Date.ToShortDateString(),
                    Status = opdBill.Status,
                    DiagInfo = billDetails.Select(d => new DiagInfo
                    {
                        Amount = (int)d.Amount,
                        DiagnosisName = d.PerformDiag.DiagList.Name
                    }).ToList()
                };
                return result;

                //foreach(var r in billDetails)
                //{
                //    var result = new OPDBillAllDetailsDTO
                //    {
                //        PatientName = r.PerformDiag.Patient.Name,

                //    };
                //}
            }
            return null;

            //var data = _dataAccessFactory.OPDBillDetailsData().Get();
            //var billDetails = (from d in data where d.OPDBillId == odpBilId select d).ToList(); 
            //if (billDetails != null)
            //{
            //    var cfg = new MapperConfiguration(c =>
            //    {
            //        c.CreateMap<OPDBillDetails, OPDBillAllDetailsDTO>();
            //        c.CreateMap<OPDBill, OPDBillDTO>();
            //        c.CreateMap<PerformDiag, PerformDiagDTO>();
            //        c.CreateMap<Doctor, DoctorDTO>();
            //        //c.CreateMap<DiagList, DiagListDTO>();    
            //    });
            //    var mapper = new Mapper(cfg);
            //    var mapped = mapper.Map<List<OPDBillAllDetailsDTO>>(billDetails);
            //    return mapped;
            //}
            //return null;
        }
        public  byte[] PrintOPDBillDetails(int opdBillId)
        {
            var result = GeneratePDF.GetPDF("OPDBillAllDetails", GetAllInfo(opdBillId));
            return result;
        }
    }
}
