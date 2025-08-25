using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class Persona
    {
        public int dni { get; set; }
        public string nombre { get; set; }

        public Persona (int dni, string nombre)
        {
           this.dni = dni;
            this.nombre = nombre;
        }

        public string Describir()
        {
            return $"DNI: {dni} - Nombre: {nombre}";
        }
    }
}
