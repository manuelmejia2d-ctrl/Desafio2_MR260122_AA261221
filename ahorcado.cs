 static void EjercicioAhorcado()
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