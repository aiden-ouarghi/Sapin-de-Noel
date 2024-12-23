using System;
using System.Threading;

namespace SapinDeNoel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textToEnter = "★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★ ★\n";
            Console.WriteLine(textToEnter);
            int taille_sapin = 0;
            bool taille_valid = false;

            // Demander à l'utilisateur de choisir la taille du sapin
            while (!taille_valid)
            {
                Console.Write("Veuillez choisir la taille de votre sapin (entre 1 et 30) : ");

                if (int.TryParse(Console.ReadLine(), out taille_sapin) && taille_sapin >= 1 && taille_sapin <= 30)
                {
                    
                    taille_valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("/!\\ Entrée non valide ou taille hors limites.");
                    Console.ResetColor();
                }
            }

            // Couleurs pour les boules de Noël
            ConsoleColor[] couleurs_boules = {
                ConsoleColor.Red,
                ConsoleColor.Yellow,
                ConsoleColor.Cyan,
                ConsoleColor.Magenta,
                ConsoleColor.White
            };

            Random random = new Random();

            // Dessiner le sapin et l'animer
            while (true)
            {
                Console.Clear();

                Console.WriteLine($"\nVoici votre sapin de {taille_sapin} cm :\n");

                // Dessiner le sapin
                for (int i = 1; i <= taille_sapin; i++)
                {
                    for (int j = 1; j <= taille_sapin - i; j++)
                    {
                        Console.Write(" ");
                    }

                    for (int j = 1; j <= i * 2 - 1; j++)
                    {
                        if (random.Next(0, 4) == 0)
                        {
                            Console.ForegroundColor = couleurs_boules[random.Next(couleurs_boules.Length)];
                            Console.Write("O");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("*");
                        }
                    }

                    Console.ResetColor();
                    Console.WriteLine();
                }

                string dessiner_tronc = "|||";

                // Calculer la largeur du tronc
                int largeur_sapin = 2 * taille_sapin - 1;
                int espaces_tronc = (largeur_sapin - dessiner_tronc.Length) / 2;

                // Dessiner le tronc
                Console.Write(new string(' ', espaces_tronc));
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(dessiner_tronc);
                Console.ResetColor();
                Console.WriteLine();
                Thread.Sleep(500);
            }
        }
    }
}
