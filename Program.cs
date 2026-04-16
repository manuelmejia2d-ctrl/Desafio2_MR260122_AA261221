using System;

namespace Desafio2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Iniciando Menú de opciones
            int opcion = 0;
            while (opcion != 3)
            {
                Console.Clear();
                Console.WriteLine("--- UNIVERSIDAD DON BOSCO ---");
                Console.WriteLine("Desafío 2 - Programación de Algoritmos");
                Console.WriteLine("1.Juego del Ahorcado");
                Console.WriteLine("2.Sistema de Notas");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1: ahorcado.EjercicioAhorcado(); 
                        break;
                        case 2: notas.EjercicioNotas(); 
                        break;
                        case 3: Console.WriteLine("Saliendo..."); 
                        break;
                        default: Console.WriteLine("Opción no válida."); 
                        break;
                    }
                }
                if (opcion != 3) 
                { Console.WriteLine("\nPresione cualquier tecla para continuar..."); 
                Console.ReadKey(); 
                }
            }
        }
        //Division de ejercicios
        static void EjercicioAhorcado()
        {
            Console.WriteLine("Iniciando Juego del Ahorcado...");
        }

        static void EjercicioNotas()
        {
            Console.WriteLine("Iniciando Sistema de Registro de Notas...");
        }
    }
}

