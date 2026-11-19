using System;
using System.Collections.Generic;

namespace EjerciciosDelegados
{
    // ==========================================
    // DECLARACIÓN DE CLASES Y DELEGADOS
    // ==========================================

    // Ejercicio 1
    delegate int Multiplicar(int a, int b);

    // Ejercicio 2
    delegate bool VerificarPalindromo(string texto);

    // Ejercicio 3
    delegate double ConvertirTemperatura(double celsius);

    // Ejercicio 4
    delegate bool EsMayorQueDiez(int numero);

    // Ejercicio 5
    delegate bool CompararLongitud(string s1, string s2);

    // Ejercicio 6
    delegate int CalcularFactorial(int numero);

    // Ejercicio 7
    delegate int ContarCaracteres(string texto);

    // Ejercicio 8
    delegate bool Operacion(int numero);

    // Ejercicio 9
    class Producto
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }
    delegate bool Filtro(Producto p);

    // Ejercicio 10
    class Empleado
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
    delegate bool FiltroEmpleado(Empleado e);

    // Ejercicio 11
    class Libro
    {
        public string Titulo { get; set; }
        public string Categoria { get; set; }
    }
    delegate bool FiltroLibros(Libro l);

    // Ejercicio 12
    class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnioFabricacion { get; set; }
    }
    delegate bool FiltroVehiculo(Vehiculo v);

    class Ejercicio1
    {
        public static void Ejecutar()
        {
            Multiplicar mult = delegate (int a, int b)
            {
                return a * b;
            };

            int a1 = 4, b1 = 3;
            int a2 = 7, b2 = 5;

            Console.WriteLine($"{a1} * {b1} = {mult(a1, b1)}");
            Console.WriteLine($"{a2} * {b2} = {mult(a2, b2)}");
        }
    }

    class Ejercicio2
    {
        public static void Ejecutar()
        {
            VerificarPalindromo esPalindromo = delegate (string texto)
            {
                char[] caracteres = texto.ToLower().ToCharArray();
                Array.Reverse(caracteres);
                string invertida = new string(caracteres);
                return texto.ToLower() == invertida;
            };

            string p1 = "radar";
            string p2 = "puerta";

            Console.WriteLine($"'{p1}' es un palíndromo: {esPalindromo(p1)}");
            Console.WriteLine($"'{p2}' es un palíndromo: {esPalindromo(p2)}");
        }
    }

    class Ejercicio3
    {
        public static void Ejecutar()
        {
            ConvertirTemperatura aFahrenheit = delegate (double c)
            {
                return (c * 9 / 5) + 32;
            };

            double t1 = 0;
            double t2 = 30;

            Console.WriteLine($"{t1}°C -> {aFahrenheit(t1)}°F");
            Console.WriteLine($"{t2}°C -> {aFahrenheit(t2)}°F");
        }
    }

    class Ejercicio4
    {
        public static void Ejecutar()
        {
            EsMayorQueDiez comprobar = delegate (int n)
            {
                return n > 10;
            };

            int n1 = 8;
            int n2 = 15;

            Console.WriteLine($"{n1} es mayor que 10: {comprobar(n1)}");
            Console.WriteLine($"{n2} es mayor que 10: {comprobar(n2)}");
        }
    }

    class Ejercicio5
    {
        public static void Ejecutar()
        {
            CompararLongitud mismaLongitud = delegate (string a, string b)
            {
                return a.Length == b.Length;
            };

            string palabra1 = "gato";
            string palabra2 = "perro";

            Console.WriteLine($"Las palabras '{palabra1}' y '{palabra2}' tienen la misma longitud: {mismaLongitud(palabra1, palabra2)}");
        }
    }

    class Ejercicio6
    {
        public static void Ejecutar()
        {
            CalcularFactorial factorial = delegate (int n)
            {
                int resultado = 1;
                for (int i = 2; i <= n; i++)
                {
                    resultado *= i;
                }
                return resultado;
            };

            Console.WriteLine($"Factorial de 4 es {factorial(4)}");
            Console.WriteLine($"Factorial de 6 es {factorial(6)}");
        }
    }

    class Ejercicio7
    {
        public static void Ejecutar()
        {
            ContarCaracteres contar = delegate (string s)
            {
                return s.Length;
            };

            string p1 = "mundo";
            string p2 = "programa";

            Console.WriteLine($"La palabra '{p1}' tiene {contar(p1)} caracteres");
            Console.WriteLine($"La palabra '{p2}' tiene {contar(p2)} caracteres");
        }
    }

    class Ejercicio8
    {
        static void ProcesarNumero(int numero, Operacion op)
        {
            bool resultado = op(numero);
            Console.WriteLine($"El número {numero} es par: {resultado}");
        }

        public static void Ejecutar()
        {
            Operacion esPar = delegate (int n)
            {
                return n % 2 == 0;
            };

            ProcesarNumero(4, esPar);
            ProcesarNumero(7, esPar);
        }
    }

    class Ejercicio9
    {
        static void MostrarProductosFiltrados(List<Producto> productos, Filtro filtro)
        {
            Console.WriteLine("Productos con cantidad mayor a 5:");
            foreach (Producto p in productos)
            {
                if (filtro(p))
                {
                    Console.WriteLine($"- {p.Nombre} (Cantidad: {p.Cantidad})");
                }
            }
        }

        public static void Ejecutar()
        {
            List<Producto> inventario = new List<Producto>
            {
                new Producto { Nombre = "Televisor", Cantidad = 10 },
                new Producto { Nombre = "Ratón", Cantidad = 3 },
                new Producto { Nombre = "Refrigerador", Cantidad = 7 },
                new Producto { Nombre = "Teclado", Cantidad = 5 }
            };

            Filtro mayorACinco = delegate (Producto p)
            {
                return p.Cantidad > 5;
            };

            MostrarProductosFiltrados(inventario, mayorACinco);
        }
    }

    class Ejercicio10
    {
        static void FiltrarEmpleados(List<Empleado> empleados, FiltroEmpleado filtro)
        {
            Console.WriteLine("Empleados mayores de 30 años:");
            foreach (Empleado e in empleados)
            {
                if (filtro(e))
                {
                    Console.WriteLine($"- {e.Nombre} (Edad: {e.Edad})");
                }
            }
        }

        public static void Ejecutar()
        {
            List<Empleado> plantilla = new List<Empleado>
            {
                new Empleado { Nombre = "Ana", Edad = 35 },
                new Empleado { Nombre = "Carlos", Edad = 28 },
                new Empleado { Nombre = "Luis", Edad = 42 },
                new Empleado { Nombre = "Marta", Edad = 30 }
            };

            FiltroEmpleado mayorDeTreinta = delegate (Empleado e)
            {
                return e.Edad > 30;
            };

            FiltrarEmpleados(plantilla, mayorDeTreinta);
        }
    }

    class Ejercicio11
    {
        static void MostrarLibrosPorCategoria(List<Libro> libros, FiltroLibros filtro)
        {
            Console.WriteLine("Libros de la categoría Ficción:");
            foreach (Libro l in libros)
            {
                if (filtro(l))
                {
                    Console.WriteLine($"- {l.Titulo}");
                }
            }
        }

        public static void Ejecutar()
        {
            List<Libro> biblioteca = new List<Libro>
            {
                new Libro { Titulo = "El Hobbit", Categoria = "Ficción" },
                new Libro { Titulo = "Breve historia del tiempo", Categoria = "Ciencia" },
                new Libro { Titulo = "Harry Potter", Categoria = "Ficción" },
                new Libro { Titulo = "Clean Code", Categoria = "Programación" }
            };

            FiltroLibros esFiccion = delegate (Libro l)
            {
                return l.Categoria == "Ficción";
            };

            MostrarLibrosPorCategoria(biblioteca, esFiccion);
        }
    }

    class Ejercicio12
    {
        static void MostrarVehiculosAntiguos(List<Vehiculo> vehiculos, FiltroVehiculo filtro)
        {
            Console.WriteLine("Vehículos fabricados antes de 2010:");
            foreach (Vehiculo v in vehiculos)
            {
                if (filtro(v))
                {
                    Console.WriteLine($"- {v.Marca} {v.Modelo} ({v.AnioFabricacion})");
                }
            }
        }

        public static void Ejecutar()
        {
            List<Vehiculo> taller = new List<Vehiculo>
            {
                new Vehiculo { Marca = "Toyota", Modelo = "Corolla", AnioFabricacion = 2005 },
                new Vehiculo { Marca = "Ford", Modelo = "Focus", AnioFabricacion = 2015 },
                new Vehiculo { Marca = "Honda", Modelo = "Civic", AnioFabricacion = 2008 },
                new Vehiculo { Marca = "Seat", Modelo = "Ibiza", AnioFabricacion = 2010 }
            };

            FiltroVehiculo antesDe2010 = delegate (Vehiculo v)
            {
                return v.AnioFabricacion < 2010;
            };

            MostrarVehiculosAntiguos(taller, antesDe2010);
        }
    }

    // ==========================================
    // PROGRAMA PRINCIPAL
    // ==========================================

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EJERCICIO 1 ===");
