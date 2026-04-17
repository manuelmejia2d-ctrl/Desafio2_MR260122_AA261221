using System;


namespace Desafio2
{
    public class ahorcado
    {
        public static void EjercicioAhorcado()
        {    

             Console.WindowHeight = 80;
             Console.WindowWidth = 60;
             Console.ForegroundColor=ConsoleColor.White;
             Console.BackgroundColor=ConsoleColor.DarkGray;

             Console.Clear();

            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("\n    --- JUEGO DEL AHORCADO ---");
                Console.WriteLine("    1. Jugar");
                Console.WriteLine("    2. Ver Instrucciones");
                Console.WriteLine("    3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        JugarAhorcado();
                        break;
                    case "2":
                        Console.WriteLine("\n          *** INSTRUCCIONES DEL JUEGO ***");
                        Console.WriteLine("    ***************************************************\n");
                        Console.WriteLine("    - El sistema elige una palabra al azar.");
                        Console.WriteLine("    - Debes adivinar la palabra letra por letra.");
                        Console.WriteLine("    - Si fallas, el dibujo del ahorcado crecerá.");
                        Console.WriteLine("    - Tienes un máximo de 6 intentos fallidos.");
                        Console.WriteLine("    - Si completas la palabra antes de morir, ¡GANAS!");
                        Console.WriteLine("    ***************************************************\n");
                        Console.WriteLine("          Presione cualquier tecla para volver...");
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
                // AQUI SE MUESTRA EL AHORCADO 
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

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
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
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
                Console.ForegroundColor = ConsoleColor.White;

              
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
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
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
        }
    }
}