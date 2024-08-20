using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWeatherForescast
{
    using Microsoft.Win32;
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Reflection.Emit;
    using System.Runtime.ConstrainedExecution;
    using System.Security.Cryptography;

    //Soy consciente de que en los dos ejercicios anteriores logre un resultado óptimo y eficaz, teniendo todos los resultados esperados 
    //con todas las validaciones correspondientes para que los programas no admitan ningún error / resultado inesperado. En este ejercicio
    //me di cuenta que todavía tengo mucho que aprender. Pude lograr que el programa funcione, pero también soy consciente que podría
    //estar mejor estructurado, con una lógica no tan compleja, y una utilización mas eficiente de los modificadores de acceso.
    //Lo que si destaco es que en cada ejercicio aprendo muchisimo, es un camino largo que estoy transitandolo con muchas ganas!

    //    //    Escenario: Weather Forecast Súper Mejorado(para una Estación Meteorológica)

    //    Utilizando el escenario del ejercicio anterior como base, deberás ahora reutilizar y reformar el código lo más que puedas para utilizar clases! 
    //Para ello deberás cumplir con las siguientes observaciones:

    //Observaciones:
    //En principio, todas las funciones de tu algoritmo deben ser métodos de clases.Puede que tengas que definir varias clases diferentes para funcionalidades diferentes, pero no deben quedar funciones sueltas. Puede que no utilices todas las funciones o código que hayas definido en tu escenario anterior, como el menú, por ej.
    //Deberás definir las clases que sean necesarias, con campos, propiedades, métodos, y modificadores de acceso que creas conveniente.
    //No es necesario que el proyecto sea de tipo consola, puedes usar si quieres una librería de clases, con todas las clases y funcionalidades necesarias para que yo lo implemente en otro proyecto, de ser necesario. (No es necesario el menú!).
    //Puedes definir más clases si así lo prefieres, no necesariamente deben estar sólo las clases que se piden en los requerimientos.Lo mismo con las propiedades y los métodos.Puedes definir más si así lo prefieres.
    //Deberás compartir todo en un repositorio! No más archivos ni texto para subir!
    //Bien, ahora vamos con los requerimientos (algunos nuevos!):

    //Requerimientos:
    //Se necesita saber ahora quién registró las temperaturas en qué día, sabiendo que en la estación está una persona presente en todo momento, pero esa persona puede ser un Profesional o bien un Pasante.No tienen mucha diferencias salvo que el pasante tiene un Número de Legajo, y el profesional tiene un Número de Matrícula que lo habilita.En total debería haber 3 pasantes y 3 profesionales, cubriendo turnos de 8 horas, y siempre intercalando Pasante-Profesional.Define las clases que creas necesario con sus respectivas properties. No es necesario que tenga métodos.
    //Deberás definir una clase llamada RegistroTemperatura, que contendrá la información de un registro de temperatura.Esta clase será usada ahora en la matriz. Estas podrían ser algunas properties:
    //-- Temperatura registrada
    //-- Persona de Turno
    //-- Fecha de registro
    //-- Hora de registro
    //Las colecciones deben ir en una clase llamada EstacionMeteorologica, con los siguientes métodos:
    //-- Un método llamado RegistrarTemperatura, que recibirá un objeto de tipo RegistroDemperatura, para ser almacenado en la matriz.
    //-- Un método VerTemperaturas, con parámetro para elegir qué colección ver.Este método puede devolver sólo las temperaturas.
    //-- Utiliza el constructor para la carga inicial de la matriz, si usaste carga automática.
    //-- Utiliza un método de carga para la matriz, si le pediste al usuario que cargue manualmente.
    //-- Puedes agregar algunas funciones anteriores como métodos de esta clase, como por ejemplo "Ver temperatura de un día específico". Tu eliges las que creas conveniente que pueden ir en esta clase.
    //-- Recuerda que ahora la matriz ya no es de tipo int, sino que almacena objetos de la clase nueva Registro! Modificalo!
    //Algunas funciones de cálculo de tu programa pueden ir en una clase estática, de nombre CalculoTemperaturas.Añade las funciones que creas convenientes que están relacionadas a algún tipo de cálculo del programa, como por ejemplo,
    //CalcularTemperaturaPromedio o similares.Solo recuerda que estos métodos harán cálculo sobre algún parámetro que reciban de tipo de la colección seguramente. Puedes hacer uso de esta clase en EstaciónMeteorológica si así lo deseas, o bien dejarme a mi que la utilice 
    //    si se te complica relacionarlas.Recuerda que esta clase será estática y la de estación no.
    class Program
    {
        static void Main(string[] args)
        {
            // Inicializa la estación meteorológica con una matriz de 5x7.
            EstacionMeteorologica estacion = new EstacionMeteorologica();
            Console.WriteLine("Calendario de temperaturas:");
            estacion.MostrarCalendario();
            // Mostrar todas las temperaturas registradas
            Console.WriteLine("Todas las temperaturas registradas:");
            estacion.VerTemperaturas();
            Console.WriteLine();
            // Ver la temperatura de un día específico (por ejemplo, en la semana 2)
            Console.WriteLine("Temperaturas registradas en la semana 3, dia 2:");
            estacion.VerTemperaturaDiaEspecifico(2, 1);
            Console.WriteLine();
            // Calcular la temperatura promedio usando la clase CalculoTemperaturas
            double promedio = CalculoTemperaturas.CalcularPromedio(estacion.ObtenerRegistros());
            Console.WriteLine($"La temperatura promedio es: {promedio}");

            // Calcular la temperatura máxima usando la clase CalculoTemperaturas
            double maxima = CalculoTemperaturas.CalcularMaxima(estacion.ObtenerRegistros());
            Console.WriteLine($"La temperatura máxima registrada es: {maxima}");
        }
    }
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tipo { get; set; }

        protected Persona(string nombre, string apellido, string tipo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Tipo = tipo;
        }
    }
    public class Profesional : Persona
    {
        public int Matricula { get; set; }
        public Profesional(int matricula, string nombre, string apellido) : base(nombre, apellido, "Profesional")
        {
            Matricula = matricula;
        }
    }
    public class Pasante : Persona
    {
        public int Legajo { get; set; }
        public Pasante(int legajo, string nombre, string apellido) : base(nombre, apellido, "Pasante")
        {
            Legajo = legajo;
        }
    }
    public class RegistroTemperatura
    {
            public double Temperatura { get; set; }
            public Persona PersonaDeTurno { get; set; }
            public DateTime FechaRegistro { get; set; }
            public TimeSpan HoraRegistro { get; set; }
        public RegistroTemperatura(double temperatura, Persona personaDeTurno, DateTime fechaRegistro, TimeSpan horaRegistro)
        {
            Temperatura = temperatura;
            PersonaDeTurno = personaDeTurno;
            FechaRegistro = fechaRegistro;
            HoraRegistro = horaRegistro;
        }
        public override string ToString()
        {
            return $"TEMPERATURA: {Temperatura}°C, Registrada por el {PersonaDeTurno.Tipo} {PersonaDeTurno.Nombre} {PersonaDeTurno.Apellido}, Fecha: {FechaRegistro.ToString("dd/MM/yyyy")}, Hora: {HoraRegistro}";
        }
    }
    public class EstacionMeteorologica
    {
        private RegistroTemperatura[,] registros;
        private int filas = 5;
        private int columnas = 7;
        public EstacionMeteorologica()
        {
            registros = new RegistroTemperatura[5, 7];
            CargaAutomatica();
        }
        private void CargaAutomatica()
        {
            Persona[] personas =
            {
                new Profesional(123,"Pedro","Gomez"),
                new Pasante (1, "Alejandro", "Gonzalez"),
                new Profesional (234, "Maxi", "Perez"),
                new Pasante (2, "Lautaro", "Diaz"),
                new Profesional (345, "Luciana", "Lopez"),
                new Pasante (3, "Camila", "Fernandez")
            };

            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    registros[i, j] = new RegistroTemperatura
                    (
                    random.Next(-10, 40),
                    personas[(i + j) % 6],
                    DateTime.Now.Date.AddDays(-j),
                    new TimeSpan(random.Next(0, 24), 0, 0)
                    );
                }
            }
        }
        public void RegistrarTemperatura(RegistroTemperatura registro, int fila, int columna)
        {
            if (fila < filas && columna < columnas)
            {
                registros[fila, columna] = registro;
            }
            else
            {
                Console.WriteLine("Índice fuera de rango.");
            }
        }
        public void VerTemperaturas()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.WriteLine($"Semana {i + 1}, Día {j + 1}: {registros[i, j]}");
                }
            }
        }
        public Persona ObtenerPersonaPorTurno(int fila, int columna)
        {
            // Lógica para intercalar entre Pasante y Profesional
            // Ejemplo simple:
            if ((fila + columna) % 2 == 0)
            {
                return new Profesional(columna + 1, "Profesional", $"Pro{columna + 1}");

            }
            else
            {
                return new Pasante(columna + 1,"Pasante", $"P{columna + 1}");
            }
        }
        public void VerTemperaturaDiaEspecifico(int semana, int dia)
        {
            if (semana >= 0 && semana < 5 && dia >= 0 && dia < 7)
            {
                var registro = registros[semana, dia];
                Console.WriteLine($"Hora: {registro.HoraRegistro}, Temperatura: {registro.Temperatura}, Persona: {registro.PersonaDeTurno.Nombre}, Tipo: {registro.PersonaDeTurno.Tipo}");
            }
            else
            {
                throw new ArgumentOutOfRangeException("Día o semana fuera de rango.");
            }
        }
        public List<RegistroTemperatura> ObtenerRegistros()
        {
            List<RegistroTemperatura> matriz = new List<RegistroTemperatura>();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    matriz.Add(registros[i, j]);
                }
            }
            return matriz;
        }
        public void MostrarCalendario()
        {
            Console.WriteLine("------------------------------------------------------");
            // Se imprimen los días de la semana.
            string[] diasSemana = { "DOM", "LUN", "MAR", "MIÉ", "JUE", "VIE", "SÁB" };
            foreach (string diaSemana in diasSemana)
            {
                Console.Write(diaSemana + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
            // Se recorren todos los días y semanas.
            for (int fila = 0; fila < 5; fila++)
            {
                for (int columna = 0; columna < 7; columna++)
                {
                    if (registros[fila, columna] != null)
                    {
                        Console.Write($"({registros[fila, columna].Temperatura}°)\t");
                    }
                    else
                    {
                        Console.Write("\t");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------------");
        }
        public RegistroTemperatura[] CargarRegistrosManualmente()
        {
            RegistroTemperatura[] registros = new RegistroTemperatura[5 * 7];
            int index = 0;

            for (int semana = 0; semana < 5; semana++)
            {
                for (int dia = 0; dia < 7; dia++)
                {
                    Console.WriteLine($"Ingrese la información para la semana {semana + 1}, día {dia + 1}:");
                    Console.Write("Hora de registro (HH:mm): ");
                    string horaRegistroString = Console.ReadLine();
                    TimeSpan horaRegistro;
                    if (TimeSpan.TryParseExact(horaRegistroString, "h\\:mm", null, System.Globalization.TimeSpanStyles.None, out horaRegistro))
                    {
                        // horaRegistro ahora contiene la hora de registro como un objeto TimeSpan
                    }
                    else
                    {
                        Console.WriteLine("Formato de hora incorrecto. Debe ser HH:mm");
                    }
                    Console.Write("Temperatura: ");
                    double temperatura;
                    bool esValido;
                    do
                    {
                        esValido = double.TryParse(Console.ReadLine(), out temperatura);
                        if (!esValido)
                        {
                            Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
                        }
                    } while (!esValido);

                    Console.Write("Persona de turno (Legajo/Matricula, Nombre, Apellido, Tipo): ");
                    string[] personaInfo = Console.ReadLine().Split(',');
                    int legajoMatricula = int.Parse(personaInfo[0].Trim());
                    string nombre = personaInfo[1].Trim();
                    string apellido = personaInfo[2].Trim();
                    string tipo = personaInfo[3].Trim();

                    Persona personaDeTurno;
                    if (tipo == "Profesional")
                    {
                        personaDeTurno = new Profesional(legajoMatricula, nombre, apellido);
                    }
                    else if (tipo == "Pasante")
                    {
                        personaDeTurno = new Pasante(legajoMatricula, nombre, apellido);
                    }
                    else
                    {
                        throw new ArgumentException("Tipo de persona no válido");
                    }

                    DateTime fechaRegistro = DateTime.Now; // Asigna la fecha actual
                    RegistroTemperatura registro = new RegistroTemperatura(temperatura, personaDeTurno, fechaRegistro, horaRegistro);
                    registros[index] = registro;
                    index++;
                }
            }

            return registros;
        }
    }
    public static class CalculoTemperaturas
    {
        public static double CalcularPromedio(List<RegistroTemperatura> temperaturas)
        {
            return temperaturas.Average(t => t.Temperatura);
        }

        public static double CalcularMaxima(List<RegistroTemperatura> temperaturas)
        {
            return temperaturas.Max(t => t.Temperatura);
        }

        public static double CalcularMinima(List<RegistroTemperatura> temperaturas)
        {
            return temperaturas.Min(t => t.Temperatura);
        }
    }
}
