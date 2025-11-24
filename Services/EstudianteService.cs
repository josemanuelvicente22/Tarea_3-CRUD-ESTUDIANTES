using System;
using System.Collections.Generic;
using Tarea_3_CRUD_ESTUDIANTES.Domain;

namespace Tarea_3_CRUD_ESTUDIANTES.Services
{
    internal class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _repository;

        public EstudianteService(IEstudianteRepository repository)
        {
            _repository = repository;
        }

        public Estudiante CrearEstudiante(string matricula, string nombre, string carrera, string correo)
        {
            if (string.IsNullOrWhiteSpace(matricula))
                throw new ArgumentException("La matrícula es obligatoria.");

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            // Validar matrícula única
            var existente = _repository.GetByMatricula(matricula);
            if (existente != null)
                throw new InvalidOperationException("Ya existe un estudiante con esa matrícula.");

            var estudiante = new Estudiante
            {
                Matricula = matricula,
                Nombre = nombre,
                Carrera = carrera,
                Correo = correo
            };

            return _repository.Add(estudiante);
        }

        public List<Estudiante> ObtenerTodos()
        {
            return _repository.GetAll();
        }

        public Estudiante ObtenerPorId(int id)
        {
            return _repository.GetById(id);
        }

        public void ActualizarEstudiante(int id, string nuevaMatricula, string nuevoNombre, string nuevaCarrera, string nuevoCorreo)
        {
            var estudiante = _repository.GetById(id);
            if (estudiante == null)
                throw new InvalidOperationException("El estudiante no existe.");

            if (!string.IsNullOrWhiteSpace(nuevaMatricula))
            {
                var otroConMismaMatricula = _repository.GetByMatricula(nuevaMatricula);
                if (otroConMismaMatricula != null && otroConMismaMatricula.Id != id)
                    throw new InvalidOperationException("Ya existe otro estudiante con esa matrícula.");

                estudiante.Matricula = nuevaMatricula;
            }

            if (!string.IsNullOrWhiteSpace(nuevoNombre))
                estudiante.Nombre = nuevoNombre;

            if (!string.IsNullOrWhiteSpace(nuevaCarrera))
                estudiante.Carrera = nuevaCarrera;

            if (!string.IsNullOrWhiteSpace(nuevoCorreo))
                estudiante.Correo = nuevoCorreo;

            _repository.Update(estudiante);
        }

        public void EliminarEstudiante(int id)
        {
            var estudiante = _repository.GetById(id);
            if (estudiante == null)
                throw new InvalidOperationException("El estudiante no existe.");

            _repository.Delete(id);
        }
    }
}