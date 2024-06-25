using App.Core;
using App.Core.Consts;
using App.Core.Models.UnitModule;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            int status = 0;
            string msg = "";
            var unitData = _unitOfWork.Units.GetById(id);
            if (unitData == null)
            {
                status = 404;
                msg = "Not Found";
            }
            else
            {
                status = 200;
                msg = "success";
            }
            return Ok(new { status, msg, unitData });
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Units.GetAll());
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            return Ok(_unitOfWork.Units.Find(b => b.Name == name));
        }

        //[HttpGet("GetAllWithAuthors")]
        //public IActionResult GetAllWithAuthors()
        //{
        //    return Ok(_unitOfWork.Units.FindAll(b => b.Name.Contains("New Book"), new[] { "Author" }));
        //}

        [HttpGet("GetOrdered/{name}")]
        public IActionResult GetOrdered(string name)
        {
            return Ok(_unitOfWork.Units.FindAll(b => b.Name.Contains(name), null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne(Unit unit)
        {
            var book = _unitOfWork.Units.Add(unit);
            _unitOfWork.Complete();
            return Ok(book);
        }
    }
}