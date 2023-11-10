using HospitalMS.BLL;
using HospitalMS.BLL.DTOs;
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
        public IActionResult Get()
        {
            try
            {
                return  Ok(_unitOfWork.Department.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("api/dept/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_unitOfWork.Department.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("api/dept/add")]
        public IActionResult Add(DepartmentDTO dept)
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
                    return BadRequest(new { Msg = "Not Inserted", Data = dept });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Msg = ex.Message, Data = dept });
            }
        }
        [HttpPost]
        [Route("api/dept/update")]
        public IActionResult Update(DepartmentDTO dept)
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
                    return BadRequest( new { Msg = "Not Updated", Data = dept });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Msg = ex.Message, Data = dept });
            }
        }
        [HttpPost]
        [Route("api/dept/delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var res = _unitOfWork.Department.Delete(id);
                if (res)
                {
                    return Ok(new { Msg = "Delete Success" });
                }
                else
                {
                    return BadRequest( new { Msg = "Delete failed" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Msg = ex.Message });
            }
        }

    }
}
