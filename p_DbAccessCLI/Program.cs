using dbAccessCLI.Controllers;
using dbAccessCLI.Models;
using dbAccessCLI.Services;
using System.Globalization;

namespace dbAccessCLI;

class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        IBaseService servicioActual = await SeleccionarServicioAsync();
        var controlador = new AlumnoController(servicioActual);

        await controlador.InicializarAsync();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Menú Principal ===");
            Console.WriteLine("1. Agregar alumno");
            Console.WriteLine("2. Eliminar alumno");
            Console.WriteLine("3. Editar alumno por matrícula");
            Console.WriteLine("4. Ver alumnos");
            Console.WriteLine("5. Cambiar motor de base de datos");
            Console.WriteLine("0. Salir");

            Console.Write("\nSelecciona una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    var alumnoNuevo = LeerDatosAlumno();
                    await controlador.AgregarAlumnoAsync(alumnoNuevo);
                    break;

                case "2":
                    Console.Write("Matrícula del alumno a eliminar: ");
                    var matriculaDel = Console.ReadLine();
                    await controlador.EliminarAlumnoAsync(matriculaDel!);
                    break;

                case "3":
                    Console.Write("Matrícula del alumno a editar: ");
                    var matriculaEdit = Console.ReadLine();
                    var datosEdit = LeerDatosAlumno();
                    await controlador.EditarAlumnoAsync(matriculaEdit!, datosEdit);
                    break;

                case "4":
                    var alumnos = await controlador.ObtenerAlumnosAsync();
                    Console.WriteLine("\n=== Alumnos Registrados ===");
                    foreach (var a in alumnos)
                    {
                        Console.WriteLine($"{a.Matricula} | {a.Nombre} | {a.Carrera} | Semestre: {a.Semestre} | Inscrito: {(a.Inscrito ? "Sí" : "No")}");
                    }
                    break;

                case "5":
                    servicioActual = await SeleccionarServicioAsync();
                    controlador.CambiarServicio(servicioActual);
                    await controlador.InicializarAsync();
                    break;

                case "0":
                    Console.WriteLine("Saliendo...");
                    return;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }
    }

    static async Task<IBaseService> SeleccionarServicioAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Selección de base de datos ===");
            Console.WriteLine("1. PostgreSQL");
            Console.WriteLine("2. MariaDB");
            Console.Write("Selecciona el motor de base de datos: ");
            var seleccion = Console.ReadLine();

            switch (seleccion)
            {
                case "1":
                    return new PostgresService();
                case "2":
                    return new MariaDbService();
                default:
                    Console.WriteLine("Selección inválida. Intenta nuevamente.");
                    await Task.Delay(1000);
                    break;
            }
        }
    }

    static Alumno LeerDatosAlumno()
    {
        Console.Write("Matrícula: ");
        string matricula = Console.ReadLine()!;
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine()!;
        Console.Write("Carrera: ");
        string carrera = Console.ReadLine()!;
        Console.Write("Semestre: ");
        int semestre = int.Parse(Console.ReadLine()!);
        Console.Write("¿Está inscrito? (s/n): ");
        bool inscrito = Console.ReadLine()!.ToLower() == "s";

        return new Alumno
        {
            Matricula = matricula,
            Nombre = nombre,
            Carrera = carrera,
            Semestre = semestre,
            Inscrito = inscrito
        };
    }
}
