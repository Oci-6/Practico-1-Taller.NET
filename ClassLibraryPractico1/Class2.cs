using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPractico1
{
    public class Persona
    {
        public string nombre { get; set; }
        public string documento { get; set; }
        public DateTime bornDate { get; set; }

        public Persona(string Nombre, string Documento, DateTime BornDate)
        {
            nombre = Nombre;
            documento = Documento;
            bornDate = BornDate;
        }

        public int getEdad()
        {
            int edad = DateTime.Today.Year - bornDate.Year;
            if (bornDate.AddYears(edad)> DateTime.Today)
                edad--;
            return edad;
        }
    }
}
