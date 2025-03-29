using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET: api/Empleado
        [HttpGet]
        public IEnumerable<EmpleadoDTO> Get()
        {
            return _empleadoService.GetEmpleados();
        }

        // GET api/Empleado/5
        [HttpGet("{id}")]
        public EmpleadoDTO Get(int id)
        {
            return _empleadoService.GetEmpleadoById(id);
        }

        // POST api/Empleado
        [HttpPost]
        public void Post([FromBody] EmpleadoDTO empleado)
        {
            _empleadoService.AddEmpleado(empleado);
        }

        // PUT api/Empleado
        [HttpPut]
        public void Put([FromBody] EmpleadoDTO empleado)
        {
            _empleadoService.UpdateEmpleado(empleado);
        }

        // DELETE api/Empleado/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _empleadoService.DeleteEmpleado(id);
        }
    }
}