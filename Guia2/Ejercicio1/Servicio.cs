using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    public class Servicio
    {
        List<Persona> personas = new List<Persona>();

        public Servicio()
        {
            //Un constructor sin parametros sirve para inicializar la lista
            //Lo puedo dejar vacio si inicializo la lista en la declaracion
        }

        public bool AgregarPersona(Persona p)
        {
            Persona personaExistente = verPersonaPorDNI(p.dni);
            if(personaExistente == null)
            {
                personas.Add(p);
                return true;
            }
            return false;
        }

        public int VerCantidadPersonas()
        {
            return personas.Count;
        }

       public Persona verPersona (int n)
       {
            if (n>=0 && n < personas.Count)
            {
                return personas[n];
            }
            else
            {
                return null;
            }
       }

       public Persona verPersonaPorDNI(int dni)
       {
            int i = -1;
            int n = 0;
            while (i==-1 && n < personas.Count)
            {
                if (personas[n].dni == dni)
                {
                    i = n;
                }
                n++;
            }

            if (i > -1)
                return personas[i];
            else
            {
                return null;
            }

        }

        public void EliminarPersona(Persona persona)
        {
            Persona existe = verPersonaPorDNI(persona.dni);
            if (existe != null)
            {
                personas.Remove(persona);
            }

        }
    }
}
