using System.Collections.Generic;
using Tarea_3_CRUD_ESTUDIANTES.Domain;

namespace Tarea_3_CRUD_ESTUDIANTES.Services
{
    internal interface IEstudianteService
    {
        Estudiante CrearEstudiante(string matricula, string nombre, string carrera, string correo);
        List<Estudiante> ObtenerTodos();
        Estudiante ObtenerPorId(int id);
        void ActualizarEstudiante(int id, string nuevaMatricula, string nuevoNombre, string nuevaCarrera, string nuevoCorreo);
        void EliminarEstudiante(int id);
    }
}