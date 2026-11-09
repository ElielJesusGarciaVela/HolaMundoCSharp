using System;

class Program
{
    static void Main(string[] args)
    {
        // Descomenta para probar los ejercicios
        Ejercicio1();
    }

    public static void Ejercicio1()
    {
        Console.Write("Introduce el tamaño del array: ");
        int tamano = int.Parse(Console.ReadLine());
        int[] numeros = new int[tamano];
        int suma = 0;

        for (int i = 0; i < tamano; i++)
        {
            Console.Write($"Introduce el valor para el componente {i}: ");
            numeros[i] = int.Parse(Console.ReadLine());
            suma += numeros[i];
        }

        double media = (double)suma / tamano;
        Console.WriteLine($"Suma: {suma}");
        Console.WriteLine($"Media: {media}");
    }

    public static int ContarEspacios(string cadena)
    {
        int contador = 0;
        foreach (char c in cadena)
        {
            if (c == ' ')
            {
                contador++;
            }
        }
        return contador;
    }

    public static void Ejercicio2()
    {
        Console.Write("Introduce una cadena de texto: ");
        string texto = Console.ReadLine();
        int espacios = ContarEspacios(texto);
        Console.WriteLine($"Número de espacios en blanco: {espacios}");
    }

    public static long CalcularFactorial(int n)
    {
        if (n <= 1) return 1;
        return n * CalcularFactorial(n - 1);
    }

    public static void Ejercicio3()
    {
        Console.Write("Introduce un número para calcular su factorial: ");
        int numero = int.Parse(Console.ReadLine());
        long resultado = CalcularFactorial(numero);
        Console.WriteLine($"El factorial de {numero} es: {resultado}");
    }

    public static bool EsPrimo(int numero)
    {
        if (numero <= 1) return false;
        for (int i = 2; i * i <= numero; i++)
        {
            if (numero % i == 0) return false;
        }
        return true;
    }

    public static void Ejercicio4()
    {
        Console.Write("Introduce un número: ");
        int numero = int.Parse(Console.ReadLine());
        if (EsPrimo(numero))
        {
            Console.WriteLine("El número es primo.");
        }
        else
        {
            Console.WriteLine("El número no es primo.");
        }
    }

    public static double PotenciaIterativa(double baseNum, int exponente)
    {
        double resultado = 1;
        int expAbs = Math.Abs(exponente);
        for (int i = 0; i < expAbs; i++)
        {
            resultado *= baseNum;
        }
        return exponente < 0 ? 1 / resultado : resultado;
    }

    public static double PotenciaRecursiva(double baseNum, int exponente)
    {
        if (exponente == 0) return 1;
        if (exponente < 0) return 1 / PotenciaRecursiva(baseNum, -exponente);
        return baseNum * PotenciaRecursiva(baseNum, exponente - 1);
    }

    public static void Ejercicio5()
    {
        Console.Write("Introduce la base: ");
        double baseNum = double.Parse(Console.ReadLine());
        Console.Write("Introduce el exponente: ");
        int exponente = int.Parse(Console.ReadLine());

        Console.WriteLine($"Iterativa: {PotenciaIterativa(baseNum, exponente)}");
        Console.WriteLine($"Recursiva: {PotenciaRecursiva(baseNum, exponente)}");
    }

    public static bool ControlarLogin(string usuario, string contrasena)
    {
        return usuario == "usuario2DAM" && contrasena == "pass2DAM";
    }

    public static void Ejercicio6()
    {
        int intentos = 0;
        bool autenticado = false;

        while (intentos < 3 && !autenticado)
        {
            Console.Write("Usuario: ");
            string user = Console.ReadLine();
            Console.Write("Contraseña: ");
            string pass = Console.ReadLine();

            autenticado = ControlarLogin(user, pass);
            intentos++;

            if (autenticado)
            {
                Console.WriteLine("Login correcto.");
            }
            else
            {
                Console.WriteLine($"Incorrecto. Intentos restantes: {3 - intentos}");
            }
        }

        if (!autenticado)
        {
            Console.WriteLine("Acceso bloqueado. Superado el límite de intentos.");
        }
    }

    public static bool EsMultiplo(int num1, int num2)
    {
        if (num2 == 0) return false;
        return num1 % num2 == 0;
    }

    public static void Ejercicio7()
    {
        Console.Write("Introduce el primer número: ");
        int n1 = int.Parse(Console.ReadLine());
        Console.Write("Introduce el segundo número: ");
        int n2 = int.Parse(Console.ReadLine());

        if (EsMultiplo(n1, n2) || EsMultiplo(n2, n1))
        {
            Console.WriteLine("Uno de los números es múltiplo del otro.");
        }
        else
        {
            Console.WriteLine("No son múltiplos entre sí.");
        }
    }

    public static int SumarDigitos(int numero)
    {
        int suma = 0;
        numero = Math.Abs(numero);
        while (numero > 0)
        {
            suma += numero % 10;
            numero /= 10;
        }
        return suma;
    }

    public static void Ejercicio8()
    {
        Console.Write("Introduce un número entero: ");
        int numero = int.Parse(Console.ReadLine());
        Console.WriteLine($"La suma de los dígitos es: {SumarDigitos(numero)}");
    }

    public static int PosicionMenor(int[] array)
    {
        if (array.Length == 0) return -1;
        int indiceMenor = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[indiceMenor])
            {
                indiceMenor = i;
            }
        }
        return indiceMenor;
    }

    public static void Ejercicio9()
    {
        int[] miArray = { 15, 23, 4, 89, 2, 42 };
        int pos = PosicionMenor(miArray);
        Console.WriteLine($"La posición del número menor es: {pos}");
    }

    public static void Ejercicio10()
    {
        Banco miBanco = new Banco();
        miBanco.Operar();
        miBanco.ObtenerEstado();
    }
}

class Cliente
{
    private string nombre;
    private double cantidadTotal;

    public Cliente(string nombre)
    {
        this.nombre = nombre;
        this.cantidadTotal = 0;
    }

    public void Ingresar(double cantidad)
    {
        cantidadTotal += cantidad;
    }

    public void Sacar(double cantidad)
    {
        cantidadTotal -= cantidad;
    }

    public double GetCantidadTotal()
    {
        return cantidadTotal;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Cliente: {nombre} - Saldo: {cantidadTotal}");
    }
}

class Banco
{
    private Cliente cliente1;
    private Cliente cliente2;
    private Cliente cliente3;

    public Banco()
    {
        cliente1 = new Cliente("Ana");
        cliente2 = new Cliente("Pedro");
        cliente3 = new Cliente("María");
    }

    public void Operar()
    {
        cliente1.Ingresar(150.50);
        cliente2.Ingresar(300.00);
        cliente3.Ingresar(50.25);
    }

    public void ObtenerEstado()
    {
        double totalBanco = cliente1.GetCantidadTotal() + cliente2.GetCantidadTotal() + cliente3.GetCantidadTotal();
        Console.WriteLine($"Dinero total en el banco: {totalBanco}");

        cliente1.MostrarInformacion();
        cliente2.MostrarInformacion();
        cliente3.MostrarInformacion();
    }
}
