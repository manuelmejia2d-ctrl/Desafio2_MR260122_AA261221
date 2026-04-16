 using System;


namespace Desafio2
{
 public class notas
{
    public static void EjercicioNotas()
    {
        //ESTRUCTURA BASE
        Console.Clear();
        Console.Write("\n******BIENVENIDO AL SISTEMA DE NOTAS******");
        Console.Write("\n");
        Console.Write("Ingrese la cantidad de estudiantes: ");
        int n = int.Parse(Console.ReadLine());

        string[] nombres = new string[n];
        double[] notas = new double[n];
        // proceso de ingreso y validacion
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEstudiante {i + 1}");

            Console.Write("Nombre: ");
            nombres[i] = Console.ReadLine();

            double nota;

            while (true)
            {
                Console.Write("Nota (0 - 10): ");
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
    }  
   }    
   }