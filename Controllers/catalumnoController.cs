using Microsoft.AspNetCore.Mvc;
using WebService.DataAccess;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    public class catalumnoController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        public catalumnoController(IDataAccessProvider dataAccessProvider) { 
            _dataAccessProvider = dataAccessProvider;
        }


        [HttpGet]
        public IEnumerable<catalumno> Get()
        {
            return _dataAccessProvider.GetAlumnos();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var alumno = _dataAccessProvider.GetAlumnoById(id);

            if (alumno == null)
            {
                return NotFound(); // Devuelve un error 404 si el registro no se encuentra
            }

            return Ok(alumno); // Devuelve el registro encontrado en la respuesta HTTP 200 OK
        }

        [HttpPost]
        public IActionResult Post([FromBody] catalumno alumno)
        {
            if (alumno == null)
            {
                return BadRequest(); // Devuelve un error 400 si el objeto de alumno es nulo
            }

            _dataAccessProvider.AddAlumno(alumno); // Inserta el nuevo alumno en la base de datos

            return CreatedAtAction(nameof(Get), new { id = alumno.id }, alumno);
            // Devuelve una respuesta HTTP 201 Created con el alumno insertado y la ubicación de la nueva entidad en
            // el encabezado Location
        }

    }
}
