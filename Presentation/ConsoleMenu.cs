using System;
using Tarea_3_CRUD_ESTUDIANTES.Services;

namespace Tarea_3_CRUD_ESTUDIANTES.Presentation
{
    internal class ConsoleMenu
    {
        private readonly IEstudianteService _service;

        public ConsoleMenu(IEstudianteService service)
        {
            _service = service;
        }

        public void Run()
        {
            while (true)
            {
                MostrarMenuPrincipal();
            }
        }

        private void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("        CRUD DE ESTUDIANTES         ");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Crear estudiante");
            Console.WriteLine("2. Listar estudiantes");
            Console.WriteLine("3. Editar estudiante");
            Console.WriteLine("4. Eliminar estudiante");
            Console.WriteLine("0. Salir");
            Console.WriteLine("====================================");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            try
            {
                switch (opcion)
                {
                    case "1":
                        CrearEstudianteFlow();
                        break;
                    case "2":
                        ListarEstudiantesFlow();
                        break;
                    case "3":
                        EditarEstudianteFlow();
                        break;
                    case "4":
                        EliminarEstudianteFlow();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Pausar();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Error: {ex.Message}");
                Pausar();
            }
        }

        private void CrearEstudianteFlow()
        {
            Console.Clear();
            Console.WriteLine("=== Crear nuevo estudiante ===");

            Console.Write("Matrícula: ");
            string matricula = Console.ReadLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Carrera: ");
            string carrera = Console.ReadLine();

            Console.Write("Correo: ");
            string correo = Console.ReadLine();

            var creado = _service.CrearEstudiante(matricula, nombre, carrera, correo);

            Console.WriteLine();
            Console.WriteLine("Estudiante creado correctamente.");
            Console.WriteLine($"Id asignado: {creado.Id}");
            Pausar();
        }

        private void ListarEstudiantesFlow()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de estudiantes ===");

            var estudiantes = _service.ObtenerTodos();

            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                Pausar();
                return;
            }

            foreach (var est in estudiantes)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"Id:        {est.Id}");
                Console.WriteLine($"Matrícula: {est.Matricula}");
                Console.WriteLine($"Nombre:    {est.Nombre}");
                Console.WriteLine($"Carrera:   {est.Carrera}");
                Console.WriteLine($"Correo:    {est.Correo}");
            }

            Console.WriteLine("------------------------------------");
            Pausar();
        }

        private void EditarEstudianteFlow()
        {
            Console.Clear();
            Console.WriteLine("=== Editar estudiante ===");

            Console.Write("Ingrese el Id del estudiante a editar: ");
            string inputId = Console.ReadLine();

            if (!int.TryParse(inputId, out int id))
            {
                Console.WriteLine("Id inválido.");
                Pausar();
                return;
            }

            var actual = _service.ObtenerPorId(id);
            if (actual == null)
            {
                Console.WriteLine("No se encontró ningún estudiante con ese Id.");
                Pausar();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Deje el campo vacío si NO desea cambiar ese valor.");
            Console.WriteLine();

            Console.WriteLine($"Matrícula actual: {actual.Matricula}");
            Console.Write("Nueva matrícula: ");
            string nuevaMatricula = Console.ReadLine();

            Console.WriteLine($"Nombre actual: {actual.Nombre}");
            Console.Write("Nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();

            Console.WriteLine($"Carrera actual: {actual.Carrera}");
            Console.Write("Nueva carrera: ");
            string nuevaCarrera = Console.ReadLine();

            Console.WriteLine($"Correo actual: {actual.Correo}");
            Console.Write("Nuevo correo: ");
            string nuevoCorreo = Console.ReadLine();

            _service.ActualizarEstudiante(id, nuevaMatricula, nuevoNombre, nuevaCarrera, nuevoCorreo);

            Console.WriteLine();
            Console.WriteLine("Estudiante actualizado correctamente.");
            Pausar();
        }

        private void EliminarEstudianteFlow()
        {
            Console.Clear();
            Console.WriteLine("=== Eliminar estudiante ===");

            Console.Write("Ingrese el Id del estudiante a eliminar: ");
            string inputId = Console.ReadLine();

            if (!int.TryParse(inputId, out int id))
            {
                Console.WriteLine("Id inválido.");
                Pausar();
                return;
            }

            var actual = _service.ObtenerPorId(id);
            if (actual == null)
            {
                Console.WriteLine("No se encontró ningún estudiante con ese Id.");
                Pausar();
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Está a punto de eliminar al estudiante:");
            Console.WriteLine($"Id:        {actual.Id}");
            Console.WriteLine($"Matrícula: {actual.Matricula}");
            Console.WriteLine($"Nombre:    {actual.Nombre}");
            Console.WriteLine($"Carrera:   {actual.Carrera}");
            Console.WriteLine($"Correo:    {actual.Correo}");
            Console.WriteLine();
            Console.Write("¿Está seguro? (s/n): ");
            string confirmacion = Console.ReadLine();

            if (confirmacion?.ToLower() == "s")
            {
                _service.EliminarEstudiante(id);
                Console.WriteLine();
                Console.WriteLine("Estudiante eliminado correctamente.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Operación cancelada.");
            }

            Pausar();
        }

        private void Pausar()
        {
            Console.WriteLine();
            Console.Write("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}