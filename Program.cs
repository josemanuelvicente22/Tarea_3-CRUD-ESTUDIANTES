using Tarea_3_CRUD_ESTUDIANTES.Domain;
using Tarea_3_CRUD_ESTUDIANTES.Infrastructure;
using Tarea_3_CRUD_ESTUDIANTES.Presentation;
using Tarea_3_CRUD_ESTUDIANTES.Services;

namespace CrudEstudiantes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Composición de dependencias 
            IEstudianteRepository repository = new InMemoryEstudianteRepository();
            IEstudianteService service = new EstudianteService(repository);
            var menu = new ConsoleMenu(service);

            menu.Run();
        }
    }
}