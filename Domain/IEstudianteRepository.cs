using System.Collections.Generic;

namespace Tarea_3_CRUD_ESTUDIANTES.Domain
{
    internal interface IEstudianteRepository
    {
        Estudiante Add(Estudiante estudiante);
        List<Estudiante> GetAll();
        Estudiante GetById(int id);
        void Update(Estudiante estudiante);
        void Delete(int id);
        Estudiante GetByMatricula(string matricula);
    }
}