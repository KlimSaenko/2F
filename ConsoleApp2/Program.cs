using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Spirale
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sr = new StreamWriter(@"D:\primes2_out.txt", false);
            sr.Close();
            using (StreamReader g = new StreamReader(@"D:\primes2_in.txt"))
            {
                string st = g.ReadLine();
                int n = int.Parse(st);

                int[,] matrix = new int[n, n];
                int oy = 0;
                int ox = 0;
                int dx = 1;
                int dy = 0;
                int t = 0;
                int m = n;
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[oy, ox] = i + 1;
                    if (--m == 0)
                    {
                        m = n * (t % 2) + n * ((t + 1) % 2) - (t / 2 - 1) - 2;
                        int temp = dx;
                        dx = -dy;
                        dy = temp;
                        t++;
                    }
                    ox += dx;
                    oy += dy;
                    //Console.WriteLine(m);
                }
                using (StreamWriter sw = new StreamWriter(@"D:\primes2_out.txt"))
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                                sw.Write("{0} ", matrix[i, j]);
                            sw.WriteLine();
                    }
                }
                //Console.ReadKey();
            }
        }
    }
}