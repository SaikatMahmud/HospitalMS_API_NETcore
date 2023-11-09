using HospitalMS.BLL;
using HospitalMS.BLL.Services;
using HospitalMS.DAL.Models;
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
            var obj = _unitOfWork.Department.Get();
            return new JsonResult(new { obj });
        }

        [HttpGet]
        [Route("api/dept/{id}")]
        public JsonResult Get(int id)
        {
            var obj = _unitOfWork.Department.Get(u => u.DepartmentId == id);
            return new JsonResult(new { obj });
        }


        [HttpPost]
        [Route("api/dept/add")]
        public IActionResult Add(Department dept)
        {
            try
            {
                var res = _unitOfWork.Department.Create(dept);
                if (res)
                {
                    return Ok(new { Msg = "Inserted", Data = dept });
                }
                else
                {
                    return Ok(new { Msg = "Not Inserted", Data = dept });
                }
            }
            catch (Exception ex)
            {
                return Ok( new { Msg = ex.Message, Data = dept });
            }
        }

        [HttpPut]
        [Route("api/dept/update")]
        public IActionResult Update(Department dept)
        {
            try
            {
                var res = _unitOfWork.Department.Update(dept);
                if (res)
                {
                    return Ok(new { Msg = "Updated", Data = dept });
                }
                else
                {
                    return BadRequest(new { Msg = "Not Updated", Data = dept });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Msg = ex.Message, Data = dept });
            }
        }

    }
}
