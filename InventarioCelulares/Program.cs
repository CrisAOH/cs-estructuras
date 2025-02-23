namespace InventarioCelulares
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool repetir = true;
            int opcion;

            Inventario inventario = new Inventario();

            do
            {
                Console.Clear();

                Console.WriteLine("\nInventario de celulares\n");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Mostrar inventario");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Salir");

                Console.Write("Selecciona una opción del menú: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        inventario.AgregarProducto();
                        break;
                    case 2:
                        inventario.MostrarProducto();
                        break;
                    case 3:
                        inventario.EliminarProducto();
                        break;
                    case 4:
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("Esa opción no se encuentra en el menú. Inténtelo de nuevo.\n");
                        break;
                }
            }
            while (repetir);
        }
    }

    class Inventario
    { 
        List<Celular> listaCelulares = new List<Celular>();

        public void AgregarProducto()
        {

            Celular celular = new Celular();
            Console.Write("Ingrese la marca del celular: ");
            celular.Marca = Console.ReadLine();

            Console.Write("Ingrese el modelo del celular: ");
            celular.Modelo = Console.ReadLine();

            Console.Write("Ingrese la capacidad de memoria del celular: ");
            celular.MemoriaPrincipal = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el precio del celular: ");
            celular.Precio = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el stock disponibles: ");
            celular.Stock = Convert.ToInt32(Console.ReadLine());

            listaCelulares.Add(celular);

            Console.Write("Producto agregado al inventario. Presiona cualquier tecla para continuar...");
            Console.ReadKey(); 
        }

        public void MostrarProducto()
        {
            Console.Clear();
            if (listaCelulares.Count == 0)
            {
                Console.WriteLine("No hay celulares para mostrar.");
            }
            else
            {
                Console.WriteLine("Inventario de productos: ");
                foreach (Celular elemento in listaCelulares)
                {
                    Console.WriteLine($"Marca: {elemento.Marca}\nModelo: {elemento.Modelo}\nMemoria Principal: {elemento.MemoriaPrincipal}\nPrecio: {elemento.Precio}\nStock: {elemento.Stock}");
                    Console.WriteLine("\n");
                }

                Console.Write("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
         
        public void EliminarProducto()
        {
            int productoEliminar;

            Console.Clear();

            if (listaCelulares.Count == 0)
            {
                Console.WriteLine("El inventario está vacío, no hay nada que pueda eliminar.");
            }
            else
            {
                Console.Write($"Ingresa el número del producto que deseas eliminar (del 1 al {listaCelulares.Count}): ");
                productoEliminar = Convert.ToInt32(Console.ReadLine());
                if (productoEliminar >= 0 && productoEliminar < listaCelulares.Count)
                {
                    Console.WriteLine($"¿El producto que deseas eliminar es: \"{listaCelulares[productoEliminar].Marca} {listaCelulares[productoEliminar].Modelo}\"? (Sí/No): ");
                    string opcion = Console.ReadLine().ToLower();

                    if (opcion == "si")
                    {
                        string marcaEliminada = listaCelulares[productoEliminar].Marca;
                        string modeloEliminado = listaCelulares[productoEliminar].Modelo;

                        listaCelulares.RemoveAt(productoEliminar);

                        Console.WriteLine($"\n¡El producto \"{marcaEliminada} {modeloEliminado}\" fue eliminado!");
                    }
                    else
                    {
                        Console.WriteLine("Operación cancelada.");
                    }
                }
                else
                { 
                    Console.WriteLine("Número de producto no válido, intenta nuevamente.");
                }
            }

            Console.Write("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    struct Celular
    {
        string marca;
        string modelo;
        int memoriaPrincipal;
        double precio;
        int stock;

        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int MemoriaPrincipal { get => memoriaPrincipal; set => memoriaPrincipal = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
