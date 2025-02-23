using System;

namespace EjercicioEstructuras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool repetir = true;
            string opcion;

            Biblioteca biblioteca1 = new Biblioteca();

            do
            {
                Console.WriteLine("\nBiblioteca\n");
                Console.WriteLine("1. Agregar un libro");
                Console.WriteLine("2. Mostrar todos los libros");
                Console.WriteLine("3. Búsqueda exacta de un libro");
                Console.WriteLine("4. Búsqueda parcial de un libro");
                Console.WriteLine("5. Eliminar un libro");
                Console.WriteLine("6. Salir");

                Console.Write("\nIngresar una opción: ");
                opcion = Console.ReadLine();

                switch (opcion) 
                {
                    case "1":
                        biblioteca1.AgregarLibro();
                        break;
                    case "2":
                        biblioteca1.MostrarLibros();
                        break;
                    case "3":
                        biblioteca1.BuscarLibro();
                        break;
                    case "4":
                        biblioteca1.BusquedaParcial();
                        break;
                    case "5":
                        biblioteca1.EliminarLibro();
                        break;
                    case "6":
                        repetir = false;
                        break;
                    default:
                        Console.WriteLine("Esa opción no está disponible. Inténtalo de nuevo.");
                        break;
                }
            }
            while (repetir);
        }
    }

    class Biblioteca
    {
        Libro[] libros;
        int cantidadLibros = 0;
        string buscarLibro;
        bool libroEncontrado;
        int posicionLibroEliminar;

        public Biblioteca()
        {
            libros = new Libro[1000];
        }

        public void AgregarLibro()
        {
            if (cantidadLibros < libros.Length)
            {
                Console.Clear();
                Console.WriteLine($"Ingresar información para el libros {cantidadLibros + 1}\n");

                Console.Write("Ingresa el nombre del libro: ");
                libros[cantidadLibros].Titulo = Console.ReadLine();
                Console.Write("Ingresa el autor: ");
                libros[cantidadLibros].Autor = Console.ReadLine();
                Console.Write("Ingresa el año: ");
                libros[cantidadLibros].Anio = Console.ReadLine();

                cantidadLibros++;

                Console.Clear();
                Console.WriteLine("Libro agregado correctamente!\n");
            }
            else
            {
                Console.WriteLine("Biblioteca llena. Intenta eliminar un libro.");
            }
        }

        public void MostrarLibros() 
        {
            Console.Clear();
            if (cantidadLibros == 0)
            {
                Console.WriteLine("Biblioteca vacía. Agrega libros para poder visualizarlos.");
            }
            else
            {
                for (int i = 0; i < cantidadLibros; i++)
                {
                    Console.WriteLine($"{i + 1}.- Título = {libros[i].Titulo}, Autor = {libros[i].Autor}, Año = {libros[i].Anio}");
                }

                Console.Write("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void BuscarLibro()
        {
            Console.Clear();

            Console.Write("Ingresa el nombre exacto del libro para buscarlo: ");
            buscarLibro = Console.ReadLine();

            libroEncontrado = false;

            for (int i = 0; i < cantidadLibros; i++)
            {
                if (libros[i].Titulo.Equals(buscarLibro))
                {
                    Console.WriteLine($"El libro \"{libros[i].Titulo}\" del autor(a) \"{libros[i].Autor}\" se encuentra disponible en la biblioteca en el índice {i + 1}");
                    libroEncontrado = true;
                }
            }

            if (!libroEncontrado)
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }

        public void BusquedaParcial()
        {
            Console.Clear();

            Console.Write("Ingresa al menos una parte del título o del nombre del autor de un libro para buscarlo: ");
            buscarLibro = Console.ReadLine();

            for (int i = 0; i < cantidadLibros; i++)
            {
                if (libros[i].Titulo.ToLower().Contains(buscarLibro) || libros[i].Autor.ToLower().Contains(buscarLibro))
                {
                    Console.WriteLine($"La palabra \"{buscarLibro}\" fue encontrada en el libro \"{libros[i].Titulo}\" del autor \"{libros[i].Autor}\" en el índice {i + 1}");
                    libroEncontrado = true;
                }
            }

            if (!libroEncontrado)
            {
                Console.WriteLine("No se encontraron coincidencias.");
            }
        }

        public void EliminarLibro()
        {
            Console.Clear();

            if (cantidadLibros == 0)
            {
                Console.WriteLine("La biblioteca está vacía, no hay nada para eliminar.");
            }
            else
            {
                Console.Write($"Ingrese el número del libro que desea eliminar (Del 1 al {cantidadLibros}): ");
                posicionLibroEliminar = Convert.ToInt32(Console.ReadLine()) - 1;

                if (posicionLibroEliminar >= 0 && posicionLibroEliminar < cantidadLibros)
                {
                    Console.WriteLine($"¿El libro que deseas elimniar es: \"{libros[posicionLibroEliminar].Titulo}\"? (Sí/No)");
                    string opcion = Console.ReadLine().ToLower();

                    if (opcion == "si")
                    {
                        string tituloEliminado = libros[posicionLibroEliminar].Titulo;
                        string autorEliminado = libros[posicionLibroEliminar].Autor;

                        for (int i = posicionLibroEliminar; i < cantidadLibros; i++)
                        {
                            libros[i] = libros[i + 1];
                        }
                        cantidadLibros--;
                        Console.WriteLine($"\nEl libro \"{tituloEliminado}\" del autor(a) \"{autorEliminado}\" fue eliminado.");
                    }
                    else
                    {
                        Console.WriteLine("Se ha cancelado la eliminación del libro.");
                    }
                }
                else
                {
                    Console.WriteLine("El número del libro no es válido.");
                }
            }
        }
    }

    struct Libro
    {
        string titulo;
        string autor;
        string anio;

        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Anio { get => anio; set => anio = value; }
    }
}
