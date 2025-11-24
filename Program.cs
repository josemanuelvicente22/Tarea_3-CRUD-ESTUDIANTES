using System;
using Tarea_3_CRUD_ESTUDIANTES.Domain;
using Tarea_3_CRUD_ESTUDIANTES.Infrastructure;
internal class Program
{
    private static void Main(string[] args)
    {
        
        /*Aquí estoy probando el primer feature que será el punto de inicio para
        los demás features*/

        IEstudianteRepository repository = new InMemoryEstudianteRepository();

        var estudianteDemo = new Estudiante
        {
            Matricula = "2023-1073",
            Nombre = "José Manuel Vicente Checo",
            Carrera = "Desarrollo de Software",
            Correo = "20231073@itla.edu.do"
        };

        repository.Add(estudianteDemo);

        var todos = repository.GetAll();

        Console.WriteLine("====================================");
        Console.WriteLine("       MODELO DE ESTUDIANTES     ");
        Console.WriteLine("====================================");
        Console.WriteLine($"Cantidad de estudiantes registrados: {todos.Count}");
        Console.WriteLine();

        foreach (var est in todos)
        {
            Console.WriteLine($"Id: {est.Id}  -  {est.Nombre} ({est.Matricula})");
        }

        Console.WriteLine();
        Console.WriteLine("Esta es solo una demo de la primera feature (modelo + repositorio).");
        Console.WriteLine("Más adelante agregaremos el CRUD completo y el menú.");
        Console.WriteLine();
        Console.Write("Presione cualquier tecla para salir...");
        Console.ReadKey();

    }
}