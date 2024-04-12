using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tres_En_RayaPROJECT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jugarAGAIN = "";
            do
            {
                juegomain();
                Console.WriteLine("Desea volver a jugar? (SI o NO)");
                jugarAGAIN = Console.ReadLine();
                jugarAGAIN = jugarAGAIN.ToUpper();

            } while (jugarAGAIN != "NO");

            Console.WriteLine("Gracias por usar el juego.");
            Console.ReadLine();

        }

        static bool isEnd = false;
        static string jugador1 = "";
        static string jugador2 = "";
        static string ganador = "";
        static string[,] matriz = new string[,] {
                                                 { "a1", "a2", "a3" },
                                                 { "b1", "b2", "b3" },
                                                 { "c1", "c2", "c3" }
                                             };

        public static void juegomain()
        {
            Console.Clear();
            // metodos
            saludar();
            getPlayers();
            proccesGame();
            finalGame();
        }

        public static void saludar()
        {
            Console.WriteLine(" -------------------------------");
            Console.WriteLine("| BIENVENIDO AL JUEGO 3 EN RAYA |");
            Console.WriteLine(" -------------------------------");
        }

        public static void getPlayers()
        {
            Console.WriteLine("\nInserte el nombre del jugador 1: ");
            jugador1 = Console.ReadLine(); jugador1 = jugador1.ToUpper();
            Console.WriteLine("\nInserte el nombre del jugador 2: ");
            jugador2 = Console.ReadLine(); jugador2 = jugador2.ToUpper();
            Console.Clear();
        }
        static bool XorOBool = true;
        static string XorO = "X";
        public static void proccesGame()
        {
            string position = "";
            bool isValidPosition = false;
            int turnosMAX = 9;
            int turnoActual = 0;

            do
            {
                Console.WriteLine("  {0} v.s. {1}\n", jugador1, jugador2);
                Console.WriteLine("  {0} | {1} | {2}", matriz[0, 0], matriz[0, 1], matriz[0, 2]);
                Console.WriteLine(" --- --- ---");
                Console.WriteLine("  {0} | {1} | {2}", matriz[1, 0], matriz[1, 1], matriz[1, 2]);
                Console.WriteLine(" --- --- ---");
                Console.WriteLine("  {0} | {1} | {2}", matriz[2, 0], matriz[2, 1], matriz[2, 2]);
                Console.WriteLine("\n\n");
                do
                {
                    Console.WriteLine("\nEn que posicion desea poner su movimiento? (POR FAVOR ELIJA EL NOMBRE DE LAS POSICIONES QUE SE VEN EN PANTALLA)");
                    position = Console.ReadLine();

                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            if ((position == matriz[i, j]) && (position != "X" && position != "O"))
                            {
                                matriz[i, j] = XorO;
                                comprobarEnd();
                                cambiarFicha();
                                isValidPosition = true;
                            }
                        }
                    }
                    if (!isValidPosition)
                    {
                        if (turnosMAX == turnoActual)
                        {
                            isEnd = true;
                        }
                        else
                        {
                            Console.WriteLine("Por favor inserte una posición valida...");
                        }

                    }
                } while (!isValidPosition);


                isValidPosition = false;
                Console.Clear();
            } while (!isEnd);

            isEnd = false;
        }

        static string jugadorActual = "";
        public static void cambiarFicha()
        {
            XorOBool = !XorOBool;

            if (XorOBool)
            {
                XorO = "X";
                jugadorActual = jugador1;
            }
            else
            {
                XorO = "O";
                jugadorActual = jugador2;
            }

        }
        public static void comprobarEnd()
        {
            for (int i = 0; i < 3; i++)
            {
                if (matriz[i, 0] == XorO && matriz[i, 1] == XorO && matriz[i, 2] == XorO)
                {
                    isEnd = true;
                    ganador = jugadorActual;
                }
            }


            for (int j = 0; j < 3; j++)
            {
                if (matriz[0, j] == XorO && matriz[1, j] == XorO && matriz[2, j] == XorO)
                {
                    isEnd = true;
                    ganador = jugadorActual;
                }
            }

            if (matriz[0, 0] == XorO && matriz[1, 1] == XorO && matriz[2, 2] == XorO)
            {
                isEnd = true;
                ganador = jugadorActual;
            }

            if (matriz[0, 2] == XorO && matriz[1, 1] == XorO && matriz[2, 0] == XorO)
            {
                isEnd = true;
                ganador = jugadorActual;
            }
        }

        public static void finalGame()
        {
            Console.WriteLine("EL GANADOR ES...");
            Thread.Sleep(3000);
            Console.WriteLine(ganador);
            Console.WriteLine();
        }
    }
}
