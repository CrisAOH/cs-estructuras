using System;

namespace ReservacionVuelos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CompraBoletos compraBoletos = new CompraBoletos();
            compraBoletos.Reservacion();
        }
    }

    struct Cliente
    {
        string nombre;
        string apellido;
        string id;
        int edad;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Id { get => id; set => id = value; }
        public int Edad { get => edad; set => edad = value; }
    }

    enum Destinos
    { 
        Guadalajara = 900,
        Monterrey = 1000,
        LA = 1700
    }

    enum Horarios
    { 
        SieteAM = 7,
        TresPM = 15,
        OchoPM = 20
    }

    enum SeccionAvion
    { 
        Atras = 0,
        Centro = 50,
        Adelante = 80
    }

    enum TipoAsiento
    { 
        Medio = 20,
        Pasillo = 60,
        Ventana = 90
    }

    class CompraBoletos 
    {
        Destinos destinoSeleccionado;
        Horarios horarioSeleccionado;
        SeccionAvion seccionSeleccionada;
        TipoAsiento asientoEscogida;

        int precioBase;
        int precioSeccion;
        int precioAsiento;
        int precioFinal;

        public void Reservacion()
        {
            Console.WriteLine("\n\t\tBienvenido a la reserva de vuelos\n");

            Cliente cliente = new Cliente();

            Console.WriteLine("Ingrese la información que se solicita a continuación\n");

            Console.Write("Nombre: ");
            cliente.Nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            cliente.Apellido = Console.ReadLine();
            Console.Write("Edad: ");
            cliente.Edad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Número de identificación oficial: ");
            cliente.Id = Console.ReadLine();

            SeleccionarDestino();
            SeleccionarHorario();
            SeleccionarSeccion();
            SeleccionarAsiento();
            ResumenReservacion(cliente);

        }

        public void SeleccionarDestino()
        {
            int opcionDestino;
            int indice = 1;

            Console.WriteLine("\nDestinos disponibles:\n");

            foreach (Destinos elemento in Enum.GetValues(typeof(Destinos)))
            {
                Console.WriteLine($"{indice++}. {elemento} - ${(int)elemento}");
            }

            Console.Write("Seleccione un destino: ");
            opcionDestino = Convert.ToInt32(Console.ReadLine());

            switch (opcionDestino)
            {
                case 1:
                    destinoSeleccionado = Destinos.Guadalajara;
                    precioBase = (int)destinoSeleccionado;
                    break;
                case 2:
                    destinoSeleccionado = Destinos.Monterrey;
                    precioBase = (int)destinoSeleccionado;
                    break;
                case 3:
                    destinoSeleccionado = Destinos.LA;
                    precioBase = (int)destinoSeleccionado;
                    break;
                default:
                    Console.WriteLine("Destino no válido.");
                    break;
            }
        }

        public void SeleccionarHorario()
        {
            int opcionHorario;
            int indice = 1;

            Console.WriteLine("\nHorarios disponibles:\n");

            foreach (Horarios elemento in Enum.GetValues(typeof(Horarios))) 
            {
                Console.WriteLine($"{indice++}. {(int)elemento}:00");
            }


            Console.Write("Selecciona un horario: ");
            opcionHorario = Convert.ToInt32(Console.ReadLine());

            switch (opcionHorario)
            {
                case 1:
                    horarioSeleccionado = Horarios.SieteAM;
                    break;
                case 2:
                    horarioSeleccionado = Horarios.TresPM;
                    break;
                case 3:
                    horarioSeleccionado = Horarios.OchoPM;
                    break;
                default:
                    Console.WriteLine("Horario no valido.)";
                    break;
            }
        }

        public void SeleccionarSeccion()
        {
            int opcionSeccion;
            int indice = 1;

            Console.WriteLine("\nSecciones disponibles:\n");

            foreach (SeccionAvion elemento in Enum.GetValues(typeof(SeccionAvion)))
            {
                Console.WriteLine($"{indice++}. {elemento} - ${(int)elemento}");
            }


            Console.Write("Selecciona la sección de tu preferencia: ");
            opcionSeccion = Convert.ToInt32(Console.ReadLine());

            switch (opcionSeccion)
            {
                case 1:
                    seccionSeleccionada =SeccionAvion.Atras;
                    precioSeccion = (int)seccionSeleccionada;
                    break;
                case 2:
                    seccionSeleccionada = SeccionAvion.Centro;
                    precioSeccion = (int)seccionSeleccionada;
                    break;
                case 3:
                    seccionSeleccionada = SeccionAvion.Adelante;
                    precioSeccion = (int)seccionSeleccionada;
                    break;
                default:
                    Console.WriteLine("Sección no válida.)";
                    break;
            }
        }

        public void SeleccionarAsiento()
        {
            int opcionAsiento = 1;
            int indice = 1;

            Console.WriteLine("\nAsientos disponibles:\n");

            foreach (TipoAsiento elemento in Enum.GetValues(typeof(TipoAsiento)))
            {
                Console.WriteLine($"{indice++}. {elemento} - ${(int)elemento}");
            }


            Console.Write("Selecciona el tipo de asiento de tu preferencia: ");
            opcionAsiento = Convert.ToInt32(Console.ReadLine());

            switch (opcionAsiento)
            {
                case 1:
                    asientoEscogida = TipoAsiento.Medio;
                    precioAsiento = (int)asientoEscogida;
                    break;
                case 2:
                    asientoEscogida = TipoAsiento.Pasillo;
                    precioAsiento = (int)asientoEscogida;
                    break;
                case 3:
                    asientoEscogida = TipoAsiento.Ventana;
                    precioAsiento = (int)asientoEscogida;
                    break;
                default:
                    Console.WriteLine("Asiento no válido.)";
                    break;
            }
        }

        public void ResumenReservacion(Cliente cliente)
        {
            Console.Clear();

            Console.WriteLine("Resumen de la reserva:\n");
            Console.WriteLine($"Nombre: {cliente.Nombre} {cliente.Apellido}");
            Console.WriteLine($"Edad: {cliente.Edad}");
            Console.WriteLine($"Número de identificación oficial: {cliente.Id}");
            Console.WriteLine($"Destino: {destinoSeleccionado} - ${(int)destinoSeleccionado}");
            Console.WriteLine($"Horario: {(int)horarioSeleccionado}:00");
            Console.WriteLine($"Sección: {seccionSeleccionada} - ${(int)seccionSeleccionada}");
            Console.WriteLine($"Asiento: {asientoEscogida} - ${(int)asientoEscogida}");
            Console.WriteLine($"Precio Total: ${precioFinal = precioBase + precioSeccion + precioAsiento}");

            Console.Write("\nConfirme su reserva (Presione cualquier tecla para continuar): ");
            Console.ReadKey();
        }
    }
}
