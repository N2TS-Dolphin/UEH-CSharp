using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Collections.Specialized;
using System.IO;
using System.Linq.Expressions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor foreground = Console.ForegroundColor;

            int choose = 0, size = 0, n = 0;
            string[] name = null;
            int[] toan = null;
            int[] ly = null;
            int[] hoa = null;
            double[] dtb = null;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("1. Nhap so luong hoc sinh.");
                Console.WriteLine("2. Nhap thong tin hoc sinh.");
                Console.WriteLine("3. In danh sach hoc sinh.");
                Console.WriteLine("4. Thoat.");
                Console.Write("Nhap lua chon cua ban: ");

                choose = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (choose)
                {
                    case 1:
                        {
                            Console.Write("Nhap so luong hoc sinh: ");
                            n = int.Parse(Console.ReadLine());

                            if(n > size)
                            {
                                name = Resize(ref name, n);
                                toan = Resize(ref toan, n);
                                ly = Resize(ref ly, n);
                                hoa = Resize(ref hoa, n);
                                dtb = Resize(ref dtb, n);
                            }

                            name = new string[n];
                            toan = new int[n];
                            ly = new int[n];
                            hoa = new int[n];
                            dtb = new double[n];
                            size = n;
                            break;
                        }
                    case 2:
                        {
                            int tmp = 0;

                            while (name[tmp] == null)
                            {
                                tmp++;
                            }

                            for (int i = tmp; i < n; i++)
                            {
                                Console.WriteLine("Nhap hoc sinh thu {0}!!!\n", i + 1);

                                Console.Write("Nhap ten hoc sinh: ");
                                name[i] = Console.ReadLine();

                                Console.Write("Nhap diem toan: ");
                                toan[i] = int.Parse(Console.ReadLine());

                                Console.Write("Nhap diem ly: ");
                                ly[i] = int.Parse(Console.ReadLine());

                                Console.Write("Nhap diem hoa: ");
                                hoa[i] = int.Parse(Console.ReadLine());

                                dtb[i] = Math.Round((toan[i] + ly[i] + hoa[i]) / 3.0, 1);
                                Console.Clear();
                            }
                            break;
                        }
                    case 3:
                        {
                            Print(name, toan, ly, hoa, dtb);

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Cam on da su dung!!!\n");

                            break;
                        }
                }
            }
        }

        static void Print(string[] name, int[] toan, int[] ly, int[] hoa, double[] dtb)
        {
            if (name == null)
                Console.WriteLine("Can't show list because don't have data.");
            else
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Ten hoc sinh           ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Toan ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Ly ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Hoa ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Diem TB ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Ket qua ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|\n");
                Console.WriteLine("----------------------------------------------------------------");

                for (int i = 0; i < name.Length; i++)
                {
                    Console.Write("| ");
                    if (dtb[i] < 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(string.Format("{0,-23}", name[i]));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.Write(string.Format("{0,-5}", toan[i]));
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.Write(string.Format("{0,-3}", ly[i]));
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.Write(string.Format("{0,-4}", hoa[i]));
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.Write(string.Format("{0,-8}", dtb[i]));
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(string.Format("{0,-7}", "Hoc lai"));
                    }

                    else if (dtb[i] >= 5 && (toan[i] < 5 || ly[i] < 5 || hoa[i] < 5))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(string.Format("{0,-23}", name[i]));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.Write(string.Format("{0,-5}", toan[i]));
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.Write(string.Format("{0,-3}", ly[i]));
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.Write(string.Format("{0,-4}", hoa[i]));
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.Write(string.Format("{0,-8}", dtb[i]));
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(string.Format("{0,-7}", "Thi lai"));
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(string.Format("{0,-23}", name[i]));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.Write(string.Format("{0,-5}", toan[i]));
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.Write(string.Format("{0,-3}", ly[i]));
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.Write(string.Format("{0,-4}", hoa[i]));
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.Write(string.Format("{0,-8}", dtb[i]));
                        Console.Write(string.Format("{0,-2}", "|"));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(string.Format("{0,-7}", "Len lop"));
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" |");
                }
                Console.WriteLine("----------------------------------------------------------------");
            }

            Console.ReadLine();
        }

        static int[] Resize(ref int[] oldArray, int newSize)
        {
            int[] newArray = new int[newSize];

            for(int i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];

            return newArray;
        }
        static string[] Resize(ref string[] oldArray, int newSize)
        {
            string[] newArray = new string[newSize];

            for (int i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];

            return newArray;
        }
        static double[] Resize(ref double[] oldArray, int newSize)
        {
            double[] newArray = new double[newSize];

            for (int i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];

            return newArray;
        }
    }
}