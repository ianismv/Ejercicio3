using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Collections;
    using System.Security.Cryptography;

    //Este ejercicio obligatorio me presento muchos desafíos. Tuve que aprender a amañarme como pude, probando muchas ejecuciones hasta que salgan los resultados que esperé.
    //La conclusión que me llevo con este ejercicio es que, por más que no entendamos una lógica desde 0 o tengamos resultados no esperados,
    //podemos utilizar todas las herramientas aprendidas hasta el momento para probar nuevos métodos o formas de hacer las cosas. 
    //Al probar varias ejecuciones y distintas formas de hacer las cosas para que termine funcionando mi código, terminé aprendiendo la lógica que no entendía en un principio,
    //y así poder reutilizar los conocimientos para los demás metodos.
    //Entiendo que todavía me queda mucho por aprender, pero me quedo con el hecho de que pude obtener los resultados que esperé.

    //Cosas que aprendí:
    //El manejo de métodos y funciones, logro que mi Main sea muchísimo mas corto.
    //La iteración del Menu como yo queria me costo bastante, hasta que se me ocurrio que, dadas ciertas condiciones, podria llamar al mismo metodo para que se ejecute de nuevo(Dentro del mismo procedimiento).
    //Al principio, usaba procedimientos sin parámetros. Luego entendí que todo el ejercicio tenía que trabajar bajo los mismos calendarios. Los metodos funcionaban igual, pero con distintos valores.
    //Tener estas complicaciones me ayudo a entender los parametros por referencia, la declaración de variables tanto del global como de cada procedimiento/función.
    //Hay algunos recorridos de matriz que me costaron mucho. Descubrí que para algunos necesitaban mas de un parametro, ya que todo el codigo trabaja con mas de un calendario(Calendario de días y Calendario de temperaturas).
    //Aunque descubrí esto por mi cuenta, la lógica de recorridos me sigue costando un poco, tuve que investigar externamente para lograrlo y probrar MUCHAS formas de recorrer y trabajar sobre el recorrido.
    //El recorrido de dias posteriores fue de lo que mas me costó entender. Todavía no entiendo mucho la lógica jaja pero lo importante es que pude lograr los resultados que esperaba.
    
    
    //Crear una aplicación simple de consola para el siguiente escenario:

    //Escenario: Weather Forecast Mejorado(para una Estación Meteorológica)

    //Una estación meteorológica necesita gestionar y procesar datos de temperatura del interior de la cabina para un mes completo (31 días). Los datos deben registrarse en una colección tipo matriz, donde las filas representan las semanas, y las columnas los días. Se requiere implementar varias funcionalidades para gestionar y procesar estos datos.

    //Para este ejercicio, se deben utilizar:
    //Una  5 x 7 para almacenar las temperaturas diarias del mes.
    //Una  para almacenar las temperaturas promedio de cada semana.
    //Una  para almacenar las temperaturas por encima de un cierto umbral.
    //Requerimientos:
    //Implementar un algoritmo principal que permita la carga inicial de todas las temperaturas del mes, 31 días (Puedes pedirle al usuario que cargue día por día, o bien simular la carga total de temperaturas). No importa si sobran lugares en la matriz al final, sólo deberemos usar 31 lugares.
    //Luego mostrar al usuario un menú con las opciones (Ver siguiente). El usuario elije una opción y luego se le da la opción de elegir si quiere otra opción o salir, y así sucesivamente hasta que elija salir.
    //Opción para ver temperatura de un día específico: Aquí vamos a usar lo del escenario anterior pero cambiándole el mensaje. Basándose en la temperatura del día elegido, la aplicación debería mostrar la temperatura y un mensaje:
    // Si la temperatura es inferior a 0, mostrar "Hizo mucho frío."

    // Si la temperatura está entre 0 y 20, mostrar "El clima estaba fresco."

    // Si la temperatura es superior a 20, mostrar "Hizo calor afuera."
    //Opción para calcular y ver temperaturas promedios de cada semana. Aquí debes usar otra colección para el almacenamiento.
    //Opción para encontrar y ver temperaturas por encima de 20° (Umbral). Aquí también debes usar otra colección para el almacenamiento.
    //Opción para ver la temperatura promedio del mes. Aquí puedes usar la matriz principal o la colección de promedios de cada semana.
    //Opción para ver la temperatura más alta. Aquí debes usar la matriz principal.
    //Opción para ver la temperatura más baja. Aquí debes usar la matriz principal.
    //Opción para ver el pronóstico de 5 días posteriores al mes. Aquí también debes implementar lo del ejercicio anterior, sólo que puedes mejorar el código colocando la funcionalidad en una opción aparte.
    //Opción para Salir.
    //Implementar una función para añadir las temperaturas diarias.
    //Implementar una función para calcular las temperaturas promedio de cada semana y almacenarlas en una colección.
    //Implementar una función para encontrar las temperaturas por encima de un umbral (20°) y almacenarlas en una colección.
    //Implementar una función para calcular la temperatura promedio del mes.
    //Implementar una función para encontrar la temperatura más alta y la más baja.
    //Utilizar una matriz 5x7 para almacenar las temperaturas diarias del mes.
    //Utilizar una colección adecuada para almacenar las temperaturas promedio de cada semana.
    //Utilizar una colección que creas más conveniente para almacenar las temperaturas por encima de un cierto umbral.
    class Program
    {
        static void Main()
        {
            Console.WriteLine("¡Bienvenido al segundo ejercicio obligatorio del Bootcamp 3.0 de Devlights!");
            Console.WriteLine();
            Console.WriteLine("WEATHER FORECAST MEJORADO (PARA UNA ESTACIÓN METEREOLÓGICA)");
            Console.WriteLine("------------------------------------------------------");
            //Inicio el calendario que, tal como se pidió, comprenda las 5 semanas con sus respectivos 7 días, teniendo en cuenta la fecha actual.
            int[,] calendario = IniciarCalendario();
            double[,] calentemp = new double[5, 7];
            MostrarCalendario(calendario);
            int opcion = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Para poder utilizar nuestras funcionalidades, se solicita la carga inicial de todas las temperaturas del mes.");
                Console.WriteLine("1) Cargar manualmente, día por día.");
                Console.WriteLine("2) Iniciar simulación de temperaturas.");
                Console.WriteLine();
                Console.WriteLine("Por favor, ingrese el VALOR NUMÉRICO que represente la OPCIÓN que desee seleccionar (1/2)");
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            calentemp = CargarTemperaturasManualmente(calentemp);
                            break;
                        case 2:
                            calentemp = SimularTemperaturas();
                            break;
                        default:
                            Console.WriteLine($"el número ingresado {opcion} es incorrecto. Inserte un valor numérico (1 o 2).");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Valor incorrecto. El programa volverá a ejecutarse. Inserte un valor numérico.");
                }
            }
            while (opcion != 1 && opcion != 2);
            Opciones(calendario, calentemp);
        }

        // Inicializa el calendario para el mes actual con los días del mes, incluyendo días anteriores y posteriores.
        static int[,] IniciarCalendario()
        {
            //Inicio la fecha de hoy, el primer dia del mes actual con respecto a la fecha de hoy, y que día de la semana es ese primer día del mes.
            DateTime hoy = DateTime.Now;
            DateTime primerDiaMes = new DateTime(hoy.Year, hoy.Month, 1);
            int diaSemanaPrimerDia = (int)primerDiaMes.DayOfWeek;

            //La matriz, al tener un formato de 5x7, tendrá días anteriores y posteriores al mes actual.
            //Para poder inicializar la matriz de manera óptima, establezco la cantidad de días anteriores, posteriores, siendo el dia inicial la variable que me permite saber en que día estoy.
            int dia = 1;
            int diasMesAnterior = (primerDiaMes - TimeSpan.FromDays(1)).Day;
            int diasMesActual = DateTime.DaysInMonth(hoy.Year, hoy.Month);
            int diaInicial = diasMesAnterior - diaSemanaPrimerDia + 1;

            //Creo una instancia de calendario para esta funcionalidad.
            int[,] calendario = new int[5, 7];

            //Recorro la matriz con dos For ya que tiene 2 dimensiones. Según el dia de la semana en el que estoy, se evalua si es parte del mes anterior, el mes actual o el mes siguiente.
            for (int semana = 0; semana < 5; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (semana == 0 && diaSemana < diaSemanaPrimerDia)
                    {
                        // Días del mes anterior
                        calendario[semana, diaSemana] = diaInicial++;
                    }
                    else if (dia <= diasMesActual)
                    {
                        // Días del mes actual
                        calendario[semana, diaSemana] = dia++;
                    }
                    else
                    {
                        // Días del mes siguiente
                        calendario[semana, diaSemana] = dia++ - diasMesActual;
                    }
                }
            }
            return calendario;
        }

        // Imprime el calendario con los días del mes, incluyendo días del mes anterior y posterior.
        static void MostrarCalendario(int[,] calendario)
        {
            // Se imprimen los días de la semana.
            Console.WriteLine("MATRIZ DEL MES ACTUAL");
            Console.WriteLine();
            string[] diasSemana = { "DOM", "LUN", "MAR", "MIÉ", "JUE", "VIE", "SÁB" };
            foreach (string diaSemana in diasSemana)
            {
                Console.Write(diaSemana + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            // Se imprimen cada día del mes.
            for (int semana = 0; semana < 5; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (calendario[semana, diaSemana] == 0)
                    {
                        // Imprime espacios para días del mes anterior o posterior
                        Console.Write("\t");
                    }
                    else
                    {
                        // Imprime el día del mes
                        Console.Write(calendario[semana, diaSemana] + "\t");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------------");
        }

        // Permite al usuario ingresar manualmente las temperaturas para cada día del mes.
        static double[,] CargarTemperaturasManualmente(double[,] calentemp)
        {
            //Inicio la fecha de hoy, el primer dia del mes actual con respecto a la fecha de hoy, y que día de la semana es ese primer día del mes.
            DateTime hoy = DateTime.Now;
            DateTime primerDiaMes = new DateTime(hoy.Year, hoy.Month, 1);
            int diaSemanaPrimerDia = (int)primerDiaMes.DayOfWeek;
            //La matriz, al tener un formato de 5x7, tendrá todas las temperaturas de cada día del mes, y un espacio vacío en los días que esten fuera del mes actual.
            int dia = 1;
            int diasMesActual = DateTime.DaysInMonth(hoy.Year, hoy.Month);
            //Creo una instancia de calendario de temperaturas.
            calentemp = new double[5, 7];
            //Recorro la matriz con dos For ya que tiene 2 dimensiones. Según el dia de la semana en el que estoy, se evalua si es parte del mes anterior, el mes actual o el mes siguiente. Si es parte del mes, se establece temperatura.
            for (int semana = 0; semana < 5; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (semana == 0 && diaSemana < diaSemanaPrimerDia)
                    {
                        // Días del mes anterior
                        calentemp[semana, diaSemana] = double.NaN;
                    }
                    else if (dia <= diasMesActual)
                    {
                        // Pedir temperatura para el día actual con validación
                        double temperatura;
                        bool esValido;
                        do
                        {
                            Console.Write($"Ingrese la temperatura para el día {dia}: ");
                            esValido = double.TryParse(Console.ReadLine(), out temperatura);
                            if (!esValido)
                            {
                                Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
                            }
                        } while (!esValido);
                        calentemp[semana, diaSemana] = temperatura;
                        dia++;
                    }
                    else
                    {
                        // Días del mes siguiente
                        calentemp[semana, diaSemana] = double.NaN;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("A CONTINUACIÓN, EL CALENDARIO CON LAS TEMPERATURAS CARGADAS ASIGNADAS A CADA DÍA DEL MES ACTUAL");
            Console.WriteLine();
            MostrarTemperaturas(calentemp);
            return calentemp;
        }

        // Simula la carga de temperaturas aleatorias para cada día del mes.
        static double[,] SimularTemperaturas()
        {
            // Inicializa el calendario para el mes actual con los días del mes, incluyendo días anteriores y posteriores.
            double[,] calentemp = new double[5, 7];
            DateTime hoy = DateTime.Now;
            DateTime primerDiaMes = new DateTime(hoy.Year, hoy.Month, 1);
            int diaSemanaPrimerDia = (int)primerDiaMes.DayOfWeek;
            //La matriz, al tener un formato de 5x7, tendrá todas las temperaturas de cada día del mes, y un espacio vacío en los días que esten fuera del mes actual.
            int dia = 1;
            int diasMesActual = DateTime.DaysInMonth(hoy.Year, hoy.Month);
            //Creo una instancia de la clase Random para las temperaturas aleatorias.
            Random random = new Random();
            //Recorro la matriz con dos For ya que tiene 2 dimensiones. Según el dia de la semana en el que estoy, se evalua si es parte del mes anterior, el mes actual o el mes siguiente. Si es parte del mes, se establece temperatura.
            for (int semana = 0; semana < 5; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (semana == 0 && diaSemana < diaSemanaPrimerDia)
                    {
                        // Días del mes anterior
                        calentemp[semana, diaSemana] = double.NaN;
                    }
                    else if (dia <= diasMesActual)
                    {
                        // Generar temperatura aleatoria entre -5 y 35 grados
                        int temprandom = random.Next(-5, 35);
                        calentemp[semana, diaSemana] = temprandom;
                        dia++;
                    }
                    else
                    {
                        // Días del mes siguiente
                        calentemp[semana, diaSemana] = double.NaN;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("A CONTINUACIÓN, LA SIMULACIÓN DE TEMPERATURAS RANDOM ENTRE -5 Y 35 GRADOS EN LAS TEMPERATURAS DEL MES ACTUAL");
            Console.WriteLine();
            MostrarTemperaturas(calentemp);
            return calentemp;
        }

        // Imprime el calendario con las temperaturas, ya sean ingresadas manualmente o simuladas aleatoriamente.
        static void MostrarTemperaturas(double[,] calentemp)
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
            for (int semana = 0; semana < 5; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (double.IsNaN(calentemp[semana, diaSemana]))
                    {
                        // Imprime espacios para días del mes anterior o posterior
                        Console.Write("\t");
                    }
                    else
                    {
                        // Imprime la temperatura del día
                        Console.Write($"({calentemp[semana, diaSemana]}°)\t");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------------");
        }

        // Evalua intervalos de temperatura y muestra la temperatura de un dia especifico.
        static void DiaEspecifico(int[,]calendario, double[,] calentemp)
        {
            // Si la temperatura es inferior a 0, mostrar "Hizo mucho frío."

            // Si la temperatura está entre 0 y 20, mostrar "El clima estaba fresco."

            // Si la temperatura es superior a 20, mostrar "Hizo calor afuera."
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Ingrese el día del mes que desea consultar:");
            int dia;
            bool esValido;
            //Se verifica que el valor ingresado sea número.
            do
            {
                esValido = int.TryParse(Console.ReadLine(), out dia);
                if (!esValido || dia < 1 || dia > 31)
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido entre 1 y 31.");
                    esValido = false;
                }
            } while (!esValido);
            //Se recorre la matriz, evaluando las temperaturas del mes.
            Console.WriteLine("-----------------------------------------------------------");
            bool encontrado = false;
            for (int semana = 0; semana < 5; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (!double.IsNaN(calentemp[semana, diaSemana]) && calendario[semana, diaSemana] == dia)
                    {
                        double temperatura = calentemp[semana, diaSemana];
                        Console.WriteLine($"La temperatura del día {dia} es {temperatura}°C");
                        if (temperatura < 0)
                        {
                            Console.WriteLine("Hizo mucho frío.");
                        }
                        else if (temperatura >= 0 && temperatura <= 20)
                        {
                            Console.WriteLine("El clima estaba fresco.");
                        }
                        else
                        {
                            Console.WriteLine("Hizo calor afuera.");
                        }
                        encontrado = true;
                        break;
                    }
                }
                if (encontrado) break;
            }
            Console.WriteLine("-----------------------------------------------------------");
        }

        // Evalua las temperaturas mayores a cierto umbral y muestra el calendario con las temperaturas que cumplen la condición.
        static void TemperaturaUmbral(int[,] calendario, double[,] calentemp)
        {
            //3) Encontrar y ver temperaturas por encima de 20° (Umbral).
            //Se crean listas para almacenar mayores, ya que no sabemos cuantos pueden ser.
            List<double> mayoresde20 = new List<double>();
            List<double> tempmayores = new List<double>();

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("A continuación, se muestran todos los días donde la temperatura fue mayor a 20°:");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine();
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
            for (int semana = 0; semana < 5; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (double.IsNaN(calentemp[semana, diaSemana]))
                    {
                        // Imprime espacios para días del mes anterior o posterior
                        Console.Write("\t");
                    }
                    else
                    {
                        // Imprime la temperatura del día solamente si es mayor a 20°.
                        if (calentemp[semana, diaSemana] > 20)
                        {
                            Console.Write($"({calentemp[semana, diaSemana]}°)\t");
                            tempmayores.Add(calentemp[semana, diaSemana]);
                            mayoresde20.Add(calendario[semana, diaSemana]);
                        }
                        else
                        {
                            Console.Write("\t");
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"Los días con temperaturas mayores a 20 fueron:");
            Console.WriteLine();
            for (int i = 0; i < mayoresde20.Count; i++) 
            {
                Console.WriteLine($"El día número {mayoresde20[i]}, con un total de {tempmayores[i]}° grados.");
            }
            Console.WriteLine();
        }

        // Calcula y muestra el promedio de temperatura de cada semana.
        static void PromedioSemanal(double[,] calentemp)
        {
            //Calcular y ver temperaturas promedios de cada semana.
            MostrarTemperaturas(calentemp);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("A continuación, se mostrarán las temperaturas promedio de cada semana del mes.");
            Console.WriteLine();
            int contador = 0;
            double tempsemanal = 0;
            for (int semana = 0; semana < 5; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (!double.IsNaN(calentemp[semana, diaSemana]))
                    {
                        double temperatura = calentemp[semana, diaSemana];
                        tempsemanal += temperatura;
                        contador++;
                    }
                }
                Console.WriteLine($"La temperatura promedio de la semana numero {semana+1} es: {(tempsemanal/contador):N1}°");
            }

        }

        // Calcula y muestra el promedio de temperatura del mes actual.
        static void PromedioMes(double[,] calentemp)
        {
            Console.WriteLine("PARA MAYOR INFORMACIÓN Y VERIFICACIÓN, SE UTILIZARÁ LA FUNCIONALIDAD DE MOSTRAR PROMEDIO SEMANAL ANTES DE MOSTRAR EL PROMEDIO MENSUAL.");
            Console.WriteLine("------------------------------------------------------");
            PromedioSemanal(calentemp);
            double promediomes = 0;
            double promediosemanal = 0;
            Console.WriteLine("------------------------------------------------------");
            int contador = 0;
            double tempsemanal = 0;
            for (int semana = 0; semana < 5; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (!double.IsNaN(calentemp[semana, diaSemana]))
                    {
                        double temperatura = calentemp[semana, diaSemana];
                        tempsemanal += temperatura;
                        contador++;
                    }
                }
                promediosemanal = tempsemanal / contador;
                promediomes += promediosemanal;
            }
            Console.WriteLine($"EL PROMEDIO MENSUAL DE TEMPERATURAS ES DE: {(promediomes/5):N1}° GRADOS.");
        }

        // Calcula y muestra el la temperatura mas alta del mes actual.
        static void TempMasAlta(int[,] calendario, double[,] calentemp)
        {
            double tempmayor = -99;
            int diamayor = 0;
            Console.WriteLine("---------------------------------------------------------------------------------------");
            for (int semana = 0; semana < 5; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (!double.IsNaN(calentemp[semana, diaSemana]))
                    {
                        double temperatura = calentemp[semana, diaSemana];
                        if (tempmayor < temperatura)
                        {
                            tempmayor = temperatura;
                            diamayor = calendario[semana, diaSemana];
                        }
                    }
                }
            }
            Console.WriteLine($"LA TEMPERATURA MAS ALTA DEL MES ES DE  {tempmayor:N1}° GRADOS EN EL DIA NÚMERO {diamayor} DEL MES ACTUAL.");
            Console.WriteLine("---------------------------------------------------------------------------------------");

        }

        // Calcula y muestra el la temperatura mas baja del mes actual.
        static void TempMasBaja(int[,] calendario, double[,] calentemp)
        {
            double tempmenor = 99;
            int diamenor = 0;
            Console.WriteLine("---------------------------------------------------------------------------------------");
            for (int semana = 0; semana < 5; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (!double.IsNaN(calentemp[semana, diaSemana]))
                    {
                        double temperatura = calentemp[semana, diaSemana];
                        if (tempmenor > temperatura)
                        {
                            tempmenor = temperatura;
                            diamenor = calendario[semana, diaSemana];
                        }
                    }
                }
            }
            Console.WriteLine($"LA TEMPERATURA MAS BAJA DEL MES ES DE  {tempmenor:N1}° GRADOS EN EL DIA NÚMERO {diamenor} DEL MES ACTUAL.");
            Console.WriteLine("---------------------------------------------------------------------------------------");

        }

        //Ver el pronóstico de 5 días posteriores al mes. 
        static void MostrarDiasPosteriores(int[,] calen, double[,] calentemp)
        {
            // Obtener el primer día del mes siguiente
            DateTime hoy = DateTime.Now;
            DateTime primerDiaMesSiguiente = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(1);
            int diasMesSiguiente = DateTime.DaysInMonth(primerDiaMesSiguiente.Year, primerDiaMesSiguiente.Month);
            Console.WriteLine();
            Console.WriteLine("MATRIZ CON LAS TEMPERATURAS DE LOS PRIMEROS 5 DÍAS  DEL MES SIGUIENTE. LOS DEMÁS DÍAS CON SUS RESPECTIVOS NÚMEROS.");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            string[] diasSemana = { "DOM", "LUN", "MAR", "MIÉ", "JUE", "VIE", "SÁB" };
            foreach (string diaSemana in diasSemana)
            {
                Console.Write(diaSemana + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
            int[,] calenMesSiguiente = new int[5, 7];
            double[,] calentempMesSiguiente = new double[5, 7];
            // Simular los primeros 5 días del mes siguiente
            Random random = new Random();
            for (int dia = 1; dia <= diasMesSiguiente; dia++)
            {
                int semana = (dia + (int)primerDiaMesSiguiente.DayOfWeek - 1) / 7;
                int diaSemana = (dia + (int)primerDiaMesSiguiente.DayOfWeek - 1) % 7;
                calenMesSiguiente[semana, diaSemana] = dia;
                if (dia <= 5)
                {
                    calentempMesSiguiente[semana, diaSemana] = random.Next(-5, 35);
                }
                else
                {
                    calentempMesSiguiente[semana, diaSemana] = double.NaN; // No se asigna temperatura a los días posteriores
                }
            }
            for (int semana = 0; semana < 5; semana++)
            {
                for (int diaSemana = 0; diaSemana < 7; diaSemana++)
                {
                    if (double.IsNaN(calentempMesSiguiente[semana, diaSemana]))
                    {
                        // Para los días sin temperaturas del mes que viene, decidí mostrar el numero del día correspondiente
                        Console.Write($"{calenMesSiguiente[semana, diaSemana]}\t");
                    }
                    else if (calenMesSiguiente[semana, diaSemana] != 0)
                    {
                        Console.Write($"({calentempMesSiguiente[semana, diaSemana]:0.#}°)\t");
                    }
                    else
                    {
                        //Los dias que no son del mes que viene, se establecen como NaN(Significa Not a Number)
                        Console.Write($"{double.NaN}\t");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("---------------------------------------------------");
        }
        static void Salir()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Usted ha seleccionado la opción Salir.");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
            Console.WriteLine("¡MUCHAS GRACIAS POR UTILIZAR NUESTRA APLICACIÓN DE PRONÓSTICO! ¡HASTA LUEGO!");
            Console.WriteLine();
        }

        // Menu Opciones iteradas hasta salir.
        static void Opciones(int[,]calendario, double[,]calentemp)
        {
            int opcion = 0;
            DateTime hoy = DateTime.Now;
            do
            {
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("MENÚ DE OPCIONES");
                Console.WriteLine("1) Ver temperatura de algún día específico");
                Console.WriteLine("2) Calcular y ver temperaturas promedios de cada semana.");
                Console.WriteLine("3) Encontrar y ver temperaturas por encima de 20° (Umbral).");
                Console.WriteLine("4) Ver la temperatura promedio del mes.");
                Console.WriteLine("5) Ver la temperatura más alta.");
                Console.WriteLine("6) Ver la temperatura más baja.");
                Console.WriteLine("7) Ver el pronóstico de 5 días posteriores al mes.");
                Console.WriteLine("8) Salir.");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Porfavor, seleccionar alguna opción del menú:");
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            DiaEspecifico(calendario, calentemp);
                            break;
                        case 2:
                            PromedioSemanal(calentemp);
                            break;
                        case 3:
                            TemperaturaUmbral(calendario, calentemp);
                            break;
                        case 4:
                            PromedioMes(calentemp);
                            break;
                        case 5:
                            TempMasAlta(calendario, calentemp);
                            break;
                        case 6:
                            TempMasBaja(calendario, calentemp);
                            break;
                        case 7:
                            MostrarDiasPosteriores(calendario, calentemp);
                            break;
                        case 8:
                            Salir();
                            break;
                        default:
                        Console.WriteLine($"El número ingresado {opcion} es incorrecto. Inserte un valor numérico del 1 al 7.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Valor incorrecto. Se volverá a mostrar el menú. Inserte un valor numérico.");
                }
            }
            while (opcion < 1 || opcion >8);
            while (opcion != 8)
            {
                Console.WriteLine();
                Console.WriteLine("Desea elegir alguna otra opción? (si/no)");
                Console.WriteLine();
                string respuesta;
                respuesta = Console.ReadLine().ToLower();
                while (respuesta != "sí" && respuesta != "si" && respuesta != "no")
                {
                    Console.WriteLine("Respuesta incorrecta. Por favor, ingrese una respuesta correcta (sí/no)");
                    respuesta = Console.ReadLine().ToLower();
                }
                if (respuesta == "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("¡MUCHAS GRACIAS POR UTILIZAR NUESTRA APLICACIÓN DE PRONÓSTICO! ¡HASTA LUEGO!");
                    Console.WriteLine();
                    break;
                }
                else
                { Opciones(calendario, calentemp); }
            }
        }
    }
}