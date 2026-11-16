using System;

namespace EjerciciosDelegados
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EJERCICIO 1 ===");
            Ejercicio1.Ejecutar();

            Console.WriteLine("\n=== EJERCICIO 2 ===");
            Ejercicio2.Ejecutar();

            Console.WriteLine("\n=== EJERCICIO 3 ===");
            Ejercicio3.Ejecutar();

            Console.WriteLine("\n=== EJERCICIO 4 ===");
            Ejercicio4.Ejecutar();

            Console.WriteLine("\n=== EJERCICIO 5 ===");
            Ejercicio5.Ejecutar();

            Console.WriteLine("\n=== EJERCICIO 6 ===");
            Ejercicio6.Ejecutar();

            Console.WriteLine("\n=== EJERCICIO 7 ===");
            Ejercicio7.Ejecutar();

            Console.WriteLine("\n=== EJERCICIO 8 ===");
            Ejercicio8.Ejecutar();

            Console.WriteLine("\n=== EJERCICIO 9 ===");
            Ejercicio9.Ejecutar();

            Console.WriteLine("\n=== EJERCICIO 10 ===");
            Ejercicio10.Ejecutar();

            Console.ReadLine();
        }
    }

    // ---------------------------------------------------------
    // Ejercicio 1: Delegado Básico
    // ---------------------------------------------------------
    class Ejercicio1
    {
        public delegate int Operacion(int a, int b);

        public static int Sumar(int a, int b) => a + b;

        public static void Ejecutar()
        {
            Operacion op = Sumar;
            int resultado = op(5, 3);
            Console.WriteLine($"Suma (5 + 3): {resultado}");
        }
    }

    // ---------------------------------------------------------
    // Ejercicio 2: Múltiples Métodos
    // ---------------------------------------------------------
    class Ejercicio2
    {
        public delegate int Operacion(int a, int b);

        public static int Sumar(int a, int b) => a + b;
        public static int Restar(int a, int b) => a - b;

        public static void Ejecutar()
        {
            Operacion op = Sumar;
            Console.WriteLine($"Suma (10 + 4): {op(10, 4)}");

            op = Restar;
            Console.WriteLine($"Resta (10 - 4): {op(10, 4)}");
        }
    }

    // ---------------------------------------------------------
    // Ejercicio 3: Uso de Multicast Delegates
    // ---------------------------------------------------------
    class Ejercicio3
    {
        public delegate int Operacion(int a, int b);

        public static int Sumar(int a, int b)
        {
            int res = a + b;
            Console.WriteLine($"Suma: {res}");
            return res;
        }

        public static int Restar(int a, int b)
        {
            int res = a - b;
            Console.WriteLine($"Resta: {res}");
            return res;
        }

        public static int Multiplicar(int a, int b)
        {
            int res = a * b;
            Console.WriteLine($"Multiplicación: {res}");
            return res;
        }

        public static void Ejecutar()
        {
            Operacion op = Sumar;
            op += Restar;
            op += Multiplicar;

            int ultimoResultado = op(6, 2);
            Console.WriteLine($"Valor devuelto por el multicast delegate: {ultimoResultado}");
        }
    }

    // ---------------------------------------------------------
    // Ejercicio 4: Delegados con Diferentes Métodos
    // ---------------------------------------------------------
    class Ejercicio4
    {
        public delegate int Operacion(int a, int b);

        public static int Sumar(int a, int b)
        {
            int res = a + b;
            Console.WriteLine($"Suma: {res}");
            return res;
        }

        public static int Restar(int a, int b)
        {
            int res = a - b;
            Console.WriteLine($"Resta: {res}");
            return res;
        }

        public static int Multiplicar(int a, int b)
        {
            int res = a * b;
            Console.WriteLine($"Multiplicación: {res}");
            return res;
        }

        public static int Dividir(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("División: Error, no se puede dividir por cero.");
                return 0;
            }
            int res = a / b;
            Console.WriteLine($"División: {res}");
            return res;
        }

        public static void Ejecutar()
        {
            Operacion op = Sumar;
            op += Restar;
            op += Multiplicar;
            op += Dividir;

            Console.WriteLine("Probando con (8, 2):");
            op(8, 2);

            Console.WriteLine("Probando con (8, 0):");
            op(8, 0);
        }
    }

    // ---------------------------------------------------------
    // Ejercicio 5: Delegados y Retornos
    // ---------------------------------------------------------
    class Ejercicio5
    {
        public delegate int Operacion(int a, int b);

        public static int Sumar(int a, int b) => a + b;
        public static int Restar(int a, int b) => a - b;
        public static int Multiplicar(int a, int b) => a * b;

        public static void EjecutarEImprimir(Operacion op, int x, int y)
        {
            Console.WriteLine($"Resultado de {op.Method.Name}({x}, {y}): {op(x, y)}");
        }

        public static void Ejecutar()
        {
            EjecutarEImprimir(Sumar, 7, 3);
            EjecutarEImprimir(Restar, 7, 3);
            EjecutarEImprimir(Multiplicar, 7, 3);
        }
    }

    // ---------------------------------------------------------
    // Ejercicio 6: Delegados y Nombres
    // ---------------------------------------------------------
    class Ejercicio6
    {
        public delegate int Operar(int a, int b);

        public static int Suma(int a, int b) => a + b;
        public static int Resta(int a, int b) => a - b;
        public static int Multiplicacion(int a, int b) => a * b;

        public static void Ejecutar()
        {
            Operar op = Suma;
            op += Resta;
            op += Multiplicacion;

            foreach (Operar metodo in op.GetInvocationList())
            {
                int resultado = metodo(9, 3);
                Console.WriteLine($"Método: {metodo.Method.Name} -> Resultado: {resultado}");
            }
        }
    }

    // ---------------------------------------------------------
    // Ejercicio 7: Delegados y Arrays
    // ---------------------------------------------------------
    class Ejercicio7
    {
        public delegate int OperarArray(int[] numeros);

        public static int Suma(int[] numeros)
        {
            int total = 0;
            foreach (int n in numeros) total += n;
            return total;
        }

        public static int Multiplicacion(int[] numeros)
        {
            if (numeros.Length == 0) return 0;
            int total = 1;
            foreach (int n in numeros) total *= n;
            return total;
        }

        public static void Ejecutar()
        {
            int[] datos = { 2, 3, 4 };
            OperarArray op = Suma;
            op += Multiplicacion;

            foreach (OperarArray metodo in op.GetInvocationList())
            {
                Console.WriteLine($"Método: {metodo.Method.Name} -> Resultado: {metodo(datos)}");
            }
        }
    }

    // ---------------------------------------------------------
    // Ejercicio 8: Delegados y Retornos Condicionales
    // ---------------------------------------------------------
    class Ejercicio8
    {
        public delegate int Transformar(int numero);

        public static int Doblar(int n) => n * 2;
        public static int Triplicar(int n) => n * 3;
        public static int Cuadrado(int n) => n * n;

        public static void Ejecutar()
        {
            int valor = 4;
            Transformar trans = Doblar;
            trans += Triplicar;
            trans += Cuadrado;

            foreach (Transformar metodo in trans.GetInvocationList())
            {
                Console.WriteLine($"{metodo.Method.Name} de {valor} = {metodo(valor)}");
            }
        }
    }

    // ---------------------------------------------------------
    // Ejercicio 9: Delegados y Funciones de Callback
    // ---------------------------------------------------------
    class Ejercicio9
    {
        public delegate int OperacionCallback(int a, int b);

        public static int EjecutarOperacion(OperacionCallback callback, int a, int b)
        {
            return callback(a, b);
        }

        public static int Suma(int a, int b) => a + b;
        public static int Resta(int a, int b) => a - b;
        public static int Multiplicar(int a, int b) => a * b;

        public static void Ejecutar()
        {
            Console.WriteLine($"Callback Suma: {EjecutarOperacion(Suma, 12, 4)}");
            Console.WriteLine($"Callback Resta: {EjecutarOperacion(Resta, 12, 4)}");
            Console.WriteLine($"Callback Multiplicar: {EjecutarOperacion(Multiplicar, 12, 4)}");
        }
    }

    // ---------------------------------------------------------
    // Ejercicio 10: Delegados y Manejo de Errores
    // ---------------------------------------------------------
    class Ejercicio10
    {
        public delegate double Calculo(double numero);

        public static double RaizCuadrada(double n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n), "No se puede calcular la raíz cuadrada de un número negativo.");
            return Math.Sqrt(n);
        }

        public static double Logaritmo(double n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException(nameof(n), "El logaritmo solo está definido para números positivos mayores que cero.");
            return Math.Log(n);
        }
        public static void ProcesarCalculo(Calculo calc, double numero)
        {
            try
            {
                double resultado = calc(numero);
                Console.WriteLine($"{calc.Method.Name}({numero}) = {resultado:F4}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en {calc.Method.Name}({numero}): {ex.Message}");
            }
        }
        public static void Ejecutar()
        {
            ProcesarCalculo(RaizCuadrada, 16);
            ProcesarCalculo(RaizCuadrada, -9);
            ProcesarCalculo(Logaritmo, 10);
            ProcesarCalculo(Logaritmo, 0);
        }
    }
}
