using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListadoAlumnos
{
    public class Persona
    {
        public enum Curso
        {
            Atletismo,
            Voley,
            Futbol
        }

        public class Alumno
        {
            public Alumno(int id, string nombre, string apellido, Curso curso)
            {
                Id = id;
                Nombre = nombre;
                Apellido = apellido;
                Curso = curso;
            }

            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public Curso Curso { get; set; }


            public override string ToString()
            {
                return Id + ", " + Apellido + ", " + Nombre + ", " + Curso;
            }

        }
    }
}
