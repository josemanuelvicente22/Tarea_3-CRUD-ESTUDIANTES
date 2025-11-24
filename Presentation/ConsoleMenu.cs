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
            Console.WriteLine("2. Listar estudiantes (no implementado aún)");
            Console.WriteLine("3. Editar estudiante (no implementado aún)");
            Console.WriteLine("4. Eliminar estudiante (no implementado aún)");
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
                    case "3":
                    case "4":
                        Console.WriteLine("Esta opción se implementará en las siguientes features.");
                        Pausar();
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

        private void Pausar()
        {
            Console.WriteLine();
            Console.Write("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}