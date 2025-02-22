using System;
using System.Xml.Serialization;

class Program
{

    static double comprobaciondouble(double num)
    {
        while (!double.TryParse(Console.ReadLine(), out num))
        {
            Console.WriteLine("Caracter invalido. Intente nuevamente");
            Console.Write("Ingrese un numero: ");
        }
        return num;

    }

    static int comprobacionint(int num)
    {
        while (!int.TryParse(Console.ReadLine(), out num))
        {
            Console.WriteLine("Caracter invalido. Intente nuevamente");
            Console.Write("Ingrese un numero: ");
        }
        return num;

    }

    static int Rango(int x, int y, int z=0) 
    {
        z = comprobacionint(z);
        while (z < x || z > y)
        {
            Console.WriteLine("Numero fuera de rango. Intente de nuevo");
            Console.Write("Ingrese un numero: ");
            z = comprobacionint(z);
        }
        return z;
    }
    static void MenuPrincipal()
    {
        Console.WriteLine("1. Calculadora \n2. Validacion de Contraseña \n3. Numeros Primos \n4. Suma de numeros pares \n5. Conversion de temperatura" +
            "\n6. Contador de Vocales \n7. Calculo factorial \n8. Juego de Adivinanza \n9. Paso Por Referencia \n10. Tablas de Multiplicar \n11. Salir");
        Console.Write("Seleccione una opcion: ");
    }


    static void Calculadora()
    {
        int opcioncalculadora=0;
        double n1=0, n2=0;
        Console.Write("Ingrese el primer digito: ");
        n1=comprobaciondouble(n1);
        Console.Write("Ingrese el segundo digito: ");
        n2=comprobaciondouble(n2);
        Console.Write("1. Suma \n2. Resta \n3. Multiplicacion \n4. Division \n5. Salir \nSeleccione: ");
        opcioncalculadora = Rango(1, 5, opcioncalculadora);

        switch (opcioncalculadora)
        {
            case 1:
                Console.WriteLine($"\nEl resultado de la suma es: {n1 + n2}");
                break;
            case 2:
                Console.WriteLine($"\nEl resultado de la resta es: {n1 - n2}");
                break;
            case 3:
                Console.WriteLine($"\nEl resultado de la multiplicacion es: {n1 * n2}");
                break;
            case 4:
                Console.WriteLine($"\nEl resultado de la division es: {n1 / n2}");
                break;

        }
    }

    static void ValidacionContraseña()
    {
        string contraseña;

        do
        {
            Console.Write("Ingrese la contraseña: ");
            contraseña = Console.ReadLine();
            if (contraseña == "1234")
            {
                Console.WriteLine("¡Contraseña Correcta. Acceso concedido!");
            }
            else
            {
                Console.WriteLine("Contraseña Incorrecta. Intente de nuevo");
            }

        } while (contraseña != "1234");
    }

    static void NumerosPrimos()
    {
        int numero=0, residuo;
        Console.Write("Ingrese un numero: ");
        numero = comprobacionint(numero);

        if (numero < 2)
        {
            Console.WriteLine("El numero no es primo");
            return;
        }
        else if (numero % 2 == 0)
        {
            Console.WriteLine("El numero no es primo");
            return;
        }
        else
        {
            for (int i = 3; i <= Math.Sqrt(numero); i+=2)
            {
                if (numero % i == 0)
                {
                    Console.WriteLine("El numero no es primo");
                    return;
                }
            }

            Console.WriteLine("El numero es primo");
        }
    }

    static void SumaPares()
    {
        int n1=1, suma = 0;

        while (n1 != 0)
        {
            Console.WriteLine("Ingrese un numero: ");
            n1 = comprobacionint(n1);

            if (n1 % 2 == 0)
            {
                suma += n1;
            }
        }
        Console.WriteLine($"La suma de los numeros pares es: {suma}");
    }

