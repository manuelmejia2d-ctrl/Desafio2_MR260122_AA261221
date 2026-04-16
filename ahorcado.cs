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
                        Console.WriteLine("\n*** INSTRUCCIONES ***");
                        Console.WriteLine("- El juego elige una palabra al azar y debes adivinarla letra por letra.");
                        Console.WriteLine("- Verás la palabra oculta con guiones bajos y se irá revelando si aciertas.");
                        Console.WriteLine("- Solo puedes ingresar una letra a la vez.");
                        Console.WriteLine("- Si repites una letra ya usada, no contará.");
                        Console.WriteLine("- Tienes 6 intentos antes de perder la partida.");
                        Console.WriteLine("- Cada error va formando el dibujo del ahorcado.");
                        Console.WriteLine("- Si completas la palabra antes de los 6 intentos, ganas.");
                        Console.WriteLine("- Si pierdes, se muestra la palabra correcta.");
                        Console.WriteLine("- Al final puedes jugar otra vez o volver al menú.");
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
            string palabraSecreta = bancoPalabras[aleatorio.Next(0, bancoPalabras.Length)];

            char[] letrasAdivinadas = new char[palabraSecreta.Length];
            for (int i = 0; i < letrasAdivinadas.Length; i++) letrasAdivinadas[i] = '_';

            List<char> letrasUsadas = new List<char>();
            int intentosFallidos = 0;
            bool victoria = false;

            while (intentosFallidos < 6 && !victoria)
            {
                Console.Clear();
                // AQUI SE MUESTRA EL AHORCADO 
                DibujarMuñeco(intentosFallidos); 

                Console.WriteLine("\nPalabra: " + string.Join(" ", letrasAdivinadas));
                Console.WriteLine("Letras usadas: " + string.Join(", ", letrasUsadas));
                Console.WriteLine("Intentos fallidos: " + intentosFallidos + " / 6");

                Console.Write("\nIngrese una letra: ");
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input) || input.Length > 1 || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("Error: Ingrese una letra válida.");
                    Thread.Sleep(800);
                    continue;
                }

                char letra = input[0];
                if (letrasUsadas.Contains(letra))
                {
                    Console.WriteLine("Ya usaste la letra " + letra);
                    Thread.Sleep(800);
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

            // AQUI APARECE LA PANTALLA FINAL
            Console.Clear();
            DibujarMuñeco(intentosFallidos);

            if (victoria)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n¡FELICIDADES! Ganaste.");
                Console.WriteLine("La palabra era: " + palabraSecreta);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n¡PERDISTE!");
                Console.WriteLine("La palabra secreta era: " + palabraSecreta);
            }

            Console.ResetColor();
            bool salirMenu = false;
            while (!salirMenu)
            {
                Console.WriteLine("\n¿Desea jugar de nuevo?");
                Console.WriteLine("1. Sí");
                Console.WriteLine("2. No (volver al menú)");
                Console.Write("Opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
            case "1":
                JugarAhorcado();
            return;
            case "2":
                salirMenu = true;
            break;
            default:
                Console.WriteLine("Opción inválida");
            break;
            }
            }
                Console.ReadKey();
        }

        static void DibujarMuñeco(int errores)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  {0}   |", (errores >= 1 ? "O" : " "));
            
            if (errores == 2) Console.WriteLine("  |   |");
            else if (errores == 3) Console.WriteLine(" /|   |");
            else if (errores >= 4) Console.WriteLine(" /|\\  |");
            else Console.WriteLine("      |");

            if (errores == 5) Console.WriteLine(" /    |");
            else if (errores >= 6) Console.WriteLine(" / \\  |");
            else Console.WriteLine("      |");

            Console.WriteLine("      |");
            Console.WriteLine("=========");
            Console.ResetColor();
        }
    }
}