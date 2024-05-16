using WebService.DataAccess;
using WebService.Models;

public class DataAccessProvider : IDataAccessProvider
{
    public readonly PostgreSqlContext _context;

    public DataAccessProvider(PostgreSqlContext context)
    {
        _context = context;
    }

    public List<catalumno> GetAlumnos()
    {
        return _context.catalumno.ToList();
    }


    public catalumno GetAlumnoById(int id)
    {
        // Utiliza el contexto de base de datos para buscar el alumno por su ID
        return _context.catalumno.FirstOrDefault(a => a.id == id);
    }

    public void AddAlumno(catalumno alumno)
    {
        _context.catalumno.Add(alumno);
        _context.SaveChanges();
    }

}
