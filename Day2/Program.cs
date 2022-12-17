using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        enum RPS
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }
        enum Awards
        {
            Loss = 0,
            Draw = 3,
            Win = 6,
            TF = -1
        }

        static readonly string inputPath = Directory.GetCurrentDirectory().Replace("Day2/bin/Debug/netcoreapp3.1", "") + "Input.txt"; //The directory of your input text file, create an Input.txt at your "System.AppContext.BaseDirectory" folder

        static List<int> scores = new List<int> { };

        static void Main()
        {
            string text = File.ReadAllText(inputPath);
            string[] lines = text.Split("\n");
            foreach (string line in lines)
            {
                string[] moves = line.Split(" ");
                Console.Write(moves[0] + "," + moves[1] + " | ");
                RPS[] states = new RPS[2] { StringToRPS(moves[0]), StringToRPS(moves[1]) };
                Console.Write(states[0] + " , " + states[1] + " | ");
                int points = PointsAwarded(states[0], states[1]);
                scores.Add(points);
                Console.Write(points + " | ");
                Console.WriteLine();
            }
            int total = 0;
            foreach (int score in scores)
            {
                total += score;
            }
            Console.WriteLine(total);
        }

        static int PointsAwarded(RPS Elf, RPS You)
        {
            if (Elf == You)
            {
                Console.Write("Draw | ");
                return (int)Awards.Draw + (int)You;
            }

            if (Elf < You && Elf != You - 2 || You == Elf - 2)
            {
                Console.Write("You Win | ");
                return (int)Awards.Win + (int)You;
            }

            if (Elf > You || You == Elf + 2)
            {
                Console.Write("You loose | ");
                return (int)Awards.Loss + (int)You;
            }

            if (Elf != You - 2)
            {
                Console.Write("You Win | ");
                return (int)Awards.Win + (int)You;
            }


            else
            {
                Console.Write("U broke smthn | ");
                return (int)Awards.TF + (int)You;
            }
        }
        static RPS StringToRPS(string input)
        {
            if (input.Contains("A") || input.Contains("X")) return RPS.Rock;
            else if (input.Contains("B") || input.Contains("Y")) return RPS.Paper;
            else if (input.Contains("C") || input.Contains("Z")) return RPS.Scissors;
            else throw null;
        }
    }
}
