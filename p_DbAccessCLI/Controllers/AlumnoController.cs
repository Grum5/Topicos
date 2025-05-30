using dbAccessCLI.Models;
using dbAccessCLI.Services;

namespace dbAccessCLI.Controllers;

public class AlumnoController
{
    private IBaseService _service;

    public AlumnoController(IBaseService service) {

        _service = service;
    }

    public void CambiarServicio(IBaseService nuevoServicio) {

        _service = nuevoServicio;
    }

    public async Task InicializarAsync() {

        await _service.InicializarAsync();
    }

    public async Task AgregarAlumnoAsync(Alumno alumno) {

        await _service.AgregarAlumnoAsync(alumno);
    }

    public async Task<List<Alumno>> ObtenerAlumnosAsync() {

        return await _service.LeerAlumnosAsync();
    }

    public async Task EditarAlumnoAsync(string matricula, Alumno nuevoAlumno) {

        await _service.EditarAlumnoAsync(matricula, nuevoAlumno);
    }

    public async Task EliminarAlumnoAsync(string matricula) {
        
        await _service.EliminarAlumnoAsync(matricula);
    }
}