    static void ConversionTemperatura()
    {
        double n1=0;

        double CelsiusAFar(double x)
        {
            double resultado = (x * 9/5) + 32;
            return resultado;
        }

        double FarACelsius(double x)
        {
            double resultado = (x - 32) * 5/9;
            return resultado;
        }

        Console.WriteLine("1. Celsius a Fahrenheit \n2. Fahrenheit a Celsius");
        Console.Write("Seleccione una opcion: ");
        int opcion = 0;
        opcion = Rango(1, 2, opcion);

        if (opcion == 1)
        {
            Console.WriteLine("Ingrese la temperatura en grados Celsius: ");
            n1 = comprobaciondouble(n1);
            Console.WriteLine($"La temperatura en grados Fahrenheit es: {CelsiusAFar(n1)}");
        }
        else if (opcion == 2)
        {
            Console.WriteLine("Ingrese la temperatura en grados Fahrenheit: ");
            n1 = comprobaciondouble(n1);
            Console.WriteLine($"La temperatura en grados Celsius es: {FarACelsius(n1)}");

        }
    }
    static void ContadorVocales()
    {
        string palabra;
        char[] vocales = { 'a', 'e', 'i', 'o', 'u' };
        int contador = 0;
        Console.WriteLine("Ingrese una cadena de caracteres: ");
        palabra = Console.ReadLine();
        for (int i = 0; i < palabra.Length; i++)
        {
            for (int j = 0; j < vocales.Length; j++)
            {
                if (palabra[i] == vocales[j])
                {
                    contador++;
                }
            }
        }
        Console.WriteLine($"La cantidad de vocales es: {contador}");
    }

    static void Factorial()
    {
        int n1=0, factorial = 1;
        Console.Write("Ingrese un numero: ");
        n1 = comprobacionint(n1);
        if (n1 == 1 || n1 == 2)
        {
            Console.WriteLine($"El factorial de {n1} es: {n1}");
        }
        else if (n1 == 0)
        {
            Console.WriteLine("El factorial de 0 es 1");
        }
        else
        {
            for (int i = 1; i <= n1; i++)
            {
                factorial *= i;
            }
            Console.WriteLine($"El factorial de {n1} es: {factorial}");
        }
    }

    static void Adivinanza()
    {
        Random random = new Random();
        int numrandom = random.Next(1, 101);
        Console.Write("Adivina el numero (1 al 100): ");
        int num = 0;
        num = Rango(1,100, num);

        do
        {
            if (num <= (numrandom + 10) && num >= (numrandom - 10))
            {
                Console.WriteLine("Estas muy cerca. Intenta de Nuevo");
            }
            else if (num > (numrandom + 10))
            {
                Console.WriteLine("Demasiado alto. Intenta de Nuevo");
            }
            else if (num < (numrandom - 10))
            {
                Console.WriteLine("Demasiado bajo. Intenta de Nuevo");
            }
            Console.Write("Adivinar el numero: ");
            num = comprobacionint(num);

        } while (num != numrandom);

        Console.WriteLine("\n ¡Felicidades! Adivinaste el numero.");
    }

    static void PasoPorReferencia(ref int x, ref int y)
    {
        int z;
        z = x;
        x = y;
        y = z;

    }

    static void TablaMultiplicar(int x, int[] tabla)
    {
        for (int i = 1; i <= 10; i++)
        {
            tabla[i - 1] = x * i;
        }
    }

    static void MostrarTabla()
    {
        int[] tabla = new int[10];
        Console.Write("Ingrese el numero de la tabla de multiplicar: ");
        int num = 0;
        num = comprobacionint(num);
        TablaMultiplicar(num, tabla);
        Console.WriteLine($"La tabla del numero {num} es: ");
        for (int i = 0; i < tabla.Length; i++)
        {
            Console.WriteLine($"{num} x {i + 1} = {tabla[i]}");
        }
    }


    static void Main()
    {

        int centinela=0;
        int opcion = 0;
        do
        {
            MenuPrincipal();
            opcion = Rango(1, 11, opcion);
            switch (opcion)
            {

                case 1:
                    Calculadora();
                    break;

                case 2:
                    ValidacionContraseña();
                    break;

                case 3:
                    NumerosPrimos();
                    break;

                case 4:
                    SumaPares();
                    break;

                case 5:
                    ConversionTemperatura();
                    break;

                case 6:
                    ContadorVocales();
                    break;

                case 7:
                    Factorial();
                    break;

                case 8:
                    Adivinanza();
                    break;

                case 9:
                    int x=0, y=0;
                    Console.Write("Ingrese el valor de x: ");
                    x = comprobacionint(x);
                    Console.Write("Ingrese el valor de y: ");
                    y = comprobacionint(y);
                    Console.WriteLine($"Valores originales = x:{x} & y:{y}");
                    PasoPorReferencia(ref x, ref y);
                    Console.WriteLine($"Valores Intercambiados= x:{x} & y:{y}");
                    break;

                case 10:
                    MostrarTabla();
                    break;

                case 11:
                    Console.WriteLine("Saliendo del programa...");
                    return;
            }
            Console.Write("\nDesea realizar otra operacion? (1=Si/0=No): ");
            centinela = Rango(1,2,centinela);
        } while (centinela ==1);
        Console.WriteLine("Saliendo del programa...");
    }
}