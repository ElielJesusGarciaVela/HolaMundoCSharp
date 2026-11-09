using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        // Descomenta para probar las funciones
        // Ejercicio1();
    }

    static void Ejercicio1()
    {
        Console.Write("Introduce el primer número: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Introduce el segundo número: ");
        int num2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("El mayor es: {0}", Math.Max(num1, num2));
    }

    static void Ejercicio2()
    {
        Console.Write("Introduce los Kilowatios consumidos: ");
        double kw = Convert.ToDouble(Console.ReadLine());
        double coste;

        if (kw > 1800)
        {
            coste = kw * 0.8;
        }
        else if (kw >= 1000)
        {
            coste = kw * 0.12;
        }
        else
        {
            coste = kw * 0.14;
        }

        Console.WriteLine("Total a pagar: {0:C2}", coste);
    }

    static void Ejercicio3()
    {
        Console.Write("Introduce tu estado civil (C, S, V, D): ");
        char estado = char.ToUpper(Console.ReadKey().KeyChar);
        Console.WriteLine();

        switch (estado)
        {
            case 'C':
                Console.WriteLine("Tu estado civil es Casad@");
                break;
            case 'S':
                Console.WriteLine("Tu estado civil es Solter@");
                break;
            case 'V':
                Console.WriteLine("Tu estado civil es Viud@");
                break;
            case 'D':
                Console.WriteLine("Tu estado civil es Divorciad@");
                break;
            default:
                Console.WriteLine("Opción incorrecta");
                break;
        }
    }

    static void Ejercicio4()
    {
        Console.Write("Introduce un número del 1 al 9: ");
        int numero = Convert.ToInt32(Console.ReadLine());

        if (numero < 1 || numero > 9)
        {
            Console.WriteLine("Número fuera de rango.");
            return;
        }

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("{0} x {1} = {2}", numero, i, numero * i);
        }
    }

    static void Ejercicio5()
    {
        Console.Write("Introduce una cadena de texto: ");
        string texto = Console.ReadLine();

        Console.WriteLine("Longitud: " + texto.Length);
        Console.WriteLine("Contiene 'hola': " + texto.Contains("hola"));
        Console.WriteLine("Reemplazo 'a' por 'x': " + texto.Replace('a', 'x'));
        Console.WriteLine("Mayúsculas: " + texto.ToUpper());
        Console.WriteLine("Minúsculas: " + texto.ToLower());

        if (texto.Length > 0)
        {
            Console.WriteLine("Eliminar carácter en posición 0: " + texto.Remove(0, 1));
        }

        if (texto.Length >= 3)
        {
            Console.WriteLine("Subcadena (pos 0 a 3): " + texto.Substring(0, 3));
        }
    }

    static void Ejercicio6()
    {
        Console.Write("Introduce un número: ");
        int numero = Convert.ToInt32(Console.ReadLine());
        long factorial = 1;

        for (int i = numero; i > 0; i--)
        {
            factorial *= i;
        }

        Console.WriteLine("El factorial de {0} es {1}", numero, factorial);
    }

    static void Ejercicio7()
    {
        for (int i = 90; i >= 65; i--)
        {
            string letra = Convert.ToString((char)i);
            Console.Write(letra + " ");
        }
        Console.WriteLine();
    }

    static void Ejercicio8()
    {
        Random random = new Random();
        int aleatorio = random.Next(10, 31);
        Console.WriteLine("Número aleatorio generado: " + aleatorio);
    }

    static void Ejercicio9()
    {
        Console.Write("Introduce el tamaño del array: ");
        int tamano = Convert.ToInt32(Console.ReadLine());
        int[] numeros = new int[tamano];

        for (int i = 0; i < tamano; i++)
        {
            Console.Write("Introduce el valor para la posición {0}: ", i);
            numeros[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.Write("Pares: ");
        for (int i = 0; i < tamano; i++)
        {
            if (numeros[i] % 2 == 0) Console.Write(numeros[i] + " ");
        }
        Console.WriteLine();

        Console.Write("Impares: ");
        for (int i = 0; i < tamano; i++)
        {
            if (numeros[i] % 2 != 0) Console.Write(numeros[i] + " ");
        }
        Console.WriteLine();
    }

    static void Ejercicio10()
    {
        int[] numeros = { 15, 3, 9, 1, 24, 12, 5, 82, 19, 7 };

        Array.Sort(numeros);

        for (int i = 0; i < numeros.Length; i++)
        {
            Console.WriteLine(numeros[i]);
        }
    }

    static void Ejercicio11()
    {
        Stack pila = new Stack();

        for (int i = 0; i < 4; i++)
        {
            Console.Write("Introduce un entero para la pila: ");
            int valor = Convert.ToInt32(Console.ReadLine());
            pila.Push(valor);
        }

        Console.WriteLine("Contenido de la pila:");
        foreach (int item in pila)
        {
            Console.WriteLine(item);
        }

        if (pila.Count >= 2)
        {
            pila.Pop();
            pila.Pop();
        }

        Console.WriteLine("Contenido de la pila tras sacar 2 elementos:");
        foreach (int item in pila)
        {
            Console.WriteLine(item);
        }
    }
}
