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
    public class OPDBillService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public OPDBillService(ApplicationDbContext db)
        {
            _dataAccessFactory = new DataAccessFactory(db);
        }
        public  List<OPDBillDTO> Get()
        {
            var data = _dataAccessFactory.OPDBillData().Get();
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<OPDBill, OPDBillDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<List<OPDBillDTO>>(data);
                return mapped;
            }
            return null;
        }



        public  OPDBillDTO Get(int id)
        {
            var data = _dataAccessFactory.OPDBillData().Get(opd => opd.Id == id);
            if (data != null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<OPDBill, OPDBillDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<OPDBillDTO>(data);
            }
            return null;
        }

        public  bool Create(OPDBillDTO opd)
        {
            var totalAmout = 0;
            var OPDData = new OPDBill
            {
                PatientId = opd.PatientId,
                PaidAmount = opd.PaidAmount,
                BillDate = DateTime.Now,
            };
            var OPDBill = _dataAccessFactory.OPDBillData().Add(OPDData);
            foreach (var item in opd.DiagId.ToArray())
            {
                var Diagnosis = _dataAccessFactory.DiagListData().Get(diag=> diag.Id == item);
                totalAmout += (int)Diagnosis.Cost;
                var diagnosisData = new PerformDiag
                {
                    PatientId = opd.PatientId,
                    DiagId = Diagnosis.Id,
                    Status = "Pending",
                    Cost = (int)Diagnosis.Cost
                };
                var PerfomedDiag = _dataAccessFactory.PerformDiagData().Add(diagnosisData);
                var OPDDetailsData = new OPDBillDetails
                {
                    OPDBillId = OPDBill.Id,
                    DoctorId = opd.DoctorId,
                    Amount = (int)PerfomedDiag.Cost,
                    PerformDiagId = PerfomedDiag.Id,
                };
                var BillDetails = _dataAccessFactory.OPDBillDetailsData().Add(OPDDetailsData);
            }
            var existOPDBill = _dataAccessFactory.OPDBillData().Get(opd=> opd.Id == OPDBill.Id);
            existOPDBill.BillAmount = totalAmout;
            if (totalAmout == opd.PaidAmount)
            {
                existOPDBill.Status = "Paid";
            }
            else { existOPDBill.Status = "Due"; }
            _dataAccessFactory.OPDBillData().Update(existOPDBill);
            return true;
        }

        public  bool Update(OPDBillDTO opd)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OPDBillDTO, OPDBill>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OPDBill>(opd);
            var res = _dataAccessFactory.OPDBillData().Update(mapped);
            return (res != null) ? true : false;

        }

    }
}
