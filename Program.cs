using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DNA
    {
        char[,] Dna;
        public ConsoleColor[] Colors;
        static int Time;
        public DNA(char[,] dna, ConsoleColor[] colors, int time)
        {
            Dna = dna;
            Colors = colors;
            Time = time;
        }
        public void PrintDNA()
        {
            int rows = Dna.GetUpperBound(0) + 1;
            int columns = Dna.Length / rows;
            bool flag = true;

            for (int i = 0; i < rows; i++)
            {
                PrintStrDNA(rows, columns, i, flag);
            }
            flag = false;
            for (int i = rows - 1; i >= 0; i--)
            {
                PrintStrDNA(rows, columns, i, flag);
            }
        }
        private void PrintStrDNA(int rows, int columns, int i, bool flag)
        {
            for (int j = 0; j < columns; j++)
            {
                PrintCharDNA(Dna[i, j], flag, i, j);
            }
            System.Threading.Thread.Sleep(Time);
            for (int k = columns - 1; k >= 0; k--)
            {
                PrintCharDNA(Dna[i, k], !flag, i, k);
            }
            System.Threading.Thread.Sleep(Time);
            Console.WriteLine();
        }
        private void PrintCharDNA(char a, bool flag, int i, int j)
        {
            if (flag)
            {
                LogicPrintCharDna(a, i, j, Colors[0], Colors[1], Colors[2]);
            }
            else
            {
                LogicPrintCharDna(a, i, j, Colors[3], Colors[2], Colors[1]);
            }
        }
        private void LogicPrintCharDna(char a, int i, int j, ConsoleColor color1, ConsoleColor color2, ConsoleColor color3)
        {
            if (a == '@')
            {
                PrintColorChar(a, color1);
            }
            else if (a == '#')
            {
                if (i == 1 && j > 3 && j < 12)
                {
                    PrintColorChar(a, color2);
                }
                else if (i == 3 && j > 7 && j < 12)
                {
                    PrintColorChar(a, color3);
                }
                else
                {
                    PrintColorChar(a, ConsoleColor.Black);
                }
            }
            else
            {
                PrintColorChar(a, ConsoleColor.Black);
            }
        }
        private static void PrintColorChar(char a, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(a);
            Console.ResetColor();
        }
        public ConsoleColor[] RandomColors()
        {
            ConsoleColor[] colors = new ConsoleColor[4];

            ConsoleColor[] allConsoleColors = new ConsoleColor[] {
                ConsoleColor.DarkBlue, ConsoleColor.DarkGreen, ConsoleColor.Red,
                ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta,
                ConsoleColor.DarkYellow, ConsoleColor.Gray, ConsoleColor.DarkGray,
                ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Cyan,
                ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.White
            };
            Random rnd = new Random();
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = allConsoleColors[rnd.Next(0, 15)];
            }

            return colors;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            char[,] dna = new char[,]
            {
                { '1','@','#','#','#','#','#','#','#','#','#','#' },
                { '1','1','@','@','#','#','#','#','#','#','#','#' },
                { '1','1','1','1','@','@','#','#','#','#','#','#' },
                { '1','1','1','1','1','@','@','@','#','#','#','#' },
                { '1','1','1','1','1','1','1','1','@','@','@','#' },
                { '1','1','1','1','1','1','1','1','1','1','@','@' }
            };
            var standatdColors = new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.DarkMagenta, ConsoleColor.Magenta, ConsoleColor.DarkBlue };
            DNA DNA = new DNA(dna, standatdColors, 20);
            for (int i = 0; i < 100; i++)
            {
                //DNA.Colors = DNA.RandomColors();
                DNA.PrintDNA();
            }            
        }
    }
}