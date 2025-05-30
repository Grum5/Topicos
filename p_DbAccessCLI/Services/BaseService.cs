using System.Threading.Tasks;
using System.Collections.Generic;
using dbAccessCLI.Models;

public interface IBaseService
{
    Task InicializarAsync();
    Task AgregarAlumnoAsync(Alumno alumno);
    Task<List<Alumno>> LeerAlumnosAsync();
    Task EditarAlumnoAsync(string matricula, Alumno nuevoAlumno);
    Task EliminarAlumnoAsync(string matricula);
}
