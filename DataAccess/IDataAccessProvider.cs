using WebService.Models;

namespace WebService.DataAccess
{
    /// <summary>
    /// Interface de acceso a metodos de persistencia
    /// </summary>
    public interface IDataAccessProvider
    {
        List<catalumno> GetAlumnos();
        public catalumno GetAlumnoById(int id);
        public void AddAlumno(catalumno alumno);
    }
}
