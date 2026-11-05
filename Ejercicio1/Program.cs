using System;

class Program
{
    static void Main(string[] args)
    {
        // Funciones para pobrar
        //Ejercicio1();
        //Ejercicio2();
        //Ejercicio3();
        //Ejercicio4();
        //Ejercicio5();
        //Ejercicio6();
        //Ejercicio7();
        //Ejercicio8();
        //Ejercicio9();
        //Ejercicio10();
    }

    // 1. Suma, resta, multiplicación y módulo de dos números
    static void Ejercicio1()
    {
        Console.WriteLine("--- Ejercicio 1 ---");
        Console.Write("Introduce el primer número: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Introduce el segundo número: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"La suma es {num1 + num2}");
        Console.WriteLine($"La resta es: {num1} - {num2} = {num1 - num2}");
        Console.WriteLine($"La multiplicación es: {num1 * num2}");
        Console.WriteLine($"La división es: {num1 / num2}");
        Console.WriteLine($"El módulo es: {num1 % num2}");
    }

    // 2. Total a pagar en un bar con precios constantes
    static void Ejercicio2()
    {
        Console.WriteLine("\n--- Ejercicio 2 ---");
        const double PRECIO_HAMBURGUESA = 4.50;
        const double PRECIO_PAPAS = 2.00;
        const double PRECIO_BEBIDA = 1.50;

        Console.Write("Cantidad de hamburguesas: ");
        int hamburguesas = Convert.ToInt32(Console.ReadLine());

        Console.Write("Cantidad de papas: ");
        int papas = Convert.ToInt32(Console.ReadLine());

        Console.Write("Cantidad de bebidas: ");
        int bebidas = Convert.ToInt32(Console.ReadLine());

        double total = (hamburguesas * PRECIO_HAMBURGUESA) + (papas * PRECIO_PAPAS) + (bebidas * PRECIO_BEBIDA);
        Console.WriteLine($"Cantidad a pagar: {total:F2}€");
    }

    // 3. Operaciones matemáticas avanzadas
    static void Ejercicio3()
    {
        Console.WriteLine("\n--- Ejercicio 3 ---");
        Console.Write("Introduce un número: ");
        double numero = Convert.ToDouble(Console.ReadLine());

        double numeroAux = 10.0;

        Console.WriteLine($"Valor absoluto: {Math.Abs(numero)}");
        Console.WriteLine($"Potencia al cubo: {Math.Pow(numero, 3)}");
        Console.WriteLine($"Raíz cuadrada: {Math.Sqrt(numero)}");
        Console.WriteLine($"Seno: {Math.Sin(numero)}");
        Console.WriteLine($"Coseno: {Math.Cos(numero)}");
        Console.WriteLine($"Número máximo (comparado con {numeroAux}): {Math.Max(numero, numeroAux)}");
        Console.WriteLine($"Número mínimo (comparado con {numeroAux}): {Math.Min(numero, numeroAux)}");
    }

    // 4. Perímetro de un cuadrado
    static void Ejercicio4()
    {
        Console.WriteLine("\n--- Ejercicio 4 ---");
        Console.Write("Introduce el valor del lado del cuadrado: ");
        double lado = Convert.ToDouble(Console.ReadLine());

        double perimetro = lado * 4;
        Console.WriteLine($"El perímetro del cuadrado es: {perimetro}");
    }

    // 5. Suma de dos primeros y producto de los dos últimos
    static void Ejercicio5()
    {
        Console.WriteLine("\n--- Ejercicio 5 ---");
        Console.Write("Introduce el primer número: ");
        double n1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Introduce el segundo número: ");
        double n2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Introduce el tercer número: ");
        double n3 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Introduce el cuarto número: ");
        double n4 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"Suma de los dos primeros: {n1 + n2}");
        Console.WriteLine($"Producto del tercero y el cuarto: {n3 * n4}");
    }

    // 6. Suma y promedio de cuatro valores
    static void Ejercicio6()
    {
        Console.WriteLine("\n--- Ejercicio 6 ---");
        double suma = 0;
        for (int i = 1; i <= 4; i++)
        {
            Console.Write($"Introduce el valor numérico {i}: ");
            suma += Convert.ToDouble(Console.ReadLine());
        }

        double promedio = suma / 4;
        Console.WriteLine($"Suma total: {suma}");
        Console.WriteLine($"Promedio: {promedio}");
    }

    // 7. Coste total de un artículo por su cantidad
    static void Ejercicio7()
    {
        Console.WriteLine("\n--- Ejercicio 7 ---");
        Console.Write("Ingresa el precio del artículo: ");
        double precio = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingresa la cantidad que lleva el cliente: ");
        int cantidad = Convert.ToInt32(Console.ReadLine());

        double costeTotal = precio * cantidad;
        Console.WriteLine($"El coste total es: {costeTotal:F2}");
    }

    // 8. Nota final ponderada
    static void Ejercicio8()
    {
        Console.WriteLine("\n--- Ejercicio 8 ---");
        Console.Write("Introduce la nota del primer parcial: ");
        double parcial1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Introduce la nota del segundo parcial: ");
        double parcial2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Introduce la nota del examen: ");
        double examen = Convert.ToDouble(Console.ReadLine());
        Console.Write("Introduce la nota del trabajo final: ");
        double trabajo = Convert.ToDouble(Console.ReadLine());

        double promedioParciales = (parcial1 + parcial2) / 2;
        double notaFinal = (promedioParciales * 0.50) + (examen * 0.30) + (trabajo * 0.20);

        Console.WriteLine($"Tu nota final en 'Desarrollo de Interfaces' es: {notaFinal:F2}");
    }

    // 9. Porcentaje de participación de tres socios mediante interpolación
    static void Ejercicio9()
    {
        Console.WriteLine("\n--- Ejercicio 9 ---");
        Console.Write("Aportación del socio 1: ");
        double socio1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Aportación del socio 2: ");
        double socio2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Aportación del socio 3: ");
        double socio3 = Convert.ToDouble(Console.ReadLine());

        double totalAportado = socio1 + socio2 + socio3;

        double p1 = (socio1 / totalAportado) * 100;
        double p2 = (socio2 / totalAportado) * 100;
        double p3 = (socio3 / totalAportado) * 100;

        Console.WriteLine($"El porcentaje del socio 1 es {p1:F0}%, del socio 2 es {p2:F0}% y del socio 3 es {p3:F0}%");
    }

    // 10. Comprobación de cadena que comienza por "www"
    static void Ejercicio10()
    {
        Console.WriteLine("\n--- Ejercicio 10 ---");
        Console.Write("Introduce una cadena de texto: ");
        string cadena = Console.ReadLine();

        bool comienzaConWww = cadena.StartsWith("www");
        Console.WriteLine(comienzaConWww.ToString().ToLower());
    }
}