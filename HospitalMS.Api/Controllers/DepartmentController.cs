using HospitalMS.BLL;
using HospitalMS.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HospitalMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public DepartmentController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("api/dept/all")]
        
        public JsonResult Get()
        {
            var obj = _unitOfWork.Department.Get(u=>u.DepartmentId == 1);
            return new JsonResult(new { obj });
        }
    }
}
