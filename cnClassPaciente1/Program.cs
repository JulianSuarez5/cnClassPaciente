using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnClassPaciente1
{
    class Paciente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroSeguroSocial { get; set; }
        public List<DateTime> Citas { get; set; } = new List<DateTime>();

        public Paciente(string nombre, string apellido, string numeroSeguroSocial)
        {
            Nombre = nombre;
            Apellido = apellido;
            NumeroSeguroSocial = numeroSeguroSocial;
        }

        public void ProgramarCita(DateTime fecha)
        {
            Citas.Add(fecha);
        }

        public bool TieneCita(DateTime fecha)
        {
            return Citas.Contains(fecha);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Bienvenido al sistema de citas médicas");
            string respuesta;
            List<Paciente> pacientes = new List<Paciente>();

            do
            {
                Console.WriteLine("Ingrese el nombre del paciente:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido del paciente:");
                string apellido = Console.ReadLine();

                Paciente paciente = new Paciente(nombre, apellido, "12345");

                Console.WriteLine("Ingrese la fecha de la cita (DD/MM/AA):");
                DateTime fechaCita = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la hora de la cita (hh:mm):");
                string horaCita = Console.ReadLine();

                DateTime fechaConHora = fechaCita.Add(TimeSpan.Parse(horaCita));

                paciente.ProgramarCita(fechaConHora);

                pacientes.Add(paciente);

                Console.WriteLine("Si no deseas programar otra cita, te mostrara las citas que tiene el paciente que acabas de ingresar");

                Console.WriteLine("¿Desea programar otra cita? (S/N)");
                respuesta = Console.ReadLine();

            } while (respuesta.ToUpper() == "S");

            Console.WriteLine("Registro de citas:");
            for (int i = 0; i < pacientes.Count; i++)
            {
                Console.WriteLine($"Paciente: {pacientes[i].Nombre} {pacientes[i].Apellido}");
                Console.WriteLine($"Fecha de la cita: {pacientes[i].Citas[0]}");
            }

            Console.ReadKey();
        }
    }
}

