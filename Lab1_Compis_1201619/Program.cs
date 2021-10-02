using System;

namespace Lab1_Compis_1201619
{
    class Program
    {
        static void Main(string[] args)
        {
            string operacion;

            Console.WriteLine("Lab1");
            Console.WriteLine("Seleccione una opción");
            Console.WriteLine("1. -> Scanner");
            Console.WriteLine("2. -> Parser");
            int Opcion = Convert.ToInt32((Console.ReadLine()));

            switch (Opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese una cadena");
                    operacion = Console.ReadLine();
                    Scanner scanner = new Scanner(operacion);
                    Token nextToken;

                    do
                    {
                        nextToken = scanner.GetToken();
                        Console.WriteLine("Token: {0}, Valor {1}",
                            nextToken.Tag,
                            nextToken.Value);

                    } while (nextToken.Tag != TokenType.EOF);
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Ingrese una cadena");
                    operacion = Console.ReadLine();

                    Parser parser = new Parser();
                    //parser.Parse(operacion);
                    Console.WriteLine(parser.Parse(operacion));
                    Console.ReadLine();
                    break;
                default:
                    break;
            }

           
        }

       
    }
}
