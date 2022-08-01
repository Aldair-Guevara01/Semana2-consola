using System;


namespace Calculator
    {
        class Calculator
        {
            public static double DoOperation(double num1, double num2, string op)
            {
                double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.

                // Use a switch statement to do the math.
                switch (op)
                {
                    case "a":
                        result = num1 + num2;
                        break;
                    case "s":
                        result = num1 - num2;
                        break;
                    case "m":
                        result = num1 * num2;
                        break;
                    case "d":
                        // Ask the user to enter a non-zero divisor.
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        break;
                    // Return text for an incorrect option entry.
                    default:
                        break;
                }
                return result;
            }
        }

        class Program

        {
            static void Main(string[] args)
            {
                bool endApp = false;
                // Display title as the C# console calculator app.
                Console.WriteLine("Calculadora de consola en C#\r");
                Console.WriteLine("------------------------\n");

                while (!endApp)
                {
                    // Declare variables and set to empty.
                    string numInput1 = "";
                    string numInput2 = "";
                    double result = 0;

                    // Ask the user to type the first number.
                    Console.Write("Escriba un número y luego presione Enter: ");
                    numInput1 = Console.ReadLine();

                    double cleanNum1 = 0;
                    while (!double.TryParse(numInput1, out cleanNum1))
                    {
                        Console.Write("Esta no es una entrada válida. Por favor ingrese un valor entero: ");
                        numInput1 = Console.ReadLine();
                    }

                    // Ask the user to type the second number.
                    Console.Write("Escriba otro número y luego presione Enter: ");
                    numInput2 = Console.ReadLine();

                    double cleanNum2 = 0;
                    while (!double.TryParse(numInput2, out cleanNum2))
                    {
                        Console.Write("Esta no es una entrada válida. Por favor ingrese un valor entero: ");
                        numInput2 = Console.ReadLine();
                    }

                    // Ask the user to choose an operator.
                    Console.WriteLine("Elija un operador de la siguiente lista:");
                    Console.WriteLine("\ta - Sumar");
                    Console.WriteLine("\ts - Restar");
                    Console.WriteLine("\tm - Multiplicar");
                    Console.WriteLine("\td - Dividir");
                    Console.Write("¿Tu opción? ");

                    string op = Console.ReadLine();

                    try
                    {
                        result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("Esta operación dará como resultado un error matemático.\n");
                        }
                        else Console.WriteLine("Tu resultado: {0:0.##}\n", result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("¡Oh, no! Ocurrió una excepción tratando de hacer los cálculos.\n - Detalles: " + e.Message);
                    }

                    Console.WriteLine("------------------------\n");

                    // Wait for the user to respond before closing.
                    Console.Write("Presione 'n' y Enter para cerrar la aplicación, o presione cualquier otra tecla y Enter para continuar: ");
                    if (Console.ReadLine() == "n") endApp = true;

                    Console.WriteLine("\n"); // Friendly linespacing.
                }
                return;
            }
        }
    }


    

