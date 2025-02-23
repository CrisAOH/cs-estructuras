namespace VideojuegoEnum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombreJugador1, nombreJugador2;
            int primerTurno;

            Console.Write("Jugador 1, escoge tu nombre: ");
            nombreJugador1 = Console.ReadLine();

            Jugador jugador1 = new Jugador(nombreJugador1, 1000);

            jugador1.EscogerPersonaje();
            jugador1.EscogerArma();

            Console.Write("Jugador 2, escoge tu nombre: ");
            nombreJugador2 = Console.ReadLine();

            Jugador jugador2 = new Jugador(nombreJugador2, 1000);

            jugador1.EscogerPersonaje();
            jugador1.EscogerArma();

            primerTurno = Batalla.TirarDados();

            if (primerTurno == 1)
            {
                Console.WriteLine($"¡{jugador1.Nombre} empieza primero!\n");
                Batalla.SimularBatalla(jugador1, jugador2);
            }
            else
            {
                Console.WriteLine($"¡{jugador2.Nombre} empieza primero!\n");
                Batalla.SimularBatalla(jugador2 , jugador1);
            }

        }//FIN MAIN
    }//FIN PROGRAM

    enum TipoPersonaje 
    { 
        Escudero,
        Arquero,
        Caballero
    }

    enum TipoArma
    { 
        Espada, 
        Arco, 
        Martillo
    }

    class Jugador
    {
        string nombre;
        int salud;
        int ataque;
        int defensa;
        TipoPersonaje personajeSeleccionado;
        TipoArma armaEquipada;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Ataque { get => ataque; set => ataque = value; }
        public int Defensa { get => defensa; set => defensa = value; }
        internal TipoPersonaje PersonajeSeleccionado { get => personajeSeleccionado; set => personajeSeleccionado = value; }
        internal TipoArma ArmaEquipada { get => armaEquipada; set => armaEquipada = value; }

        Random random = new Random();

        public Jugador(string nombreParam, int saludParam) 
        {
            nombre = nombreParam;
            salud = saludParam;
        }

        public void EscogerPersonaje()
        {
            int opcion;

            Console.Clear();

            do
            {
                Console.WriteLine("1. Escudero");
                Console.WriteLine("2. Arquero");
                Console.WriteLine("3. Caballero");

                Console.Write($"\n{Nombre}, escoge un personaje: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        PersonajeSeleccionado = TipoPersonaje.Escudero;
                        ResumenPersonajeSeleciconado();
                        break;
                    case 2:
                        PersonajeSeleccionado = TipoPersonaje.Arquero;
                        ResumenPersonajeSeleciconado();
                        break;
                    case 3:
                        PersonajeSeleccionado = TipoPersonaje.Caballero;
                        ResumenPersonajeSeleciconado();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intenta de nuevo.");
                        break;
                }
            }
            while (opcion < 1 || opcion > 3);
        }

        public void ResumenPersonajeSeleciconado()
        {
            Console.WriteLine($"{Nombre}, ahora eres \"{PersonajeSeleccionado}\"");

            Console.Write("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();

            Console.Clear();
        }

        public void EscogerArma()
        {
            int opcion;

            Console.Clear();

            do
            {
                Console.WriteLine("1. Espada (Ataque: 130, Defensa: 40)");
                Console.WriteLine("2. Arco (Ataque: 140, Defensa: 30)");
                Console.WriteLine("3. Martillo (Ataque: 150, Defensa: 20)");

                Console.Write($"\n{Nombre}, escoge un arma: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        ArmaEquipada = TipoArma.Espada;
                        ResumenPersonajeSeleciconado();
                        break;
                    case 2:
                        ArmaEquipada = TipoArma.Arco;
                        ResumenPersonajeSeleciconado();
                        break;
                    case 3:
                        ArmaEquipada = TipoArma.Martillo;
                        ResumenPersonajeSeleciconado();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intenta de nuevo.");
                        break;
                }
            }
            while (opcion < 1 || opcion > 3 );
        }

        public void ValoresAtaqueDefensaArma()
        {
            switch (ArmaEquipada)
            {
                case TipoArma.Espada:
                    Ataque = 130;
                    Defensa = 40;
                    ValoresAtaqueDefensaArma();
                    ResumenArmaSeleccionada();
                    break;
                case TipoArma.Arco:
                    Ataque = 140;
                    Defensa = 30;
                    ValoresAtaqueDefensaArma();
                    ResumenArmaSeleccionada();
                    break;
                case TipoArma.Martillo:
                    Ataque = 150;
                    Defensa = 20;
                    ValoresAtaqueDefensaArma();
                    ResumenArmaSeleccionada();
                    break;
            }
        }

        public void ResumenArmaSeleccionada()
        {
            Console.WriteLine($"{Nombre}, escogiste \" {ArmaEquipada} \" con un nivel de ataque de [{Ataque}] y una defensa de [{Defensa}]");

            Console.Write("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();

            Console.Clear();
        }

        public void Atacar()
        { 
            Console.WriteLine($"\n¡{PersonajeSeleccionado} {Nombre} ataca con su {ArmaEquipada}!\n");
        }

        public void Defender()
        {
            Console.WriteLine($"\n¡{PersonajeSeleccionado} {Nombre} se defiende con su {ArmaEquipada}!\n");
        }

        public void SeleccionarAccion()
        {
            int opcion;

            do
            {
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Defender");
                Console.Write($"\n[{PersonajeSeleccionado} {Nombre}], elige una acción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Atacar();
                        break;
                    case 2:
                        Defender();
                        break;
                    default:
                        Console.WriteLine("Opci´´on inválida. Intenta de nuevo.");
                        break;
                }
            }
            while (opcion < 1 || opcion > 2); ;
        }

        public void ResumenJugador()
        {
            Console.WriteLine($"[{PersonajeSeleccionado} {Nombre}] Salud: {Salud} / [{ArmaEquipada}] Ataque: {Ataque}, Defensa: {Defensa}");
        }

        public void CalcularDanio(int ataqueOtroJugadorParam)
        {
            int dañoRecibido;
            int ataqueSorpresa;

            ataqueSorpresa = random.Next(-15, 16);

            dañoRecibido = ataqueOtroJugadorParam - Defensa + ataqueSorpresa;

            Salud -= dañoRecibido;
        }
    }

    class Batalla 
    {
        static Random random = new Random();
        public static int TirarDados()
        {
            Console.Write("Presiona cualquier tecla para tirar los dados y determinar quien comienza...");
            Console.ReadKey();
            Console.Clear();

            int primerTurno;

            primerTurno = random.Next(1, 3);
            return primerTurno;
        }

        public static void SimularBatalla(Jugador jugador1Param, Jugador jugador2Param)
        {
            int ronda = 1;

            Console.WriteLine("¡La batalla ha comenzado!");
            Console.WriteLine($"RONDA {ronda}\n");

            jugador1Param.ResumenJugador();
            jugador2Param.ResumenJugador();

            Console.WriteLine($"\n¡{jugador1Param.PersonajeSeleccionado} {jugador1Param.Nombre}, empieza a atacar!");
            Console.Write($"Presiona Enter para usar tu {jugador1Param.ArmaEquipada}...");
            Console.ReadKey();
            jugador1Param.Atacar();

            jugador2Param.CalcularDanio(jugador1Param.Ataque);

            jugador2Param.SeleccionarAccion();

            jugador1Param.CalcularDanio(jugador2Param.Ataque);

            for (int i = 2; i <= 5; i++)
            {
                Console.WriteLine($"RONDA {i}\n");
                jugador1Param.ResumenJugador();
                jugador2Param.ResumenJugador();

                jugador1Param.SeleccionarAccion();

                jugador2Param.CalcularDanio(jugador1Param.Ataque);

                jugador2Param.SeleccionarAccion();

                jugador1Param.CalcularDanio(jugador2Param.Ataque);

                Console.WriteLine();
            }

            Console.WriteLine("\n¡La batalla ha terminado!");

            jugador1Param.ResumenJugador();
            jugador2Param.ResumenJugador();

            if (jugador1Param.Salud > jugador2Param.Salud)
            {
                Console.WriteLine($"\n¡{jugador1Param.Nombre} ha ganado la batalla!");
            }
            else
            {
                Console.WriteLine($"\n¡{jugador2Param.Nombre} ha ganado la batalla!");
            }
        }
    }

}//FIN NAMESPACE
