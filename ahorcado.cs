using System;


namespace Desafio2
{
    public class ahorcado
    {
        public static void EjercicioAhorcado()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("--- JUEGO DEL AHORCADO ---");
                Console.WriteLine("1. Jugar");
                Console.WriteLine("2. Ver Instrucciones");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        JugarAhorcado();
                        break;
                    case "2":
                        Console.WriteLine("\nInstrucciones: Adivina la palabra secreta letra por letra.");
                        Console.WriteLine("Tienes 6 intentos antes de ser ahorcado. ¡Suerte!");
                        Console.WriteLine("\nPresione cualquier tecla para volver...");
                        Console.ReadKey();
                        break;
                    case "3":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        static void JugarAhorcado()
        {
            string[] bancoPalabras = { "PROGRAMACION", "ALGORITMO", "ESTRUCTURA", "VARIABLE", "COMPUTADORA", "INGENIERIA", "SERVIDOR", "BINARIO", "SISTEMA", "VECTOR" };
            Random aleatorio = new Random();
            string palabraSecreta = bancoPalabras[aleatorio.Next(0, 10)];

            char[] letrasAdivinadas = new char[palabraSecreta.Length];
            for (int i = 0; i < letrasAdivinadas.Length; i++) letrasAdivinadas[i] = '_';

            List<char> letrasUsadas = new List<char>();
            int intentosFallidos = 0;
            bool victoria = false;

            while (intentosFallidos < 6 && !victoria)
            {
                Console.Clear();
                //dibujar ahorcado
                
                Console.WriteLine("\nPalabra: " + string.Join(" ", letrasAdivinadas));
                Console.WriteLine("Letras usadas: " + string.Join(", ", letrasUsadas));
                Console.WriteLine($"Intentos restantes: {6 - intentosFallidos}");

                Console.Write("\nIngrese una letra: ");
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input) || input.Length > 1 || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("Error: Ingrese un solo carácter válido.");
                    Thread.Sleep(1000);
                    continue;
                }

                char letra = input[0];

                if (letrasUsadas.Contains(letra))
                {
                    Console.WriteLine($"La letra '{letra}' ya la usaste.");
                    Thread.Sleep(1000);
                    continue;
                }

                letrasUsadas.Add(letra);

                if (palabraSecreta.Contains(letra))
                {
                    for (int i = 0; i < palabraSecreta.Length; i++)
                    {
                        if (palabraSecreta[i] == letra) letrasAdivinadas[i] = letra;
                    }
                }
                else
                {
                    intentosFallidos++;
                }
                victoria = !new string(letrasAdivinadas).Contains('_');
            }
        }
    }
}