namespace Tarea_3_CRUD_ESTUDIANTES.Domain
{
    internal class Estudiante
    {
        public int Id { get; set; }               
        public string Matricula { get; set; }   
        public string Nombre { get; set; }
        public string Carrera { get; set; }
        public string Correo { get; set; }
    }
}