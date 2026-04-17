 using System;


namespace Desafio2
{
 public class notas
{
    public static void EjercicioNotas()
    {
        Console.WindowHeight = 200;
        Console.WindowWidth = 70;
        Console.ForegroundColor=ConsoleColor.Black;
        Console.BackgroundColor=ConsoleColor.DarkGray;
        Console.Clear();
        //ESTRUCTURA BASE
        Console.Clear();
        Console.ForegroundColor=ConsoleColor.White;
        Console.BackgroundColor=ConsoleColor.Blue;
        Console.Write("\n***************** BIENVENIDO AL SISTEMA DE NOTAS *********************");
        Console.ForegroundColor=ConsoleColor.Black;
        Console.BackgroundColor=ConsoleColor.DarkGray;
        Console.Write("\n\n");
        Console.Write("Ingrese la cantidad de estudiantes: ");
        int n = int.Parse(Console.ReadLine());
        
        string[] nombres = new string[n];
        double[] notas = new double[n];
        // proceso de ingreso y validacion
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEstudiante {i + 1}");

            Console.Write("\t Nombre: ");
            nombres[i] = Console.ReadLine();

            double nota;

            while (true)
            {
                Console.Write("\t Nota (0 - 10): ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out nota) && nota >= 0 && nota <= 10)
                    break;   
                Console.WriteLine("Por favor, solo ingrese numeros.");
            }

            notas[i] = nota;
        }
        //Proceso de claculos
        double suma = 0;
        double max = notas[0];
        double min = notas[0];

        for (int i = 0; i < n; i++)
        {
            suma += notas[i];

            if (notas[i] > max)
                max = notas[i];

            if (notas[i] < min)
                min = notas[i];
        }

        double promedio = suma / n;
        
        //TABLA DE REPORTE 
        int aprobados = 0;
        int reprobados = 0;
        Console.ForegroundColor=ConsoleColor.White;
        Console.Write("\n\n");
        // Encabezado con bordes pro
        Console.WriteLine("\n┌──────────────────────┬──────────┬────────┬────────────┐");
        Console.WriteLine("│ {0,-20} │ {1,-8} │ {2,-6} │ {3,-10} │", "NOMBRE", "NOTA", "LETRA", "ESTADO");
        Console.WriteLine("├──────────────────────┼──────────┼────────┼────────────┤");

        for (int i = 0; i < n; i++)
        {
            string letra = ObtenerLetra(notas[i]);
            string estado = Estado(notas[i]);

            if (estado == "Aprobado")
                aprobados++;
            else
                reprobados++;

            string nombreFijo = nombres[i].Length > 20 ? nombres[i].Substring(0, 17) + "..." : nombres[i].PadRight(20);
            Console.WriteLine("│ {0,-20} │ {1,-8:F2} │ {2,-6} │ {3,-10} │", nombreFijo, notas[i], letra, estado);
        }

        Console.WriteLine("└──────────────────────┴──────────┴────────┴────────────┘");

        //RESUMEN FINAL
        Console.WriteLine("  ==============================================");
        Console.WriteLine("    Promedio general: " + promedio.ToString("F2"));
        Console.WriteLine("    Nota máxima: " + max);
        Console.WriteLine("    Nota mínima: " + min);
        Console.WriteLine("    Total aprobados: " + aprobados);
        Console.WriteLine("    Total reprobados: " + reprobados);
        Console.WriteLine("  ==============================================");
    }

      //FUNCIONES
         static string ObtenerLetra(double nota)
    {
        if (nota >= 9) return "A";
        if (nota >= 8) return "B";
        if (nota >= 7) return "C";
        if (nota >= 6) return "D";
        return "F";
    }

        static string Estado(double nota)
    {
        if (nota >= 6) return "Aprobado";
        return "Reprobado";
    }
}
    
}  
       
   