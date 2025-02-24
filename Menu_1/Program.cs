using System;
using System.Data;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\nMenú Principal");
            Console.WriteLine("1. Programas de introducción");
            Console.WriteLine("2. Programas de localización");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Menu_1();
                    break;
                case 2:
                    Menu_2();
                    break;
                case 3:
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void Menu_1()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Selecciona una opción:");
            Console.WriteLine("1. Programa 1");
            Console.WriteLine("2. Programa 2");
            Console.WriteLine("3. Programa 3");
            Console.WriteLine("4. volver al menu principal");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Programa1();
                    break;
                case 2:
                    Programa2();
                    break;
                case 3:
                    Programa3();
                    break;
                case 4:
                    Console.Clear();
                    return;
                case 5:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
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
        Console.ResetColor();

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
        Console.SetCursorPosition(1, Console.WindowHeight - 3);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, Console.WindowHeight - 2);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Main();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
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
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(0, Console.WindowHeight-1);
        Console.Write("Digite una opción del menú: 1. Ir al menú anterior       2. Continuar        3. Salir: ");
        Console.ResetColor();
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Main();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    private static void Programa3()
    {
        int centroX = Console.WindowWidth / 2;
        int centroY = Console.WindowHeight / 2;
        int escalax = 10;
        int escalay = 4;

        Console.Clear();
        Console.SetCursorPosition(51, 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Dibujar rectángulos");
        ConsoleColor[] colores = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.DarkBlue, ConsoleColor.Red, ConsoleColor.Cyan };

        for (int rectangulos = 0; rectangulos < 5; rectangulos++)
        {
            Console.ForegroundColor = colores[rectangulos % colores.Length];
            int ancho = (rectangulos) * escalax + 4;
            int alto = (rectangulos) * escalay;

            int startX = centroX - ancho / 2;
            int startY = centroY - alto / 2;
            int endX = centroX + ancho / 2;
            int endY = centroY + alto / 2;

            for (int x = startX; x <= endX; x++)
            {
                if (x >= 0 && x < Console.WindowWidth && startY >= 0 && startY < Console.WindowHeight)
                {
                    Console.SetCursorPosition(x, startY);
                    Console.Write("*");
                    System.Threading.Thread.Sleep(10);
                }
            }

            for (int y = startY; y <= endY; y++)
            {
                if (y >= 0 && y < Console.WindowHeight && endX >= 0 && endX < Console.WindowWidth)
                {
                    Console.SetCursorPosition(endX, y);
                    Console.Write("*");
                    System.Threading.Thread.Sleep(15);
                }
            }

            for (int x = endX; x >= startX; x--)
            {
                if (x >= 0 && x < Console.WindowWidth && endY >= 0 && endY < Console.WindowHeight)
                {
                    Console.SetCursorPosition(x, endY);
                    Console.Write("*");
                    System.Threading.Thread.Sleep(20);
                }
            }

            for (int y = endY; y >= startY; y--)
            {
                if (y >= 0 && y < Console.WindowHeight && startX >= 0 && startX < Console.WindowWidth)
                {
                    Console.SetCursorPosition(startX, y);
                    Console.Write("*");
                    System.Threading.Thread.Sleep(25);
                }
            }
        }
        Console.SetCursorPosition(1, Console.WindowHeight - 3);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, Console.WindowHeight - 2);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Main();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void Menu_2()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\nMenú 2. Programas de localización");
            Console.WriteLine("1. Mostrar la tabla de senos del 0 al 90.");
            Console.WriteLine("2. Mostrar la tabla de cosenos del 0 al 90.");
            Console.WriteLine("3. Calcular la hipotenusa y los ángulos de un triángulo rectángulo.");
            Console.WriteLine("4. Calcular datos de una recta dados dos puntos.");
            Console.WriteLine("5. Calcular la trayectoria de un proyectil.");
            Console.WriteLine("6. Volver al menú principal.");
            Console.WriteLine("7. Salir.");
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    MostrarTablaSeno();
                    break;
                case 2:
                    MostrarTablaCoseno();
                    break;
                case 3:
                    CalcularTriangulo();
                    break;
                case 4:
                    CalcularDatosRecta();
                    break;
                case 5:
                    CalcularTrayectoriaProyectil();
                    break;
                case 6:
                    Console.Clear();
                    return;
                case 7:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static double Factorial(int n)
    {
        double fact = 1;
        for (int i = 2; i <= n; i++)
            fact *= i;
        return fact;
    }

    static double Seno(double grados)
    {
        double radianes = grados * (Math.PI / 180);
        double seno = 0;
        for (int i = 0; i < 10; i++)
        {
            seno += (Math.Pow(-1, i) * Math.Pow(radianes, 2 * i + 1)) / Factorial(2 * i + 1);
            System.Threading.Thread.Sleep(5);
        }
        return seno;
    }

    static double Coseno(double grados)
    {
        double radianes = grados * (Math.PI / 180);
        double coseno = 0;
        for (int i = 0; i < 10; i++)
        {
            coseno += (Math.Pow(-1, i) * Math.Pow(radianes, 2 * i)) / Factorial(2 * i);
        }
        return coseno;
    }

    static void MostrarTablaSeno()
    {
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 3, 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Menu 2 - Programas de localización");
        Console.ResetColor();
        Console.SetCursorPosition(1, 2);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nTabla de Senos:");
        Console.ResetColor();

        int anchoConsola = Console.WindowWidth;
        int altoConsola = Console.WindowHeight;

        for (int i = 0; i <= 90; i++)
        {
            int fila = i % 16; 
            int col = (i / 16);

            if (fila == 0 && i != 0)
            {
                Console.WriteLine(); 
            }

            Console.SetCursorPosition(col * 20, fila + 5);
            Console.Write($"Seno({i}) = {Seno(i):F4}");
        }
        Console.SetCursorPosition(1, altoConsola - 4);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, altoConsola - 3);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true) {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Main();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }


    static void MostrarTablaCoseno()
    {
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 3, 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Menu 2 - Programas de localización");
        Console.ResetColor();
        Console.SetCursorPosition(1, 2);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nTabla de Cosenos:");
        Console.ResetColor();

        int anchoConsola = Console.WindowWidth;
        int altoConsola = Console.WindowHeight;

        for (int i = 0; i <= 90; i++)
        {
            int fila = i % 16;
            int col = (i / 16);

            if (fila == 0 && i != 0)
            {
                Console.WriteLine();
            }

            Console.SetCursorPosition(col * 20, fila + 5);
            Console.WriteLine($"Cos({i}) = {Coseno(i):F4}");
        }
        Console.SetCursorPosition(1, altoConsola - 4);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, altoConsola - 3);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Main();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

    }

    static void CalcularTriangulo()
    {
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 3, 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Menu 2 - Programas de localización");
        Console.ResetColor();
        Console.Write("Cateto A: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Cateto B: ");
        double b = Convert.ToDouble(Console.ReadLine());
        double h = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        double anguloA = Math.Atan(a / b) * (180 / Math.PI);
        double anguloB = Math.Atan(b / a) * (180 / Math.PI);
        Console.WriteLine("\nResultados:");
        Console.WriteLine($"Hipotenusa: {h:F2}");
        Console.WriteLine($"Ángulo opuesto a cateto A: {anguloA:F2}°");
        Console.WriteLine($"Ángulo opuesto a cateto B: {anguloB:F2}°");
        //Dibujar
        Console.WriteLine("\nRepresentación del triángulo:\n");
        for (int i = 0; i <= a; i++)
        {
            for (int j = 0; j <= b; j++)
            {
                if (i == a || j == 0 || j == (int)Math.Round((double)i * b / a))
                    Console.Write("* ");
                else
                    Console.Write("  ");
            }
            Console.WriteLine();
        }
        Console.SetCursorPosition(1, Console.WindowHeight - 4);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, Console.WindowHeight - 3);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Main();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void CalcularDatosRecta()
    {
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 3, 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Menu 2 - Programas de localización");
        Console.ResetColor();
        Console.Write("Ingrese x1: ");
        double x1 = double.Parse(Console.ReadLine());
        Console.Write("Ingrese y1: ");
        double y1 = double.Parse(Console.ReadLine());
        Console.Write("Ingrese x2: ");
        double x2 = double.Parse(Console.ReadLine());
        Console.Write("Ingrese y2: ");
        double y2 = double.Parse(Console.ReadLine());

        double pendiente = (y2 - y1) / (x2 - x1);
        double angulo = Math.Atan(pendiente) * 180 / Math.PI;
        double xm = (x1 + x2) / 2;
        double ym = (y1 + y2) / 2;

        Console.WriteLine($"Pendiente: {pendiente:F4}");
        Console.WriteLine($"Ángulo de inclinación: {angulo:F4}°");
        Console.WriteLine($"Punto medio: ({xm}, {ym})");
        Console.WriteLine("\nRepresentación de la recta:\n");

        int alto = (int)Math.Max(y1, y2); // Mayor valor de Y para iniciar desde arriba
        int bajo = (int)Math.Min(y1, y2); // Menor valor de Y
        int izquierda = (int)Math.Min(x1, x2); // Menor valor de X
        int derecha = (int)Math.Max(x1, x2); // Mayor valor de X

        for (int y = alto; y >= bajo; y--) // Iterar de arriba hacia abajo
        {
            for (int x = izquierda; x <= derecha; x++)
            {
                if (Math.Abs((y - y1) - pendiente * (x - x1)) < 0.5)
                    Console.Write("* ");
                else
                    Console.Write("  ");
            }
            Console.WriteLine();
        }
        Console.SetCursorPosition(1, Console.WindowHeight - 3);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, Console.WindowHeight - 2);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Main();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void CalcularTrayectoriaProyectil()
    {
        Console.Clear();
        Console.SetCursorPosition(Console.WindowWidth / 3, 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Menu 2 - Programas de localización");
        Console.ResetColor();
        Console.Write("Ingrese la velocidad inicial (m/s): ");
        double v0 = double.Parse(Console.ReadLine());
        Console.Write("Ingrese el ángulo de lanzamiento (°): ");
        double angulo = double.Parse(Console.ReadLine());

        double g = 9.81;
        double radianes = angulo * Math.PI / 180;
        double vx = v0 * Math.Cos(radianes);
        double vy = v0 * Math.Sin(radianes);

        double tiempoVuelo = (2 * vy) / g;
        double alturaMaxima = (vy * vy) / (2 * g);
        double distanciaMaxima = vx * tiempoVuelo;

        double velocidadMaxima = v0; // La velocidad inicial es la velocidad máxima

        int alturaConsola = Console.WindowHeight - 12; // Limitar la salida a 6 posiciones antes de la altura máxima de la consola

        Console.WriteLine("\nTrayectoria del proyectil:");
        int lineaConsola = 0; // Línea actual en la consola
        int columnaActual = 0; // Columna actual para la salida
        int espacioColumna = 30; // Espacio entre columnas

        for (double t = 0; t <= tiempoVuelo; t += 0.1)
        {
            double x = vx * t;
            double y = vy * t - 0.5 * g * t * t;
            double velocidad = Math.Sqrt(Math.Pow(vx, 2) + Math.Pow(vy - g * t, 2));
            if (y < 0) break;

            if (lineaConsola >= alturaConsola)
            {
                lineaConsola = 0;
                columnaActual += espacioColumna;
            }

            // Agregar condición para detenerse cuando se sobrepasa el ancho de la consola
            if (columnaActual >= Console.WindowWidth)
            {
                Console.WriteLine("\nEl límite de columnas ha sido sobrepasado.");
                break;
            }

            Console.SetCursorPosition(columnaActual, 5 + lineaConsola);
            Console.Write($"T: {Math.Truncate(t * 10) / 10:F1}s - P: ({Math.Truncate(x * 10) / 10:F1}; {Math.Truncate(y * 10) / 10:F1})");
            lineaConsola++;
            System.Threading.Thread.Sleep(30);
        }

        Console.SetCursorPosition(0, Console.WindowHeight - 6);
        Console.WriteLine($"Altura máxima: {Math.Truncate(alturaMaxima * 10) / 10:F1} m");
        Console.WriteLine($"Distancia máxima: {Math.Truncate(distanciaMaxima * 10) / 10:F1} m");
        Console.WriteLine($"Velocidad máxima: {Math.Truncate(velocidadMaxima * 10) / 10:F1} m/s");

        Console.SetCursorPosition(1, Console.WindowHeight - 3);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Digite una opción del menú:");
        Console.ResetColor();
        Console.SetCursorPosition(25, Console.WindowHeight - 2);
        Console.WriteLine("1. Ir al menú anterior       2. Continuar        3. Salir");
        while (true)
        {
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Main();
                    return;
                case 2:
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}