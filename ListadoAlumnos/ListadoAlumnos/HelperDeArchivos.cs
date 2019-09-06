using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ListadoAlumnos.Persona;

namespace ListadoAlumnos
{

    static class HelperDeArchivos
    {
        public static void CargarArchivo(string NombreDeArchivo, List<Alumno> listaDeAlumnos)
        {
            StreamWriter writer = new StreamWriter(File.Open(NombreDeArchivo, FileMode.Create));
            writer.Write("Id;Nombre;Apellido;Curso\n");
            foreach (Alumno A in listaDeAlumnos)
            {
                writer.Write(A.Id + ";" + A.Nombre + ";" + A.Apellido + ";" + A.Curso + "\n");
            }
            writer.Close();
        }


    }
}
