using System;
using System.Collections.Generic;
using System.IO;

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
        enum Award
        {
            Loss = 0,
            Draw = 3,
            Win = 6,
            TF = -1
        }
        static Dictionary<string, string> cheat = new Dictionary<string, string>()
        {
                { "A X", "C"},
                { "A Y", "A"},
                { "A Z", "B"},
                { "B X", "A"},
                { "B Y", "B"},
                { "B Z", "C"},
                { "C X", "B"},
                { "C Y", "C"},
                { "C Z", "A"}
        };

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
            Console.WriteLine("Pt. 1: " + total);

            total = 0;
            foreach (string line in lines)
            {
                string[] moves = line.Split(" ");
                int bonus = (int)StringToAward(moves[1]);
                string response = cheat[line];
                int _base = (int)StringToRPS(response);
                total += _base + bonus;
            }
            Console.WriteLine("Pt. 2: " + total);
        }

        static int PointsAwarded(RPS Elf, RPS You)
        {
            if (Elf == You)
            {
                Console.Write("Draw | ");
                return (int)Award.Draw + (int)You;
            }

            if (Elf < You && Elf != You - 2 || You == Elf - 2)
            {
                Console.Write("You Win | ");
                return (int)Award.Win + (int)You;
            }

            if (Elf > You || You == Elf + 2)
            {
                Console.Write("You loose | ");
                return (int)Award.Loss + (int)You;
            }

            if (Elf != You - 2)
            {
                Console.Write("You Win | ");
                return (int)Award.Win + (int)You;
            }


            else
            {
                Console.Write("U broke smthn | ");
                return (int)Award.TF + (int)You;
            }
        }
        static RPS StringToRPS(string input)
        {
            if (input.Contains("A") || input.Contains("X")) return RPS.Rock;
            else if (input.Contains("B") || input.Contains("Y")) return RPS.Paper;
            else if (input.Contains("C") || input.Contains("Z")) return RPS.Scissors;
            else throw null;
        }
        static Award StringToAward(string input)
        {
            if (input.Contains("X")) return Award.Loss;
            else if (input.Contains("Y")) return Award.Draw;
            else if (input.Contains("Z")) return Award.Win;
            else throw null;
        }
    }
}
