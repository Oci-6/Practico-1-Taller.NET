using ClassLibraryPractico1;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>();
            string option;
            do
            {
                Menu();
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        personas = personas.Concat<Persona>(AgregarPersonas()).ToList();
                        break;
                    case "2":
                        ListarPersonas(personas, "", "");
                        break;
                    case "3":
                        Console.WriteLine("Filtrar por:");
                        Console.WriteLine("1- Nombre");
                        Console.WriteLine("2- CI");
                        string filtro = Console.ReadLine();
                        if (filtro == "1")
                        {
                            Console.WriteLine("Ingrese nombre de filtro");
                            ListarPersonas(personas, Console.ReadLine(), "");

                        }

                        if (filtro == "2")
                        {
                            Console.WriteLine("Ingrese CI de filtro");
                            ListarPersonas(personas, "", Console.ReadLine());
                        }

                        break;
                    case "4": break;
                    case null: break;
                }
                Console.Clear();
            } while (option != "4");

        }

        private static void ListarPersonas(List<Persona> personas, string filtroNom, string filtroCI)
        {
            if (filtroNom != "")
            {
                personas = personas.Where(x => x.nombre.StartsWith(filtroNom)).ToList();
            }
            if (filtroCI != "")
            {
                personas = personas.Where(x => x.documento.StartsWith(filtroCI)).ToList();
            }
            List<string> lista = personas.Select(x => "Nombre: " + x.nombre + ", Documento: " +
                    x.documento + ", F. Nacimiento: " + x.bornDate.ToString("dd-MM-yyyy") +
                    ", Edad: " + x.getEdad()).ToList();

            // Imprimimos
            lista.ForEach(x =>
            {
                Console.WriteLine(x);
            });
            Console.ReadLine();
        }

        private static List<Persona> AgregarPersonas()
        {
            string nombre = "";
            string fechaNac = "";
            string documento = "";
            string exit;
            List<Persona> personas = new List<Persona>();
            do
            {
                Console.WriteLine("Ingrese nombre");
                nombre = Console.ReadLine();
                Console.WriteLine("Ingrese fecha nacimiento (dd-mm-yyyy)");
                fechaNac = Console.ReadLine();
                Console.WriteLine("Ingrese documento");
                documento = Console.ReadLine();

                Persona person = new Persona(nombre, documento, DateTime.ParseExact(fechaNac, "dd-MM-yyyy", CultureInfo.InvariantCulture));
                personas.Add(person);


                Console.WriteLine("Salir(y/n)");
                exit = Console.ReadLine();

            } while (exit != "y");
            return personas;
        }

        private static void Menu()
        {
            Console.WriteLine("Bienvenido");
            Console.WriteLine("1- Agregar Personas");
            Console.WriteLine("2- Listar Personas");
            Console.WriteLine("3- Filtrar Personas");
            Console.WriteLine("4- Salir");
        }
    }
}
