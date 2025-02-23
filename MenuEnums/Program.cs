namespace MenuEnums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 2;
            OpcionesMenu opcion;

            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicación");
            Console.WriteLine("4. División");

            Console.Write("Elige una opción: ");
            opcion = (OpcionesMenu)Enum.Parse(typeof(OpcionesMenu), Console.ReadLine());

            switch (opcion)
            {
                case OpcionesMenu.Suma:
                    Console.WriteLine($"{a} + {b} = {a + b}");
                    break;
                case OpcionesMenu.Resta:
                    Console.WriteLine($"{a} - {b} = {a - b}");
                    break;
                case OpcionesMenu.Multiplicacion:
                    Console.WriteLine($"{a} * {b} = {a * b}");
                    break;
                case OpcionesMenu.Division:
                    Console.WriteLine($"{a} / {b} = {a / b}");
                    break;
            }
        }
    }

    enum OpcionesMenu
    { 
        Suma, Resta, Multiplicacion, Division
    }
}
