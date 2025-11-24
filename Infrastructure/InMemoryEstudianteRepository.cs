using System;
using System.Collections.Generic;
using System.Linq;
using Tarea_3_CRUD_ESTUDIANTES.Domain;

namespace Tarea_3_CRUD_ESTUDIANTES.Infrastructure
{
internal class InMemoryEstudianteRepository : IEstudianteRepository
    {
        private readonly List<Estudiante> _estudiantes = new List<Estudiante>();
        private int _siguienteId = 1;

        public Estudiante Add(Estudiante estudiante)
        {
            estudiante.Id = _siguienteId++;
            _estudiantes.Add(estudiante);
            return estudiante;
        }

        public List<Estudiante> GetAll()
        {
            // Devolvemos una copia para evitar modificaciones externas directas
            return _estudiantes.ToList();
        }

        public Estudiante GetById(int id)
        {
            return _estudiantes.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Estudiante estudiante)
        {
            var existente = GetById(estudiante.Id);
            if (existente == null)
            {
                throw new InvalidOperationException("El estudiante no existe.");
            }

            existente.Matricula = estudiante.Matricula;
            existente.Nombre = estudiante.Nombre;
            existente.Carrera = estudiante.Carrera;
            existente.Correo = estudiante.Correo;
        }

        public void Delete(int id)
        {
            var estudiante = GetById(id);
            if (estudiante != null)
            {
                _estudiantes.Remove(estudiante);
            }
        }

        public Estudiante GetByMatricula(string matricula)
        {
            return _estudiantes.FirstOrDefault(e =>
                e.Matricula.Equals(matricula, StringComparison.OrdinalIgnoreCase));
        }
    }
}