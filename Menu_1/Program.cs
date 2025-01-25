using System;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Selecciona una opción:");
            Console.WriteLine("1. Programa 1");
            Console.WriteLine("2. Programa 2");
            Console.WriteLine("3. Salir");
            Console.Write("Elige una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Programa1();
                    break;
                case "2":
                    Programa2();
                    break;
                case "3":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }

            Console.WriteLine("Presiona cualquier tecla para regresar al menú...");
            Console.ReadKey();
        }
    }

    private static void Programa1()
    {
        int y = 122;
        int x = 25;
        int longitud = 7;
        int alto = 13;

        Console.Clear();
        Console.SetCursorPosition(55, 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Dibujar gráfico");

        for (int ciclo = 0; ciclo < 10; ciclo++)
        {
            // Movimiento izquierda y se mantiene x disminuye
            Movimento(ref y, ref x, -1, 0, longitud, ConsoleColor.Cyan);

            // Movimiento abajo y disminuye x se mantiene
            Movimento(ref y, ref x, 0, -1, alto, ConsoleColor.Blue);

            // Movimiento izquierda de nuevo y se mantiene x disminuye
            Movimento(ref y, ref x, -1, 0, longitud, ConsoleColor.Cyan);

            // Movimiento arriba y se mantiene x aumenta
            Movimento(ref y, ref x, 0, 1, alto, ConsoleColor.Blue);
        }

        Console.SetCursorPosition(40, 26);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("¡Listo! Presiona una tecla para continuar");
    }

    private static void Movimento(ref int y, ref int x, int cambioY, int cambioX, int pasos, ConsoleColor color)
    {
        for (int i = 0; i < pasos; i++)
        {
            y += cambioY;
            x += cambioX;

            // Evitar que se salga de los límites
            if (y >= 0 && y < Console.WindowWidth && x >= 0 && x < Console.WindowHeight)
            {
                Console.SetCursorPosition(y, x);
                Console.ForegroundColor = color;
                System.Threading.Thread.Sleep(3);
                Console.WriteLine("*");
            }
            else
            {
                break;
            }
        }
    }

    private static void Programa2()
    {
        int y = 64;
        int x = 14;
        int longitud = 4;
        int altura = 0;
        int direccion = 0;
        
        Console.Clear();
        ConsoleColor[] colores = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.DarkBlue, ConsoleColor.Red, ConsoleColor.Cyan };
        int colorIndex = 0;

        for (int ciclo = 0; ciclo < 30; ciclo++)
        {
            int pasos;
            if (direccion == 0 || direccion == 2)
            {
                pasos = longitud;
            }
            else
            {
                pasos = altura;
            }

            for (int i = 0; i < pasos; i++)
            {
                if (y >= 0 && y < Console.WindowWidth && x >= 0 && x < Console.WindowHeight)
                {
                    Console.SetCursorPosition(y, x);
                    System.Threading.Thread.Sleep(3);
                    Console.ForegroundColor = colores[colorIndex];
                    Console.WriteLine("*");
                }
                else
                {
                    break;
                }

                switch (direccion)
                {
                    case 0: y--; break; // Izquierda
                    case 1: x--; break; // Arriba
                    case 2: y++; break; // Derecha
                    case 3: x++; break; // Abajo
                }
                colorIndex = (colorIndex + 1) % colores.Length;
            }

            direccion = (direccion + 1) % 4;

            if (direccion == 0 || direccion == 2)
            {
                longitud += 5;
            }
            else if (direccion == 1 || direccion == 3)
            {
                altura += 2;
            }
        }
        Console.SetCursorPosition(40, 28);
        Console.WriteLine();
    }
}
